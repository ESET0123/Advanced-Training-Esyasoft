using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public class LoadProfileDay
    {
        public DateTime Date { get; }
        public int[] HourlyKwh { get; }

        public LoadProfileDay(DateTime date, int[] hourly)
        {
            if (hourly == null || hourly.Length != 24)
            {
                throw new ArgumentException("HourlyKwh array must be of length 24.");
            }

            if (hourly.Any(kwh => kwh < 0))
            {
                throw new ArgumentException("HourlyKwh values cannot be negative.");
            }

            Date = date.Date;
            HourlyKwh = (int[])hourly.Clone();
        }

        public int Total => HourlyKwh.Sum();

        public int PeakHour
        {
            get
            {
                int maxKwh = HourlyKwh.Max();
                return Array.IndexOf(HourlyKwh, maxKwh);
            }
        }
    }
}
