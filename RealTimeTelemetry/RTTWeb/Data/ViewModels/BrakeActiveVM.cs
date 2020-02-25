using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class BrakeActiveVM
    {
        private TelemetryService _telemetryService;

        public BrakeActiveVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<BrakeActive> BrakeActiveUpdated
        {
            add { _telemetryService.BrakeActiveUpdated += value; }
            remove { _telemetryService.BrakeActiveUpdated -= value; }
        }
    }
}
