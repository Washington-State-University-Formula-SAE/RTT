using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    interface IDataWriteContext
    {
        VehicleRPM InsertRPM(VehicleRPM engineRPMs);
        List<VehicleRPM> InsertRPM(List<VehicleRPM> engineRPMs);
    }
}
