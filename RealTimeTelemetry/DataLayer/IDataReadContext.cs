using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DataLayer
{
    public interface IDataReadContext
    {
        // Engine RPM
        EngineRPM GetMostRecentVehicleRPM();
        IEnumerable<EngineRPM> GetAllVehicleRPM();
        IEnumerable<EngineRPM> GetVehicleRPMBetweenTimes(DateTime start, DateTime end);

        // Vehicle Speed
        VehicleSpeed GetMostRecentVehicleSpeed();
        IEnumerable<VehicleSpeed> GetAllVehicleSpeed();
        IEnumerable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end);

        // Accelerator Position
        AcceleratorPosition GetMostRecentAccelatorPosition();
        IEnumerable<AcceleratorPosition> GetAllAcceleratorPosition();
        IEnumerable<AcceleratorPosition> GetAcceleratorPositionBetweenTimes(DateTime start, DateTime end);

        // Brake Active
        BrakeActive GetMostRecentBrakeActive();
        IEnumerable<BrakeActive> GetAllBrakeActive();
        IEnumerable<BrakeActive> GetBrakeActiveBetweenTimes(DateTime start, DateTime end);

        // Gear Active
        GearActive GetMostRecentGearActive();
        IEnumerable<GearActive> GetAllGearActive();
        IEnumerable<GearActive> GetGearActiveBetweenTimes(DateTime start, DateTime end);

        // Wheel Speed
        WheelSpeed GetMostRecentWheelSpeed();
        IEnumerable<WheelSpeed> GetAllWheelSpeed();
        IEnumerable<WheelSpeed> GetWheelSpeedBetweenTimes(DateTime start, DateTime end);

        // Steering Position
        SteeringPosition GetMostRecentSteeringPosition();
        IEnumerable<SteeringPosition> GetAllSteeringPosition();
        IEnumerable<SteeringPosition> GetSteeringPositionBetweenTimes(DateTime start, DateTime end);
    }
}
