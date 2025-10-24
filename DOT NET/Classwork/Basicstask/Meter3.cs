using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CS.2.003
//Parse Load Profile Lines (No Files)
//Problem
//You’re given 7 CSV-like lines: yyyy - MM - dd,kWh, status where status is OK / OUTAGE / TAMPER.Compute:
//Sum of kWh where status == OK
//Count of OUTAGE days
//Count of TAMPER days
//Average kWh across only OK days
//Guidance
//Use string[] lines.
//For each line: Split(','), double.Parse, if/else if.
//Keep okCount to compute average.

namespace Basicstask
{
    internal class Meter3
    {
        string[] lines = { "2025-09-01,4.2,OK", "2025-09-02,5.0,OK", "2025-09-03,0.0,OUTAGE", "2025-09-04,3.8,OK", "2025-09-05,6.1,OK", "2025-09-06,2.5,TAMPER", "2025-09-07,5.4,OK" };
        
        public void Summary()
        {
            double sum=0, kwh, average;
            int outage=0, tamper=0, count=0;
            foreach (string item in lines)
            {
                string [] data = item.Split(',');
                string date = data[0];
                double unit = double.Parse(data[1]);
                string status = data[2];
                if(status == "OK")
                {
                    sum += unit;
                    count++;
                }
                else if(status == "OUTAGE")
                {
                    outage++;
                }
                else if(status == "TAMPER")
                {
                    tamper++;
                }
            }
            average = sum / count;
            Console.WriteLine($"OK: {sum} kWh (avg {average:f2}) | OUTAGE: {outage} | TAMPER: {tamper}");
        }
    }
}
