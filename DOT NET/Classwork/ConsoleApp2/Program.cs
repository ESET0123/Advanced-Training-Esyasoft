using System.Collections.Concurrent;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            humans h1 = new humans("Rishav", 28);
            Console.WriteLine("Age: " + h1.age);
            h1.eat();
            h1.sleep();

            Book b1 = new Book("JJK", "Redemption", "Gege");
            b1.IssueBook();
            b1.DisplayBookDetails();

            Movie m1 = new Movie("Kantara: The Legend", 1000, 200);
            m1.BookSeats(5);
            m1.CancelSeats(2);
            m1.DisplayAvailableSeats();

            Company c1 = new Company("Rishav Shah", "rs123");
            c1.DisplayEmployeeDetails();
            Company c2 = new Company("Punit Pandey", "pp323");
            c2.DisplayEmployeeDetails();
            Company.DisplayCompanyName();

            Employee e1 = new Employee("rs123", "Rishav Shah", 98600.0);
            e1.DisplaySalarySlip();
            Employee e2 = new Employee("sr653", "Shreyansh Ray", 215600.0);
            e2.DisplaySalarySlip();

        }
    }
}
