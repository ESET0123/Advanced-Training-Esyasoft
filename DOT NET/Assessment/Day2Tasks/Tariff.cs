using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public class Tariff
    {
        public string Name { get; set; }
        public double RatePerKwh { get; set; }
        public double FixedCharge { get; set; }

        public Tariff(string name) : this(name, 6.0) { }

        public Tariff(string name, double rate) : this(name, rate, 50.0) { }

        public Tariff(string name, double rate, double fixedCharge)
        {
            Name = name;
            RatePerKwh = rate;
            FixedCharge = fixedCharge;
        }

        public double ComputeBill(int units)
        {
            return units * RatePerKwh + FixedCharge;
        }
    }
}
