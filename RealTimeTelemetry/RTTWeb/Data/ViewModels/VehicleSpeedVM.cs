using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class VehicleSpeedVM
    {
        private TelemetryService _telemetryService;

        public VehicleSpeedVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<VehicleSpeed> VehicleSpeedUpdated
        {
            add { _telemetryService.VehicleSpeedUpdated += value; }
            remove { _telemetryService.VehicleSpeedUpdated -= value; }
        }
    }
}
