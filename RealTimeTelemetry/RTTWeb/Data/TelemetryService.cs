using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;

using Models;

namespace RTTWeb.Data
{
    public class TelemetryService
    {
        // https://stackoverflow.com/questions/45889855/simple-way-to-get-data-from-iot-hub-in-c-sharp
        // https://docs.microsoft.com/en-us/azure/iot-hub/quickstart-send-telemetry-dotnet

        TelemetryModel tm = new TelemetryModel();
    }
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([EventHubTrigger("myEventHubName", Connection = "myIoTHub")]string myEventHubMessage, TraceWriter log)
        {
            log.Info($"C# Event Hub trigger function processed a message: {myEventHubMessage}");
        }
    }
}
