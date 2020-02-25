using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class EngineTemperatureVM
    {
        private TelemetryService _telemetryService;

        public EngineTemperatureVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<EngineTemperature> EngineTemperatureUpdated
        {
            add { _telemetryService.EngineTemperatureUpdated += value; }
            remove { _telemetryService.EngineTemperatureUpdated -= value; }
        }
    }
}
