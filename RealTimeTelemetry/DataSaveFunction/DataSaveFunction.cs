using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace DataSaveFunction
{
    public static class DataSaveFunction
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("DataSaveFunction")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "connection")]EventData message, ILogger log)
        {
            foreach (var prop in message.SystemProperties)
            {
                if (prop.Key == "iothub-connection-device-id")
                {
                    if (prop.Value.ToString() == "EngineRPM")
                    {

                    }
                }

                System.Diagnostics.Debug.WriteLine("  {0}: {1}", prop.Key, prop.Value);
            }
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}