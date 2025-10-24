using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

//CS.2.002
//Weekly Consumption Basics
//Problem
//Given 7 daily kWh values for a meter, compute:
//Total, average
//Day index (1-based) of max usage
//Number of outage days (value == 0)
//Print all on one line.
//Guidance
//Use an int[] daily hardcoded.
//Use a for loop, if to count outages, track max and index.

namespace Basicstask
{
    internal class Meter2
    {
        int[] daily = { 4, 5, 6, 0, 7, 8, 5 };

        public void Summary()
        {
            int total=0, max = 0, day, outage = 0;
            double average;
            int index = 1;
            foreach (int item in daily)
            {
                total = total + item;
                if (item == 0)
                {
                    outage++;
                }
                if (item > max)
                {
                    max = item;
                    day = index;

                }
                index++;
            }
            average = total / daily.Length;
            Console.WriteLine($"Total: {total} kWh | Avg: {average:f2} kWh | Max: {max} kWh (Day 6) | Outages: {outage}");
        }
    }
}
