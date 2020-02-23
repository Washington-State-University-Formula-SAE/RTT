using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class SQLData : IDataReadContext, IDataWriteContext
    {
        private TelematryContext _context;
        public SQLData()
        {
            _context = new TelematryContext();
        }

        public IEnumerable<EngineRPM> GetAllEngineRPM()
        {
            return _context.EngineRPM.AsNoTracking();
        }

        public IEnumerable<EngineRPM> GetEngineRPMBetweenTimes(DateTime start, DateTime end)
        {
            return _context.EngineRPM.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public EngineRPM GetMostRecentEngineRPM()
        {
            return _context.EngineRPM.AsNoTracking().FirstOrDefault();
        }

        public EngineRPM InsertRPM(EngineRPM engineRPM)
        {
            _context.EngineRPM.Add(engineRPM);
            _context.SaveChanges();
            _context.Entry(engineRPM).State = EntityState.Detached;
            return engineRPM;
        }

        public List<EngineRPM> InsertRPM(List<EngineRPM> engineRPMs)
        {
            _context.EngineRPM.AddRange(engineRPMs);
            _context.SaveChanges();
            _context.Entry(engineRPMs).State = EntityState.Detached;
            return engineRPMs;
        }
    }
}
