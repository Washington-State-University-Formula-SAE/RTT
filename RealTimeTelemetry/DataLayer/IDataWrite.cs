using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataWrite
    {
        #region EngineRPM
        Task<VehicleRPM> InsertVehicleRPMAsync(VehicleRPM VehicleRPMs);
        Task<List<VehicleRPM>> InsertVehicleRPMAsync(List<VehicleRPM> VehicleRPMs);
        #endregion


        #region VehicleSpeed
        Task<VehicleSpeed> InsertVehicleSpeedAsync(VehicleSpeed vehicleSpeed);
        Task<List<VehicleSpeed>> InsertVehicleSpeedAsync(List<VehicleSpeed> vehicleSpeed);
        #endregion


        #region AcceleratorPosition
        Task<AcceleratorPosition> InsertAcceleratorPositionAsync(AcceleratorPosition acceleratorPosition);
        Task<List<AcceleratorPosition>> InsertAcceleratorPositionAsync(List<AcceleratorPosition> acceleratorPosition);
        #endregion


        #region BrakeActive
        Task<BrakeActive> InsertBrakeActiveAsync(BrakeActive brakeActive);
        Task<List<BrakeActive>> InsertBrakeActiveAsync(List<BrakeActive> brakeActive);
        #endregion


        #region GearActive
        Task<GearActive> InsertGearActiveAsync(GearActive gearActive);
        Task<List<GearActive>> InsertGearActiveAsync(List<GearActive> gearActive);
        #endregion


        #region WheelSpeed
        Task<WheelSpeed> InsertWheelSpeedAsync(WheelSpeed wheelSpeed);
        Task<List<WheelSpeed>> InsertWheelSpeedAsync(List<WheelSpeed> wheelSpeed);
        #endregion


        #region SteeringPosition
        Task<SteeringPosition> InsertSteeringPositionAsync(SteeringPosition steeringPosition);
        Task<List<SteeringPosition>> InsertSteeringPositionAsync(List<SteeringPosition> steeringPosition);
        #endregion


        #region EngineTemperature
        Task<EngineTemperature> InsertEngineTemperatureAsync(EngineTemperature engineTemperature);
        Task<List<EngineTemperature>> InsertEngineTemperatureAsync(List<EngineTemperature> engineTemperature);
        #endregion
    }
}
