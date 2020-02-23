using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DataLayer
{
    public interface IDataReadContext
    {
        EngineRPM GetMostRecentEngineRPM();
        IEnumerable<EngineRPM> GetAllEngineRPM();
        IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end);
    }
}
