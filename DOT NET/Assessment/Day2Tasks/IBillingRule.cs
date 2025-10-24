using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public interface IBillingRule
    {
        double Compute(int units);
    }

    public class DomesticRule : IBillingRule
    {
        public double Compute(int units)
        {
            return 6.0 * units + 50.0;
        }
    }

    public class CommercialRule : IBillingRule
    {
        public double Compute(int units)
        {
            return 8.5 * units + 150.0;
        }
    }

    public class AgricultureRule : IBillingRule
    {
        public double Compute(int units)
        {
            return 3.0 * units + 0.0;
        }
    }

    public class BillingEngine
    {
        public IBillingRule Rule { get; set; }

        public double GenerateBill(int units)
        {
            return Rule.Compute(units);
        }
    }
}
