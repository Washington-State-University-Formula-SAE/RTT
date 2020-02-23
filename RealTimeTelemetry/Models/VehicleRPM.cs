using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EngineRPM
    {
        public DateTime TimeStamp { get; set; }
        public int RPM { get; set; }
        public string RPMString
        {
            get => RPM.ToString();
        }
    }
}
