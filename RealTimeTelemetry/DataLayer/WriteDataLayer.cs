using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class WriteDataLayer
    {
        private IDataWrite _context;
        public WriteDataLayer(IDataWrite context)
        {
            _context = context ?? throw new Exception("Data write context cannot be null!");
        }

        #region EngineRPM
        public VehicleRPM InsertVehicleRPM(VehicleRPM VehicleRPMs)
        {
            return _context.InsertVehicleRPM(VehicleRPMs);
        }
        public List<VehicleRPM> InsertVehicleRPM(List<VehicleRPM> VehicleRPMs)
        {
            return _context.InsertVehicleRPM(VehicleRPMs);
        }
        #endregion


        #region VehicleSpeed
        public VehicleSpeed InsertVehicleSpeed(VehicleSpeed vehicleSpeed)
        {
            return _context.InsertVehicleSpeed(vehicleSpeed);
        }
        public List<VehicleSpeed> InsertVehicleSpeed(List<VehicleSpeed> vehicleSpeed)
        {
            return _context.InsertVehicleSpeed(vehicleSpeed);
        }
        #endregion


        #region AcceleratorPosition
        public AcceleratorPosition InsertAcceleratorPosition(AcceleratorPosition accelPos)
        {
            return _context.InsertAcceleratorPosition(accelPos);
        }
        public List<AcceleratorPosition> InsertAcceleratorPosition(List<AcceleratorPosition> accelPos)
        {
            return _context.InsertAcceleratorPosition(accelPos);
        }
        #endregion


        #region Brake Active
        public BrakeActive InsertBrakeActive(BrakeActive brakeActive)
        {
            return _context.InsertBrakeActive(brakeActive);
        }
        public List<BrakeActive> InsertBrakeActive(List<BrakeActive> brakeActive)
        {
            return _context.InsertBrakeActive(brakeActive);
        }
        #endregion


        #region GearActive
        public GearActive InsertGearActive(GearActive gearActive)
        {
            return _context.InsertGearActive(gearActive);
        }
        public List<GearActive> InsertGearActive(List<GearActive> gearActive)
        {
            return _context.InsertGearActive(gearActive);
        }
        #endregion


        #region WheelSpeed
        public WheelSpeed InsertWheelSpeed(WheelSpeed wheelSpeed)
        {
            return _context.InsertWheelSpeed(wheelSpeed);
        }
        public List<WheelSpeed> InsertWheelSpeed(List<WheelSpeed> wheelSpeed)
        {
            return _context.InsertWheelSpeed(wheelSpeed);
        }
        #endregion


        #region SteeringPosition
        public SteeringPosition InsertSteeringPosition(SteeringPosition steeringPos)
        {
            return _context.InsertSteeringPosition(steeringPos);
        }
        public List<SteeringPosition> InsertSteeringPosition(List<SteeringPosition> steeringPos)
        {
            return _context.InsertSteeringPosition(steeringPos);
        }
        #endregion
    }
}