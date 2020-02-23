using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class WriteDataLayer
    {
        private IDataWriteContext _context;
        public WriteDataLayer()
        {
            _context = new SQLData();
        }
        public EngineRPM InsertRPM(EngineRPM engineRPMs)
        {
            return _context.InsertRPM(engineRPMs);
        }
        public List<EngineRPM> InsertRPM(List<EngineRPM> engineRPMs)
        {
            return _context.InsertRPM(engineRPMs);
        }
    }
}