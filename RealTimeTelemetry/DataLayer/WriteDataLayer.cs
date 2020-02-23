using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class WriteDataLayer
    {
        private IDataWriteContext _context;
        public WriteDataLayer()
        {
            _context = new SQLData();
        }

        // Engine RPM
        public EngineRPM InsertVehicleRPM(EngineRPM engineRPMs)
        {
            return _context.InsertVehicleRPM(engineRPMs);
        }
        public List<EngineRPM> InsertVehicleRPM(List<EngineRPM> engineRPMs)
        {
            return _context.InsertVehicleRPM(engineRPMs);
        }

        // Vehicle Speed
        public VehicleSpeed InsertVehicleSpeed(VehicleSpeed vehicleSpeed)
        {
            return _context.InsertVehicleSpeed(vehicleSpeed);
        }
        public List<VehicleSpeed> InsertVehicleSpeed(List<VehicleSpeed> vehicleSpeed)
        {
            return _context.InsertVehicleSpeed(List<VehicleSpeed> vehicleSpeed);
        }

        // Accelerator Position
        public AcceleratorPosition InsertAcceleratorPosition(AcceleratorPosition accelPos)
        {
            return _context.InsertAcceleratorPosition(accelPos);
        }
        public List<AcceleratorPosition> InsertAcceleratorPosition(List<AcceleratorPosition> accelPos)
        {
            return _context.InsertAcceleratorPosition(accelPos);
        }

        // Brake Active
        public BrakeActive InsertBrakeActive(BrakeActive brakeActive)
        {
            return _context.InsertBrakeActive(brakeActive);
        }
        public List<BrakeActive> InsertBrakeActive(List<BrakeActive> brakeActive)
        {
            return _context.InsertBrakeActive(brakeActive);
        }

        // Gear Active
        public GearActive InsertGearActive(GearActive gearActive)
        {
            return _context.InsertGearActive(gearActive);
        }
        public List<GearActive> InsertGearActive(List<GearActive> gearActive)
        {
            return _context.InsertGearActive(gearActive);
        }

        // Wheel Speed
        public WheelSpeed InsertWheelSpeed(WheelSpeed wheelSpeed)
        {
            return _context.InsertWheelSpeed(wheelSpeed);
        }
        public List<WheelSpeed> InsertWheelSpeed(List<WheelSpeed> wheelSpeed)
        {
            return _context.InsertWheelSpeed(wheelSpeed);
        }

        // Steering Position
        public SteeringPosition InsertSteeringPosition(SteeringPosition steeringPos)
        {
            return _context.InsertSteeringPosition(steeringPos);
        }
        public List<SteeringPosition> InsertSteeringPosition(List<SteeringPosition> steeringPos)
        {
            return _context.InsertSteeringPosition(steeringPos);
        }
    }
}