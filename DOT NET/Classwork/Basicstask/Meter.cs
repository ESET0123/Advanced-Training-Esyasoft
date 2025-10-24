using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CS.1.001
//Quick Bill from Two Readings
//Problem
//Write a console app that:
//Prompts for meterSerial (string), prevReading (int), currReading (int).
//Computes units = currReading - prevReading.
//If units ≤ 0, print an error.
//Else compute energyCharge = units * 6.5 and a tax = 5% and total = energyCharge + tax.
//Print a one-line bill summary.
//Guidance
//Use string, int, double.
//Use arithmetic operators and an if/else guard.
//Format to 2 decimals with ToString("F2").

namespace Basicstask
{
    internal class Meter
    {
        public string meterSerial { get; set; }
        public int prevReading { get; set; }
        public int currReading { get; set; }

        public void computeSummary () {
            int units = currReading - prevReading;
            if(units <= 0)
            {
                throw new ArgumentOutOfRangeException("Units cannot be negative.");
            }
            if(units > 500)
            {
                Console.WriteLine("High Consumption");
            }
            double energyCharge = units * 6.5;
            double tax = energyCharge * 0.05;
            double total = energyCharge + tax;

            Console.WriteLine($"Meter {meterSerial} | Units: {units} | Energy: Rs.{energyCharge:f2} | Tax(5%): Rs. {tax:f2} | Total: Rs. {total:f2}");
        }

    }
}
