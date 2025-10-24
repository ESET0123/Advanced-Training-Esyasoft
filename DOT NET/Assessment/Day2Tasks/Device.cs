using Day2Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public class Device
    {
        public string Id { get; set; }
        public DateTime InstalledOn { get; set; }

        public virtual string Describe()
        {
            return $"Device Id: {Id} Installed: {InstalledOn:yyyy-MM-dd}";
        }
    }

    public class MeterDevice : Device
    {
        public int PhaseCount { get; set; }

        public override string Describe()
        {
            return $"Meter Id: {Id} | Installed: {InstalledOn:yyyy-MM-dd} | Phases: {PhaseCount}";
        }
    }

    public class GatewayDevice : Device
    {
        public string IpAddress { get; set; }

        public override string Describe()
        {
            return $"Gateway Id: {Id} | Installed: {InstalledOn:yyyy-MM-dd} | IP: {IpAddress}";
        }
    }
}