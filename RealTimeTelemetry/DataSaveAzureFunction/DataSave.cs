using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using DataLayer;
using Models;
using System;
using System.Globalization;

namespace DataSaveFunction
{
    public static class DataSaveFunction
    {
        [FunctionName("DataSaveFunction")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "connection")]EventData message, ILogger log)
        {
            WriteDataLayer context = new WriteDataLayer();
            if (message.SystemProperties.ContainsKey("iothub-connection-device-id"))
            {
                var format = "dd/MM/yyyy HH:mm:ss tt";
                switch (message.SystemProperties["iothub-connection-device-id"])
                {
                    case "EngineRPM":
                        EngineRPM erpm = new EngineRPM();
                        erpm.RPM = Convert.ToInt32(Encoding.UTF8.GetString(message.Body.Array));
                        string messageStr = message.SystemProperties["iothub-enqueuedtime"].ToString();
                        erpm.TimeStamp = (DateTime)message.SystemProperties["iothub-enqueuedtime"];
                        context.InsertRPM(erpm);
                        break;
                }
            }

            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}