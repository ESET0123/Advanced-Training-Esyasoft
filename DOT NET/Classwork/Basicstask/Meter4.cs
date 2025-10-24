using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

//CS.3.004
//Multi-Meter Weekly Health Report
//Problem
//For 3 meters, each with 7 daily kWh entries:
//For each meter:
//Total & average
//PeakAlert if any day > 8 kWh
//SustainedOutage if there are two consecutive zero-days
//Across all meters, find the single highest day usage (value + which meter + day)
//Guidance
//Use int[][] meters as a jagged array.
//Outer loop over meters, inner over days.
//Use flags for alerts; track per-meter max and global max (with meter/day indexes).

namespace Basicstask
{
    internal class Meter4
    {
        int[][] meters = new int[][]  {
        new[] { 4, 5, 0, 0, 6, 7, 3 }, // A    
        new[] { 2, 2, 2, 2, 2, 2, 2 }, // B    
        new[] { 9, 1, 1, 1, 1, 1, 1 }  // C  
};
        string[] ids = { "A-1001", "B-2001", "C-3001" };

        public void Summary()
        {
            int[] meterdata;
            foreach (int[] data in meters)
            {
                var total=0;
                double avg;
                bool peakalert=false, sustainedoutage=false;
                for(int i=0;i<data.Length; i++)
                {
                    total += data[i];
                    if (data[i] == 0 && i > 0 && data[i - 1] == 0)
                    {
                        sustainedoutage = true;
                    }
                    if (data[i] >8)
                    {
                        peakalert = true;
                    }
                }
                Console.WriteLine($"A - 1001: Total 25, Avg 3.57, PeakAlert False, SustainedOutage True(days 3–4)");

            }
            
                //A - 1001: Total 25, Avg 3.57, PeakAlert False, SustainedOutage True(days 3–4)

        }
    }
}
