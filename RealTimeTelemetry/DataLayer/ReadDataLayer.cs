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
        public EngineRPM GetMostRecentEngineRPM()
        {
            return _context.GetMostRecentEngineRPM();
        }
        public IEnumerable<EngineRPM> GetAllEngineRPM()
        {
            return _context.GetAllEngineRPM();
        }
        public IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetEngineRPMBetweenTimes(start, end);
        }

    }
}
