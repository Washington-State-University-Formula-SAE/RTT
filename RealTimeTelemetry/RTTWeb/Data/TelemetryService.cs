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
        // https://stackoverflow.com/questions/45889855/simple-way-to-get-data-from-iot-hub-in-c-sharp
        // https://docs.microsoft.com/en-us/azure/iot-hub/quickstart-send-telemetry-dotnet

        // Event Hub-compatible endpoint
        // az iot hub show --query properties.eventHubEndpoints.events.endpoint --name {your IoT Hub name}

        // Event Hub-compatible name
        // az iot hub show --query properties.eventHubEndpoints.events.path --name {your IoT Hub name}

        // az iot hub policy show --name service --query primaryKey --hub-name {your IoT Hub name}
        private static EventHubClient s_eventHubClient;
        public TelemetryModel telemetry = new TelemetryModel();

        public TelemetryService(string s_eventHubsCompatibleEndpoint, string s_eventHubsCompatiblePath, string s_iotHubSasKeyName, string s_iotHubSasKey)
        {
            try
            {
                var connectionString = new EventHubsConnectionStringBuilder(new Uri(s_eventHubsCompatibleEndpoint), s_eventHubsCompatiblePath, s_iotHubSasKeyName, s_iotHubSasKey);
                s_eventHubClient = EventHubClient.CreateFromConnectionString(connectionString.ToString());

                // Create a PartitionReciever for each partition on the hub.
                var runtimeInfo = s_eventHubClient.GetRuntimeInformationAsync().Result;
                var d2cPartitions = runtimeInfo.PartitionIds;

                CancellationTokenSource cts = new CancellationTokenSource();

                Console.CancelKeyPress += (s, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                    System.Diagnostics.Debug.WriteLine("Exiting...");
                };


                var tasks = new List<Task>();
                foreach (string partition in d2cPartitions)
                {
                    tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token));
                }
            }
            catch (AggregateException)
            {
                return;
            }
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
                        switch (eventData.SystemProperties["iothub-connection-device-id"])
                        {
                            case "vehicleRPM":
                                VehicleRPM erpm = new VehicleRPM();
                                erpm.RPM = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                erpm.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                telemetry.VehicleRPM = erpm;
                                break;
                            case "acceleratorPosition":
                                AcceleratorPosition acceleratorPosition = new AcceleratorPosition();
                                acceleratorPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                acceleratorPosition.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                telemetry.AcceleratorPosition = acceleratorPosition;
                                break;
                            case "vehicleSpeed":
                                VehicleSpeed vehicleSpeed = new VehicleSpeed();
                                vehicleSpeed.Speed = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                vehicleSpeed.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                telemetry.VehicleSpeed = vehicleSpeed;
                                break;
                            case "vehicleGearActive":
                                GearActive gearActive = new GearActive();
                                gearActive.Gear = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                gearActive.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                telemetry.GearActive = gearActive;
                                break;
                            case "wheelSpeed":
                                WheelSpeed wheelSpeed = new WheelSpeed();
                                string[] allWheels = Encoding.UTF8.GetString(eventData.Body.Array).Split(',');
                                wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[0]);
                                wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[1]);
                                wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[2]);
                                wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[3]);
                                wheelSpeed.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                break;
                            case "steeringPosition":
                                SteeringPosition steeringPosition = new SteeringPosition();
                                steeringPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(eventData.Body.Array));
                                steeringPosition.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                telemetry.SteeringPosition = steeringPosition;
                                break;
                            case "BrakeActive":
                                BrakeActive brakeActive = new BrakeActive();
                                brakeActive.Active = Convert.ToBoolean(Encoding.UTF8.GetString(eventData.Body.Array));
                                brakeActive.TimeStamp = (DateTime)eventData.SystemProperties["iothub-enqueuedtime"];
                                telemetry.BrakeActive = brakeActive;
                                break;
                        }
                    }
                }
            }
        }
    }
}


