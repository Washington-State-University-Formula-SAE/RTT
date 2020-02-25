using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class AcceleratorPositionVM
    {
        private TelemetryService _telemetryService;

        public AcceleratorPositionVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<AcceleratorPosition> AcceleratorPositionUpdated
        {
            add { _telemetryService.AcceleratorPositionUpdated += value; }
            remove { _telemetryService.AcceleratorPositionUpdated -= value; }
        }
    }
}
