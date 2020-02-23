using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DataLayer
{
    public interface IDataReadContext
    {
        // Engine RPM
        EngineRPM GetMostRecentEngineRPM();
        IEnumerable<EngineRPM> GetAllEngineRPM();
        IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end);

        /*
        // Vehicle Speed
        VehicleSpeed GetMostRecentVehicleSpeed();
        IEnumerable<VehicleSpeed> GetAllVehicleSpeed();
        IEnumerable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end);

        // Accelator Position
        EngineRPM GetMostRecentAccelator();
        IEnumerable<EngineRPM> GetAllEngineRPM();
        IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end);

        // Brake Active
        EngineRPM GetMostRecentEngineRPM();
        IEnumerable<EngineRPM> GetAllEngineRPM();
        IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end);

        // Gear Active
        EngineRPM GetMostRecentEngineRPM();
        IEnumerable<EngineRPM> GetAllEngineRPM();
        IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end);

        // Wheel Speed
        EngineRPM GetMostRecentEngineRPM();
        IEnumerable<EngineRPM> GetAllEngineRPM();
        IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end);

        // Steering Position
        EngineRPM GetMostRecentEngineRPM();
        IEnumerable<EngineRPM> GetAllEngineRPM();
        IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end);
        */
    }
}
