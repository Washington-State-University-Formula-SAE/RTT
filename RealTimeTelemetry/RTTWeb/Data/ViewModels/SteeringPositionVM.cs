using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTTWeb.Data.ViewModels
{
    public class SteeringPositionVM
    {
        private TelemetryService _telemetryService;

        public SteeringPositionVM(TelemetryService telemService)
        {
            _telemetryService = telemService;
        }
        public event EventHandler<SteeringPosition> SteeringPositionUpdated
        {
            add { _telemetryService.SteeringPositionUpdated += value; }
            remove { _telemetryService.SteeringPositionUpdated -= value; }
        }
    }
}
