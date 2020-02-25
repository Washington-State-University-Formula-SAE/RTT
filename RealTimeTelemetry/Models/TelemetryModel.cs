namespace Models
{
    public class TelemetryModel
    {
        public delegate void EventHandler();

        public event EventHandler VehicleRPMChanged = delegate { };
        private VehicleRPM _vehicleRPM;
        public VehicleRPM VehicleRPM
        {
            get => _vehicleRPM;
            set
            {
                _vehicleRPM = value;
                VehicleRPMChanged();
            }
        }

        public event EventHandler AcceleratorPositionChanged = delegate { };
        private AcceleratorPosition _acceleratorPosition;
        public AcceleratorPosition AcceleratorPosition
        {
            get => _acceleratorPosition;
            set
            {
                _acceleratorPosition = value;
                AcceleratorPositionChanged();
            }
        }

        public event EventHandler BrakeActiveChanged = delegate { };
        private BrakeActive _brakeActive;
        public BrakeActive BrakeActive
        {
            get => _brakeActive;
            set
            {
                _brakeActive = value;
                BrakeActiveChanged();
            }
        }

        public event EventHandler GearActiveChanged = delegate { };
        private GearActive _gearActive;
        public GearActive GearActive
        {
            get => _gearActive;
            set
            {
                _gearActive = value;
                GearActiveChanged();
            }
        }

        public event EventHandler EngineTemperatureChanged = delegate { };
        private EngineTemperature _engineTemperature;
        public EngineTemperature EngineTemperature
        {
            get => _engineTemperature;
            set
            {
                _engineTemperature = value;
                EngineTemperatureChanged();
            }
        }

        public event EventHandler WheelSpeedChanged = delegate { };
        private WheelSpeed _wheelSpeed;
        public WheelSpeed WheelSpeed
        {
            get => _wheelSpeed;
            set
            {
                _wheelSpeed = value;
                WheelSpeedChanged();
            }
        }

        public event EventHandler VehicleSpeedChanged = delegate { };
        private VehicleSpeed _vehicleSpeed;
        public VehicleSpeed VehicleSpeed
        {
            get => _vehicleSpeed;
            set
            {
                _vehicleSpeed = value;
                VehicleSpeedChanged();
            }
        }

        public event EventHandler SteeringPositionChanged = delegate { };
        private SteeringPosition _steeringPosition;
        public SteeringPosition SteeringPosition
        {
            get => _steeringPosition;
            set
            {
                _steeringPosition = value;
                SteeringPositionChanged();
            }
        }

    }
}
