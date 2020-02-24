using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DataLayer
{
    public interface IDataRead
    {
        #region EngineRPM
        VehicleRPM GetMostRecentVehicleRPM();
        IEnumerable<VehicleRPM> GetAllVehicleRPM();
        IEnumerable<VehicleRPM> GetVehicleRPMBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region VehicleSpeed
        VehicleSpeed GetMostRecentVehicleSpeed();
        IEnumerable<VehicleSpeed> GetAllVehicleSpeed();
        IEnumerable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region AcceleratorPosition
        AcceleratorPosition GetMostRecentAccelatorPosition();
        IEnumerable<AcceleratorPosition> GetAllAcceleratorPosition();
        IEnumerable<AcceleratorPosition> GetAcceleratorPositionBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region BrakeActive
        BrakeActive GetMostRecentBrakeActive();
        IEnumerable<BrakeActive> GetAllBrakeActive();
        IEnumerable<BrakeActive> GetBrakeActiveBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region GearActive
        GearActive GetMostRecentGearActive();
        IEnumerable<GearActive> GetAllGearActive();
        IEnumerable<GearActive> GetGearActiveBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region WheelSpeed
        WheelSpeed GetMostRecentWheelSpeed();
        IEnumerable<WheelSpeed> GetAllWheelSpeed();
        IEnumerable<WheelSpeed> GetWheelSpeedBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region SteeringPosition
        SteeringPosition GetMostRecentSteeringPosition();
        IEnumerable<SteeringPosition> GetAllSteeringPosition();
        IEnumerable<SteeringPosition> GetSteeringPositionBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region EngineTemperature
        EngineTemperature GetMostRecentEngineTemperature();
        IEnumerable<EngineTemperature> GetAllEngineTemperature();
        IEnumerable<EngineTemperature> GetEngineTemperatureBetweenTimes(DateTime start, DateTime end);
        #endregion
    }
}
