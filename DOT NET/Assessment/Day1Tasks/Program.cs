using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day1Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Task 1 – Student Marks Calculator - Description:
            ////Write a C# program that stores a student’s name and marks for 5 subjects using variables.
            ////Then calculate and display:
            ////Total marks
            ////Average marks
            ////Percentage
            //Console.WriteLine("ENTER YOUR NAME");
            //string name = Console.ReadLine();
            //double[] marks = new double[5];

            //double sum = 0;

            //Console.WriteLine("ENTER YOUR Subject marks");
            //for (int i = 0; i < marks.Length; i++)
            //{
            //    Console.Write($"Subject {i + 1} marks: ");
            //    marks[i] = Convert.ToDouble(Console.ReadLine());
            //    sum += marks[i];
            //}
            //Console.WriteLine($"Total marks: {sum}");
            //Console.WriteLine($"Average marks: {sum / marks.Length}");
            //Console.WriteLine($"Percentage marks: {(sum / (marks.Length * 100)) * 100}%");

            ////Task 2 - Simple Salary Computation - Description:
            ////Create a program to calculate the net salary of an employee using variables.
            ////Steps:
            ////Declare variables for:
            ////Basic salary
            ////HRA (20% of basic)
            ////DA (10% of basic)
            ////Tax (8% of gross)
            ////Use formulas: gross = basic + HRA + DA
            ////netSalary = gross - tax
            ////Display all values with proper labels.
            //Console.WriteLine("Enter your basic salary");
            //double basic_salary = Convert.ToDouble(Console.ReadLine());
            //double HRA = basic_salary * 0.20;
            //double DA = basic_salary * 0.10;
            //double TAX = basic_salary * 0.08;
            //double gross = basic_salary + HRA + DA;
            //double netSalary = gross - TAX;
            //Console.WriteLine($"Basic Salary: {basic_salary}");
            //Console.WriteLine($"HRA: {HRA}");
            //Console.WriteLine($"DA: {DA}");
            //Console.WriteLine($"TAX: {TAX}");
            //Console.WriteLine($"GROSS: {gross}");
            //Console.WriteLine($"Net Salary: {netSalary}");

            ////Task 3 – Currency Converter - Description:
            ////Write a program to convert an amount in INR (Indian Rupees) to USD and EUR using given rates.
            ////Steps:
            ////Declare a double inr and two conversion rates (1 USD = 83.0 INR, 1 EUR = 90.5 INR).
            ////Calculate: usd = inr / 83.0
            ////eur = inr / 90.5
            ////Display the results rounded to two decimals.
            //Console.WriteLine("Enter your amount in INR");
            //double amount = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine($"amount in INR: {amount}");
            //Console.WriteLine($"amount in USD: {Math.Round(amount / 83.0,2)}");
            //Console.WriteLine($"amount in EUR: {Math.Round(amount / 90.5, 2)}");

            ////Task 4 – Time Converter - Description:
            ////Convert a given time in minutes into hours and minutes using integer variables.
            ////Steps:
            ////        Input: total minutes(e.g., 130)
            ////Calculate hours and remaining minutes:
            ////            hours = totalMinutes / 60
            ////minutes = totalminutes % 60
            ////Print result.
            //Console.WriteLine("Enter time in minutes");
            //int totalMinutes = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"Time Only in Hrs and mins: {totalMinutes / 60} hrs. {totalMinutes % 60} mins");

            ////-------------------------------------------------------------------------------------------------------------------

            ////Task 1:Print a table of squares and cubes for numbers 1 to 10.
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine($"i: {i}  Square: {i*i}   Cube: {i*i*i}");
            //}

            ////Task2: Find all “perfect numbers” between 1 and 1000(numbers equal to the sum of their proper divisors).
            //Console.WriteLine("Perfect Numbers");
            //for (int number = 1; number <= 1000; number++)
            //{
            //    int sumOfDivisors = 0;
            //    for (int i = 1; i <= number / 2; i++)
            //    {
            //        if (number % i == 0)
            //        {
            //            sumOfDivisors += i;
            //        }
            //    }
            //    if (sumOfDivisors == number)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}

            ////Task 3:Print this pattern :
            ////*****
            //// ***
            ////  *
            //// ***
            ////*****
            //int rows = 3;

            //for (int i = rows; i >= 1; i--)
            //{
            //    for (int j = 1; j <= rows - i; j++)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int k = 1; k <= (2 * i) - 1; k++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}
            //for (int i = 2; i <= rows; i++)
            //{
            //    for (int j = 1; j <= rows - i; j++)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int k = 1; k <= (2 * i) - 1; k++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            ////Task 4:Print this pattern :
            ////    1
            ////   121
            ////  12321
            //// 1234321
            ////123454321
            //for (int i = 1; i <= 5; i++)
            //{
            //    int j;
            //    for (int k = 1; j <= i; j++)
            //    {
            //        Console.Write(j);
            //    }
            //    for (j = 1; j <= i; j++)
            //    {
            //        Console.Write(j);
            //    }
            //    for (j = j - 2; j > 0; j--)
            //    {
            //        Console.Write(j);
            //    }
            //    Console.WriteLine();
            //}

            ////Task 5:Triangle with alternate numbers:
            ////1
            ////0 1
            ////1 0 1
            ////0 1 0 1
            ////1 0 1 0 1

            //int num1 = 0;

            //for (int i = 1; i <= 5; i++)
            //{
            //    int num = 1 - num1;
            //    num1 = num;
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write(num +" ");
            //        num = 1 - num;
            //    }
            //    Console.WriteLine();
            //}

            ////Task 6:Display all Armstrong numbers between 100 and 999.(Armstrong number⇒sum of cube of each digit = original number)
            //Console.WriteLine("Armstrong Numbers");
            //for (int i = 100; i <= 999; i++)
            //{
            //    int originalNumber = i;
            //    int sumOfCubes = 0;
            //    int tempNumber = i;

            //    while (tempNumber > 0)
            //    {
            //        int digit = tempNumber % 10; 
            //        sumOfCubes += (int)Math.Pow(digit, 3); 
            //        tempNumber /= 10; 
            //    }

            //    if (sumOfCubes == originalNumber)
            //    {
            //        Console.WriteLine(originalNumber);
            //    }
            //}

            ////Task 7:Print Fibonacci series in reverse order
            //int n = 10;

            //List<int> fibonacciSeries = new List<int>();

            //if (n >= 1)
            //{
            //    fibonacciSeries.Add(0);
            //}
            //if (n >= 2)
            //{
            //    fibonacciSeries.Add(1);
            //}

            //for (int i = 2; i < n; i++)
            //{
            //    int nextFib = fibonacciSeries[i - 1] + fibonacciSeries[i - 2];
            //    fibonacciSeries.Add(nextFib);
            //}

            //Console.WriteLine($"Fibonacci series (first {n} terms) in reverse order:");
            //for (int i = fibonacciSeries.Count - 1; i >= 0; i--)
            //{
            //    Console.Write(fibonacciSeries[i] + " ");
            //}

            ////Task 8: Zigzag star pattern(height = 4)
            ////     *      *
            ////    * *    * *
            ////   *   *  *   *
            ////  *     **     *
            

            ////Task 9: Count the total digits in a number using a loop.
            //int num = 5415610;
            //int count_digits = 0;
            //while (num > 10)
            //{
            //    num = num / 10;
            //    count_digits++;
            //}
            //count_digits++;
            //Console.WriteLine("Number: " + num);
            //Console.WriteLine("Total digits: " + count_digits);

            ////Task 10: Diamond pattern with numbers
            ////        1
            ////       121
            ////      12321
            ////     1234321
            ////    123454321
            ////     1234321
            ////      12321
            ////       121
            ////        1
            //int num2 = 5;
            //for (int i = 1; i <= num2; i++)
            //{
            //    for (int j = 1; j <= num2 - i; j++)
            //    {
            //        Console.Write(" ");
            //    }
            //    int k;
            //    for (k = 1; k <= i; k++)
            //    {
            //        Console.Write(k);
            //    }
            //    for (k = k - 2; k > 0; k--)
            //    {
            //        Console.Write(k);
            //    }
            //    Console.WriteLine();
            //}
            //for (int i = num2 - 1; i > 0; i--)
            //{
            //    for (int j = 1; j <= num2 - i; j++)
            //    {
            //        Console.Write(" ");
            //    }
            //    int k;
            //    for (k = 1; k <= i; k++)
            //    {
            //        Console.Write(k);
            //    }
            //    for (k = k - 2; k > 0; k--)
            //    {
            //        Console.Write(k);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
