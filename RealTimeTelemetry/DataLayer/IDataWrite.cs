using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDataWrite
    {
        #region EngineRPM
        VehicleRPM InsertVehicleRPM(VehicleRPM VehicleRPMs);
        List<VehicleRPM> InsertVehicleRPM(List<VehicleRPM> VehicleRPMs);
        #endregion


        #region VehicleSpeed
        VehicleSpeed InsertVehicleSpeed(VehicleSpeed vehicleSpeed);
        List<VehicleSpeed> InsertVehicleSpeed(List<VehicleSpeed> vehicleSpeed);
        #endregion


        #region AcceleratorPosition
        AcceleratorPosition InsertAcceleratorPosition(AcceleratorPosition acceleratorPosition);
        List<AcceleratorPosition> InsertAcceleratorPosition(List<AcceleratorPosition> acceleratorPosition);
        #endregion


        #region BrakeActive
        BrakeActive InsertBrakeActive(BrakeActive brakeActive);
        List<BrakeActive> InsertBrakeActive(List<BrakeActive> brakeActive);
        #endregion


        #region GearActive
        GearActive InsertGearActive(GearActive gearActive);
        List<GearActive> InsertGearActive(List<GearActive> gearActive);
        #endregion


        #region WheelSpeed
        WheelSpeed InsertWheelSpeed(WheelSpeed wheelSpeed);
        List<WheelSpeed> InsertWheelSpeed(List<WheelSpeed> wheelSpeed);
        #endregion


        #region SteeringPosition
        SteeringPosition InsertSteeringPosition(SteeringPosition steeringPosition);
        List<SteeringPosition> InsertSteeringPosition(List<SteeringPosition> steeringPosition);
        #endregion


        #region EngineTemperature
        EngineTemperature InsertEngineTemperature(EngineTemperature engineTemperature);
        List<EngineTemperature> InsertEngineTemperature(List<EngineTemperature> engineTemperature);
        #endregion
    }
}
