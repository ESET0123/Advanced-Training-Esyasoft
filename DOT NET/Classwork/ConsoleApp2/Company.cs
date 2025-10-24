using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Company
    {
        string employeeName; 
        string employeeId;
        static string companyName= "Esyasoft Technology";
        public Company(string employeeName, string employeeId)
        {
            this.employeeName = employeeName;
            this.employeeId = employeeId;
        }
        
        public static void DisplayCompanyName()
        {
            Console.WriteLine("Display Company Name: " + companyName);
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine("Employee Name: " + this.employeeName);
            Console.WriteLine("Employee Id: " + this.employeeId);
            Console.WriteLine("Company Name: " + companyName);
        }
    }
}
