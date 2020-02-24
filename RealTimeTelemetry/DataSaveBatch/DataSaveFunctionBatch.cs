using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.EventHubs;
using System.Text;
using Microsoft.Extensions.Logging;
using DataLayer;
using Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataSaveFunction
{
    public static class DataSaveFunctionBatch
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private static WriteDataLayer _context = new WriteDataLayer(new SQLDatabase(connectionString));

        [FunctionName("DataSaveFunction")]
        public static async void Run([IoTHubTrigger("messages/events", Connection = "connection")]EventData[] messages, ILogger log)
        {
            List<VehicleRPM> vehicleRPMs = new List<VehicleRPM>();
            List<AcceleratorPosition> acceleratorPositions = new List<AcceleratorPosition>();
            List<VehicleSpeed> vehicleSpeeds = new List<VehicleSpeed>();
            List<GearActive> gearActives = new List<GearActive>();
            List<WheelSpeed> wheelSpeeds = new List<WheelSpeed>();
            List<SteeringPosition> steeringPositions = new List<SteeringPosition>();
            foreach (var message in messages)
            {
                if (message.SystemProperties.ContainsKey("iothub-connection-device-id"))
                {
                    switch (message.SystemProperties["iothub-connection-device-id"].ToString().ToLower())
                    {
                        case "vehiclerpm":
                            VehicleRPM vehicleRPM = new VehicleRPM();
                            vehicleRPM.RPM = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                            vehicleRPM.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                            vehicleRPMs.Add(vehicleRPM);
                            break;
                        case "acceleratorposition":
                            AcceleratorPosition acceleratorPosition = new AcceleratorPosition();
                            acceleratorPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                            acceleratorPosition.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                            acceleratorPositions.Add(acceleratorPosition);
                            break;
                        case "vehiclespeed":
                            VehicleSpeed vehicleSpeed = new VehicleSpeed();
                            vehicleSpeed.Speed = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                            vehicleSpeed.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                            vehicleSpeeds.Add(vehicleSpeed);
                            break;
                        case "vehiclegearactive":
                            GearActive gearActive = new GearActive();
                            gearActive.Gear = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                            gearActive.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                            gearActives.Add(gearActive);
                            break;
                        case "wheelspeed":
                            WheelSpeed wheelSpeed = new WheelSpeed();
                            string[] allWheels = Encoding.UTF8.GetString(message.Body.Array).Split(',');
                            wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[0]);
                            wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[1]);
                            wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[2]);
                            wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[3]);
                            wheelSpeed.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                            wheelSpeeds.Add(wheelSpeed);
                            break;
                        case "steeringposition":
                            SteeringPosition steeringPosition = new SteeringPosition();
                            steeringPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                            steeringPosition.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                            steeringPositions.Add(steeringPosition);
                            break;
                        default:
                            log.LogWarning($"{message.SystemProperties["iothub - connection - device - id"].ToString().ToLower()} was not found in switch statement");
                            break;
                    }
                }
                //log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
            }
            await _context.InsertVehicleRPMAsync(vehicleRPMs);
            await _context.InsertAcceleratorPositionAsync(acceleratorPositions);
            await _context.InsertVehicleSpeedAsync(vehicleSpeeds);
            await _context.InsertGearActiveAsync(gearActives);
            await _context.InsertWheelSpeedAsync(wheelSpeeds);
            await _context.InsertSteeringPositionAsync(steeringPositions);
        }
    }
}