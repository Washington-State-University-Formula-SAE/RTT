using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataLayer
{
    public interface IDataRead
    {
        #region EngineRPM
        Task<VehicleRPM> GetMostRecentVehicleRPMAsync();
        IQueryable<VehicleRPM> GetAllVehicleRPM();
        IQueryable<VehicleRPM> GetVehicleRPMBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region VehicleSpeed
        Task<VehicleSpeed> GetMostRecentVehicleSpeedAsync();
        IQueryable<VehicleSpeed> GetAllVehicleSpeed();
        IQueryable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region AcceleratorPosition
        Task<AcceleratorPosition> GetMostRecentAccelatorPositionAsync();
        IQueryable<AcceleratorPosition> GetAllAcceleratorPosition();
        IQueryable<AcceleratorPosition> GetAcceleratorPositionBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region BrakeActive
        Task<BrakeActive> GetMostRecentBrakeActiveAsync();
        IQueryable<BrakeActive> GetAllBrakeActive();
        IQueryable<BrakeActive> GetBrakeActiveBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region GearActive
        Task<GearActive> GetMostRecentGearActiveAsync();
        IQueryable<GearActive> GetAllGearActive();
        IQueryable<GearActive> GetGearActiveBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region WheelSpeed
        Task<WheelSpeed> GetMostRecentWheelSpeedAsync();
        IQueryable<WheelSpeed> GetAllWheelSpeed();
        IQueryable<WheelSpeed> GetWheelSpeedBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region SteeringPosition
        Task<SteeringPosition> GetMostRecentSteeringPositionAsync();
        IQueryable<SteeringPosition> GetAllSteeringPosition();
        IQueryable<SteeringPosition> GetSteeringPositionBetweenTimes(DateTime start, DateTime end);
        #endregion


        #region EngineTemperature
        Task<EngineTemperature> GetMostRecentEngineTemperatureAsync();
        IQueryable<EngineTemperature> GetAllEngineTemperature();
        IQueryable<EngineTemperature> GetEngineTemperatureBetweenTimes(DateTime start, DateTime end);
        #endregion
    }
}
