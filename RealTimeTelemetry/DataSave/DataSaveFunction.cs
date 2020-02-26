using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.EventHubs;
using System.Text;
using Microsoft.Extensions.Logging;
using DataLayer;
using Models;
using System;
using System.Configuration;

namespace DataSaveFunction
{
    public static class DataSaveFunction
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        private static WriteDataLayer _context = new WriteDataLayer(new SQLDatabase(connectionString));

        [FunctionName("DataSaveFunction")]
        public static async void Run([IoTHubTrigger("messages/events", Connection = "connection")]EventData message, ILogger log)
        {

            if (message.SystemProperties.ContainsKey("iothub-connection-device-id"))
            {
                switch (message.SystemProperties["iothub-connection-device-id"].ToString().ToLower())
                {
                    case "vehiclerpm":
                        VehicleRPM vehicleRPM = new VehicleRPM();
                        vehicleRPM.RPM = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        vehicleRPM.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        await _context.InsertVehicleRPMAsync(vehicleRPM);
                        break;
                    case "acceleratorposition":
                        AcceleratorPosition acceleratorPosition = new AcceleratorPosition();
                        acceleratorPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        acceleratorPosition.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        await _context.InsertAcceleratorPositionAsync(acceleratorPosition);
                        break;
                    case "vehiclespeed":
                        VehicleSpeed vehicleSpeed = new VehicleSpeed();
                        vehicleSpeed.Speed = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        vehicleSpeed.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        await _context.InsertVehicleSpeedAsync(vehicleSpeed);
                        break;
                    case "vehiclegearactive":
                        GearActive gearActive = new GearActive();
                        gearActive.Gear = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        gearActive.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        await _context.InsertGearActiveAsync(gearActive);
                        break;
                    case "wheelspeed":
                        WheelSpeed wheelSpeed = new WheelSpeed();
                        string[] allWheels = Encoding.UTF8.GetString(message.Body.Array).Split(',');
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[0]);
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[1]);
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[2]);
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[3]);
                        wheelSpeed.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        await _context.InsertWheelSpeedAsync(wheelSpeed);
                        break;
                    case "steeringposition":
                        SteeringPosition steeringPosition = new SteeringPosition();
                        steeringPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        steeringPosition.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        await _context.InsertSteeringPositionAsync(steeringPosition);
                        break;
                    default:
                        break;
                }
            }

            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}