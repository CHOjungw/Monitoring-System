using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem
{
    abstract class Data
    {
        private string Date;
        private string Time;
        private int Value;

        public string date
        {
            get { return  this.Date; }
            set { this.Date = value; }
        }

        public string time
        {
            get { return this.Time; }
            set { this.Time = value; }
        }
        public int value
        {
            get { return this.Value; }
            set { this.Value = value; }
        }

    }
}
