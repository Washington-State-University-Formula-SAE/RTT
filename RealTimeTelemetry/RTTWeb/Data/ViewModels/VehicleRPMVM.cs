using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class VehicleRPMVM
    {
        private TelemetryService _telemetryService;

        public VehicleRPMVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<VehicleRPM> VehicleRPMChanged
        {
            add { _telemetryService.VehicleRPMUpdated += value; }
            remove { _telemetryService.VehicleRPMUpdated -= value; }
        }
    }
}
