using Models;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class ReadDataLayer
    {
        private IDataReadContext _context;
        public ReadDataLayer()
        {
            _context = new SQLData();
        }
        public VehicleRPM GetMostRecentEngineRPM()
        {
            return _context.GetMostRecentEngineRPM();
        }
        public IEnumerable<VehicleRPM> GetAllEngineRPM()
        {
            return _context.GetAllEngineRPM();
        }
        public IEnumerable<VehicleRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetEngineRPMBetweenTimes(start, end);
        }

    }
}
