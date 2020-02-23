using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    interface IDataWriteContext
    {
        EngineRPM InsertRPM(EngineRPM engineRPMs);
        List<EngineRPM> InsertRPM(List<EngineRPM> engineRPMs);
    }
}
