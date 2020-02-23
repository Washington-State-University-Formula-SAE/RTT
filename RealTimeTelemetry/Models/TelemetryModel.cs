namespace Models
{
    public class TelemetryModel
    {
        public EngineRPM EngineRPM { get; set; }
        public AcceleratorPosition AcceleratorPosition { get; set; }
        public BrakeActive BrakeActive { get; set; }
        public GearActive GearActive { get; set; }
        public SteeringPosition SteeringPosition { get; set; }
        public VehicleSpeed VehicleSpeed { get; set; }
        public WheelSpeed WheelSpeed { get; set; }
    }
}
