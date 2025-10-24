using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    //public interface IBillingRule
    //{
    //    double Compute(int units);
    //}

    public interface IRebate
    {
        string Code { get; }
        double Apply(double currentTotal, int outageDays);
    }

    //public class CommercialRule : IBillingRule
    //{
    //    public double Compute(int units)
    //    {
    //        return 8.5 * units + 150.0;
    //    }
    //}

    public class NoOutageRebate : IRebate
    {
        public string Code => "NO_OUTAGE";

        public double Apply(double currentTotal, int outageDays)
        {
            return outageDays == 0 ? currentTotal * -0.02 : 0;
        }
    }

    public class HighUsageRebate : IRebate
    {
        public string Code => "HIGH_USAGE";

        public double Apply(double currentTotal, int outageDays)
        {
            return (currentTotal > 500) ? currentTotal * -0.03 : 0;
        }
    }

    public class BillingContext
    {
        public IBillingRule Rule { get; }
        public List<IRebate> Rebates { get; } = new();

        public BillingContext(IBillingRule rule)
        {
            Rule = rule;
        }

        public double Finalize(int units, int outageDays)
        {
            double total = Rule.Compute(units);
            double rebateTotal = 0;
            foreach (var r in Rebates)
            {
                rebateTotal += r.Apply(total, outageDays);
            }
            return total + rebateTotal;
        }
    }
}
