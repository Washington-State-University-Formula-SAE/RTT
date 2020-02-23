using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WheelSpeed
    {
        public DateTime TimeStamp { get; set; }
        public short FrontDriver { get; set; }
        public short FrontPassenger { get; set; }
        public short RearDriver { get; set; }
        public short RearPassenger { get; set; }
    }
}
