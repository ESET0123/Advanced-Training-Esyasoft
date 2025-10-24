using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public abstract class Event
    {
        public DateTime When { get; }
        public string MeterSerial { get; }

        protected Event(DateTime when, string meterSerial)
        {
            When = when;
            MeterSerial = meterSerial;
        }

        public abstract string Category { get; }
        public abstract int Severity { get; }

        public virtual string Describe()
        {
            return $"{When:yyyy-MM-dd HH:mm} [{Category}] {MeterSerial}";
        }
    }

    public class OutageEvent : Event
    {
        public double DurationMinutes { get; }

        public OutageEvent(DateTime when, string meterSerial, double durationMinutes) : base(when, meterSerial)
        {
            DurationMinutes = durationMinutes;
        }

        public override string Category => "OUTAGE";
        public override int Severity => 3;

        public override string Describe()
        {
            return $"{base.Describe()} | Duration: {DurationMinutes} min | Severity: {Severity}";
        }
    }

    public class TamperEvent : Event
    {
        public string Code { get; }

        public TamperEvent(DateTime when, string meterSerial, string code) : base(when, meterSerial)
        {
            Code = code;
        }

        public override string Category => "TAMPER";
        public override int Severity => 5;

        public override string Describe()
        {
            return $"{base.Describe()} | Code: {Code} | Severity: {Severity}";
        }
    }

    public class VoltageEvent : Event
    {
        public double Voltage { get; }

        public VoltageEvent(DateTime when, string meterSerial, double voltage) : base(when, meterSerial)
        {
            Voltage = voltage;
        }

        public override string Category => "VOLTAGE";
        public override int Severity => 2;

        public override string Describe()
        {
            return $"{base.Describe()} | V: {Voltage} | Severity: {Severity}";
        }
    }

    public class EventProcessor
    {
        public static void PrintTopSevere(IEnumerable<Event> events, int topN)
        {
            var topEvents = events.OrderByDescending(e => e.Severity).ThenByDescending(e => e.When).Take(topN);
            foreach (var ev in topEvents)
            {
                Console.WriteLine(ev.Describe());
            }
        }
    }
}
