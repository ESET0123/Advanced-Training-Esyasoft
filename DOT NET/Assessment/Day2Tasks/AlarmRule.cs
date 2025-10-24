using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public abstract class AlarmRule
    {
        public string Name { get; }

        protected AlarmRule(string name)
        {
            Name = name;
        }

        public abstract bool IsTriggered(LoadProfileDay day);

        public virtual string Message(LoadProfileDay day)
        {
            return $"{Name} triggered on {day.Date:yyyy-MM-dd}";
        }
    }

    public class PeakOveruseRule : AlarmRule
    {
        private readonly int _threshold;

        public PeakOveruseRule(int threshold) : base("PeakOveruse")
        {
            _threshold = threshold;
        }

        public override bool IsTriggered(LoadProfileDay day)
        {
            return day.Total > _threshold;
        }
    }

    public class SustainedOutageRule : AlarmRule
    {
        private readonly int _minConsecutive;

        public SustainedOutageRule(int min) : base("SustainedOutage")
        {
            _minConsecutive = min;
        }

        public override bool IsTriggered(LoadProfileDay day)
        {
            int consecutiveZeros = 0;
            foreach (var kwh in day.HourlyKwh)
            {
                if (kwh == 0)
                {
                    consecutiveZeros++;
                    if (consecutiveZeros >= _minConsecutive)
                    {
                        return true;
                    }
                }
                else
                {
                    consecutiveZeros = 0;
                }
            }
            return false;
        }
    }
}
