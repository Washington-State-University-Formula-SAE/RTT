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
        public static void Run([IoTHubTrigger("messages/events", Connection = "connection")]EventData message, ILogger log)
        {

            if (message.SystemProperties.ContainsKey("iothub-connection-device-id"))
            {
                switch (message.SystemProperties["iothub-connection-device-id"])
                {
                    case "vehicleRPM":
                        VehicleRPM vehicleRPM = new VehicleRPM();
                        vehicleRPM.RPM = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        vehicleRPM.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        _context.InsertVehicleRPM(vehicleRPM);
                        break;
                    case "acceleratorPosition":
                        AcceleratorPosition acceleratorPosition = new AcceleratorPosition();
                        acceleratorPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        acceleratorPosition.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        _context.InsertAcceleratorPosition(acceleratorPosition);
                        break;
                    case "vehicleSpeed":
                        VehicleSpeed vehicleSpeed = new VehicleSpeed();
                        vehicleSpeed.Speed = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        vehicleSpeed.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        _context.InsertVehicleSpeed(vehicleSpeed);
                        break;
                    case "vehicleGearActive":
                        GearActive gearActive = new GearActive();
                        gearActive.Gear = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        gearActive.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        _context.InsertGearActive(gearActive);
                        break;
                    case "wheelSpeed":
                        WheelSpeed wheelSpeed = new WheelSpeed();
                        string[] allWheels = Encoding.UTF8.GetString(message.Body.Array).Split(',');
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[0]);
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[1]);
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[2]);
                        wheelSpeed.FrontDriver = Convert.ToInt16(allWheels[3]);
                        wheelSpeed.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        _context.InsertWheelSpeed(wheelSpeed);
                        break;
                    case "steeringPosition":
                        SteeringPosition steeringPosition = new SteeringPosition();
                        steeringPosition.Position = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        steeringPosition.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        _context.InsertSteeringPosition(steeringPosition);
                        break;
                    default:
                        break;
                }
            }

            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}