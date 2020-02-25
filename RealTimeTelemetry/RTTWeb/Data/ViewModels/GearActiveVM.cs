using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class GearActiveVM
    {
        private TelemetryService _telemetryService;

        public GearActiveVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<GearActive> GearActiveUpdated
        {
            add { _telemetryService.GearActiveUpdated += value; }
            remove { _telemetryService.GearActiveUpdated -= value; }
        }
    }
}
