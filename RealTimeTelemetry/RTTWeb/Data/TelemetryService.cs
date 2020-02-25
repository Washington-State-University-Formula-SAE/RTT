using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.EventHubs;

using Models;
using System.Text;

namespace RTTWeb.Data
{
    public class TelemetryService
    {
        private static EventHubClient s_eventHubClient;
        private EventHubsConnectionStringBuilder _connectionStringBuilder;
        public event EventHandler<VehicleRPM> VehicleRPMUpdated;
        public event EventHandler<AcceleratorPosition> AcceleratorPositionUpdated;
        public event EventHandler<BrakeActive> BrakeActiveUpdated;
        public event EventHandler<EngineTemperature> EngineTemperatureUpdated;
        public event EventHandler<GearActive> GearActiveUpdated;
        public event EventHandler<SteeringPosition> SteeringPositionUpdated;
        public event EventHandler<VehicleSpeed> VehicleSpeedUpdated;
        public event EventHandler<WheelSpeed> WheelSpeedUpdated;

        public TelemetryService(string s_eventHubsCompatibleEndpoint, string s_eventHubsCompatiblePath, string s_iotHubSasKeyName, string s_iotHubSasKey)
        {
            System.Diagnostics.Debug.WriteLine($"Instatiating TelemetryService");
            _connectionStringBuilder = new EventHubsConnectionStringBuilder(new Uri(s_eventHubsCompatibleEndpoint), s_eventHubsCompatiblePath, s_iotHubSasKeyName, s_iotHubSasKey);
            ConnectToIOTHub();
        }

        public async Task<bool> ConnectToIOTHub()
        {
            while (true)
            {
                try
                {
                    bool ok = false;
                    int count = 0;
                    do
                    {
                        try
                        {
                            s_eventHubClient = EventHubClient.CreateFromConnectionString(_connectionStringBuilder.ToString());
                            System.Diagnostics.Debug.WriteLine($"Attempt to connect {count}");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"failed attempt{count}:{ex.Message}");
                        }
                        await Task.Delay(200);
                        count++;
                    } while (!ok && s_eventHubClient.IsClosed);
                    try
                    {
                        // Create a PartitionReciever for each partition on the hub.
                        var runtimeInfo = s_eventHubClient.GetRuntimeInformationAsync().Result;
                        var d2cPartitions = runtimeInfo.PartitionIds;

                        CancellationTokenSource cts = new CancellationTokenSource();

                        var tasks = new List<Task>();
                        foreach (string partition in d2cPartitions)
                        {
                            tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token));
                        }
                        try
                        {
                            foreach (var task in tasks)
                                await task;
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"failed during message Area:{ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"failed getting runtimeInfo:{ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"failed somewhere unknown!!!!!:{ex.Message}");
                }

            }
            return true;

        }

        // Asynchronously create a PartitionReceiver for a partition and then start 
        // reading any messages sent from the simulated client.
        private async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        {
            // Create the receiver using the default consumer group.
            // For the purposes of this sample, read only messages sent since 
            // the time the receiver is created. Typically, you don't want to skip any messages.
            var eventHubReceiver = s_eventHubClient.CreateReceiver("$Default", partition, EventPosition.FromEnqueuedTime(DateTime.Now));
            System.Diagnostics.Debug.WriteLine("Create receiver on partition: " + partition);
            while (true)
            {
                if (ct.IsCancellationRequested) break;
                System.Diagnostics.Debug.WriteLine("Listening for messages on: " + partition);
                // Check for EventData - this methods times out if there is nothing to retrieve.
                var events = await eventHubReceiver.ReceiveAsync(100);

                // If there is data in the batch, process it.
                if (events == null) continue;

                foreach (EventData eventData in events)
                {
                    string data = Encoding.UTF8.GetString(eventData.Body.Array);
                    if (eventData.SystemProperties.ContainsKey("iothub-connection-device-id"))
                    {
                        switch (eventData.SystemProperties["iothub-connection-device-id"].ToString().ToLower())
                        {
                            case "vehiclerpm":
                                VehicleRPM newEngineRPM = new VehicleRPM();
                                newEngineRPM.RPM = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                newEngineRPM.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                //telemetry.VehicleRPM.VehicleRPM = erpm;
                                VehicleRPMUpdated?.Invoke(this, newEngineRPM);
                                break;
                            case "acceleratorposition":
                                AcceleratorPosition newAcceleratorPosition = new AcceleratorPosition();
                                newAcceleratorPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                newAcceleratorPosition.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                AcceleratorPositionUpdated?.Invoke(this, newAcceleratorPosition);
                                break;
                            case "vehiclespeed":
                                VehicleSpeed newVehicleSpeed = new VehicleSpeed();
                                newVehicleSpeed.Speed = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                newVehicleSpeed.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                VehicleSpeedUpdated?.Invoke(this, newVehicleSpeed);
                                break;
                            case "vehiclegearactive":
                                GearActive newGearActive = new GearActive();
                                newGearActive.Gear = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                newGearActive.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                GearActiveUpdated?.Invoke(this, newGearActive);
                                break;
                            case "wheelspeed":
                                WheelSpeed newWheelSpeed = new WheelSpeed();
                                string[] allWheels = Encoding.UTF8.GetString(eventData.Body.Array).Split(',');
                                newWheelSpeed.FrontDriver = Convert.ToInt16(allWheels[0]);
                                newWheelSpeed.FrontDriver = Convert.ToInt16(allWheels[1]);
                                newWheelSpeed.FrontDriver = Convert.ToInt16(allWheels[2]);
                                newWheelSpeed.FrontDriver = Convert.ToInt16(allWheels[3]);
                                newWheelSpeed.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                WheelSpeedUpdated?.Invoke(this, newWheelSpeed);
                                break;
                            case "steeringposition":
                                SteeringPosition newSteeringPosition = new SteeringPosition();
                                newSteeringPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                newSteeringPosition.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                SteeringPositionUpdated?.Invoke(this, newSteeringPosition);
                                break;
                            case "brakeactive":
                                BrakeActive newBrakeActive = new BrakeActive();
                                newBrakeActive.Active = Convert.ToBoolean(Encoding.UTF8.GetString(eventData.Body.Array));
                                newBrakeActive.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                BrakeActiveUpdated?.Invoke(this, newBrakeActive);
                                break;
                        }
                    }
                }
            }
        }
    }
}


