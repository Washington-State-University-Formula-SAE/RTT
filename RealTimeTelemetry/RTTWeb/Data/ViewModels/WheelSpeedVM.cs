using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class WheelSpeedVM
    {
        private TelemetryService _telemetryService;

        public WheelSpeedVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<WheelSpeed> WheelSpeedUpdated
        {
            add { _telemetryService.WheelSpeedUpdated += value; }
            remove { _telemetryService.WheelSpeedUpdated -= value; }
        }
    }
}
