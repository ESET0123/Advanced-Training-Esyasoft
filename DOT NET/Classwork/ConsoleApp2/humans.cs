using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class humans
    {
        public string name;
        public int age;

        public humans(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void eat()
        {
            Console.WriteLine(name + " is eating");
        }
        public void sleep()
        {
            Console.WriteLine(name + " is sleeping");
        }
    }
}
