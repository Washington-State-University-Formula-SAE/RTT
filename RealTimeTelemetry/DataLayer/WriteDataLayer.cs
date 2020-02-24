using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<VehicleRPM> InsertVehicleRPMAsync(VehicleRPM VehicleRPMs)
        {
            return await _context.InsertVehicleRPMAsync(VehicleRPMs);
        }
        public async Task<List<VehicleRPM>> InsertVehicleRPMAsync(List<VehicleRPM> VehicleRPMs)
        {
            return await _context.InsertVehicleRPMAsync(VehicleRPMs);
        }
        #endregion


        #region VehicleSpeed
        public async Task<VehicleSpeed> InsertVehicleSpeedAsync(VehicleSpeed vehicleSpeed)
        {
            return await _context.InsertVehicleSpeedAsync(vehicleSpeed);
        }
        public async Task<List<VehicleSpeed>> InsertVehicleSpeedAsync(List<VehicleSpeed> vehicleSpeed)
        {
            return await _context.InsertVehicleSpeedAsync(vehicleSpeed);
        }
        #endregion


        #region AcceleratorPosition
        public async Task<AcceleratorPosition> InsertAcceleratorPositionAsync(AcceleratorPosition accelPos)
        {
            return await _context.InsertAcceleratorPositionAsync(accelPos);
        }
        public async Task<List<AcceleratorPosition>> InsertAcceleratorPositionAsync(List<AcceleratorPosition> accelPos)
        {
            return await _context.InsertAcceleratorPositionAsync(accelPos);
        }
        #endregion


        #region Brake Active
        public async Task<BrakeActive> InsertBrakeActiveAsync(BrakeActive brakeActive)
        {
            return await _context.InsertBrakeActiveAsync(brakeActive);
        }
        public async Task<List<BrakeActive>> InsertBrakeActiveAsync(List<BrakeActive> brakeActive)
        {
            return await _context.InsertBrakeActiveAsync(brakeActive);
        }
        #endregion


        #region GearActive
        public async Task<GearActive> InsertGearActiveAsync(GearActive gearActive)
        {
            return await _context.InsertGearActiveAsync(gearActive);
        }
        public async Task<List<GearActive>> InsertGearActiveAsync(List<GearActive> gearActive)
        {
            return await _context.InsertGearActiveAsync(gearActive);
        }
        #endregion


        #region WheelSpeed
        public async Task<WheelSpeed> InsertWheelSpeedAsync(WheelSpeed wheelSpeed)
        {
            return await _context.InsertWheelSpeedAsync(wheelSpeed);
        }
        public async Task<List<WheelSpeed>> InsertWheelSpeedAsync(List<WheelSpeed> wheelSpeed)
        {
            return await _context.InsertWheelSpeedAsync(wheelSpeed);
        }
        #endregion


        #region SteeringPosition
        public async Task<SteeringPosition> InsertSteeringPositionAsync(SteeringPosition steeringPos)
        {
            return await _context.InsertSteeringPositionAsync(steeringPos);
        }
        public async Task<List<SteeringPosition>> InsertSteeringPositionAsync(List<SteeringPosition> steeringPos)
        {
            return await _context.InsertSteeringPositionAsync(steeringPos);
        }
        #endregion
    }
}