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
        public VehicleRPM InsertRPM(VehicleRPM engineRPMs)
        {
            return _context.InsertRPM(engineRPMs);
        }
        public List<VehicleRPM> InsertRPM(List<VehicleRPM> engineRPMs)
        {
            return _context.InsertRPM(engineRPMs);
        }
    }
}