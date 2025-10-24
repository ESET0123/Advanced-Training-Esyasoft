using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public class Meter
    {
        public string MeterSerial { get; set; }
        public string Location { get; set; }
        public DateTime InstalledOn { get; set; }
        public int LastReadingKwh { get; set; }

        public void AddReading(int deltaKwh)
        {
            if (deltaKwh > 0)
            {
                LastReadingKwh += deltaKwh;
            }
        }

        public string Summary()
        {
            return $"{MeterSerial} Location: {Location} | Reading: {LastReadingKwh}";
        }
    }
}
