using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Employee
    {
        string id;
        string name;
        double basicSalary;
        double hra;
        double da;
        double grossSalary;
        public Employee(string id, string name, double basicSalary) {
            this.id = id;
            this.name = name;
            this.basicSalary = basicSalary;
            this.hra = 0.10 * this.basicSalary;
            this.da = 0.05 * this.basicSalary;
            this.grossSalary = this.basicSalary + this.hra + this.da;
        }
        public void DisplaySalarySlip()
        {
            Console.WriteLine($"Employee Id: {this.id}");
            Console.WriteLine($"Employee Name: {this.name}");
            Console.WriteLine($"Basic Salary: {this.basicSalary}");
            Console.WriteLine($"HRA: {this.hra}");
            Console.WriteLine($"DA: {this.da}");
            Console.WriteLine($"Gross: {this.grossSalary}");
        }
    }
}
