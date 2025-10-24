using D4Tasks_LINQ;

var employees = new List<Employee>
{
    new Employee{ Id=1, Name="Ravi", Department="IT", Salary=85000, Experience=5, Location="Bangalore"},
    new Employee{ Id=2, Name="Priya", Department="HR", Salary=52000, Experience=4, Location="Pune"},
    new Employee{ Id=3, Name="Kiran", Department="Finance", Salary=73000, Experience=6, Location="Hyderabad"},
    new Employee{ Id=4, Name="Asha", Department="IT", Salary=95000, Experience=8, Location="Bangalore"},
    new Employee{ Id=5, Name="Vijay", Department="Marketing", Salary=68000, Experience=5, Location="Mumbai"},
    new Employee{ Id=6, Name="Deepa", Department="HR", Salary=61000, Experience=7, Location="Delhi"},
    new Employee{ Id=7, Name="Arjun", Department="Finance", Salary=82000, Experience=9, Location="Bangalore"},
    new Employee{ Id=8, Name="Sneha", Department="IT", Salary=78000, Experience=4, Location="Pune"},
    new Employee{ Id=9, Name="Rohit", Department="Marketing", Salary=90000, Experience=10, Location="Delhi"},
    new Employee{ Id=10, Name="Meena", Department="Finance", Salary=66000, Experience=3, Location="Mumbai"}
};

//Tasks:
//Employee Tasks
//1.Display all employees working in the IT department.
Console.WriteLine("----------------------------------------------------Employee");
Console.WriteLine("--------------1.Display all employees working in the IT department.");

var allEmployees1 = employees.Where(n => n.Department == "IT");
foreach (var item in allEmployees1)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("--------------2.List names and salaries of employees who earn more than 70,000.");
//2.List names and salaries of employees who earn more than 70,000.
var allEmployees2 = employees.Where(n => n.Salary > 7000);
foreach (var item in allEmployees2)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("---------------3.Find all employees located in Bangalore.");

//3.Find all employees located in Bangalore.
var allEmployees3 = employees.Where(n => n.Location == "Bangalore");
foreach (var item in allEmployees3)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("--------------4.Display employees having more than 5 years of experience.");

//4.Display employees having more than 5 years of experience.
var allEmployees6 = employees.Where(n => n.Experience > 5);
foreach (var item in allEmployees6)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("--------------5.Show names of employees and their salaries in ascending order of salary.");

//5.Show names of employees and their salaries in ascending order of salary.
var allEmployees7 = employees.OrderBy(n => n.Salary);
foreach (var item in allEmployees7)
{
    Console.WriteLine($"{item.Name}---{item.Salary}");
}
Console.WriteLine("--------------6.Group employees by location and count how many employees are in each location.");
//6.Group employees by location and count how many employees are in each location.
var groupemployees = employees
           .GroupBy(n => n.Location)
           .Select(group => new
           {
               Customer = group.Key,
               totalCount = group.Count()
           });
foreach (var city in groupemployees)
{
    Console.WriteLine($"-------City: {city.Customer}");
    Console.WriteLine($"-----Average: {city.totalCount}");
}
Console.WriteLine("-----------------7.Display employees whose salary is above the average salary");

//7.Display employees whose salary is above the average salary.
var avgSalary = employees.Average(n => n.Salary);
var groupEmployees = employees.Where (n => n.Salary > avgSalary);
foreach (var item in groupEmployees)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("------------------8.Show top 3 highest-paid employees.");

//8.Show top 3 highest-paid employees.
var allEmployees8 = employees.OrderByDescending(n => n.Salary)
                            .Take(3);
foreach (var item in allEmployees8)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("-----------------------------------------------------");




var products = new List<Product>
{
    new Product{ Id=1, Name="Laptop", Category="Electronics", Price=75000, Stock=15 },
    new Product{ Id=2, Name="Smartphone", Category="Electronics", Price=55000, Stock=25 },
    new Product{ Id=3, Name="Tablet", Category="Electronics", Price=30000, Stock=10 },
    new Product{ Id=4, Name="Headphones", Category="Accessories", Price=2000, Stock=100 },
    new Product{ Id=5, Name="Shirt", Category="Fashion", Price=1500, Stock=50 },
    new Product{ Id=6, Name="Jeans", Category="Fashion", Price=2200, Stock=30 },
    new Product{ Id=7, Name="Shoes", Category="Fashion", Price=3500, Stock=20 },
    new Product{ Id=8, Name="Refrigerator", Category="Appliances", Price=45000, Stock=8 },
    new Product{ Id=9, Name="Washing Machine", Category="Appliances", Price=38000, Stock=6 },
    new Product{ Id=10, Name="Microwave", Category="Appliances", Price=12000, Stock=12 }
};

//Product Tasks
Console.WriteLine("----------------------------------------------------Product");
Console.WriteLine("---------------1.Display all products with stock less than 201");

//1.Display all products with stock less than 20.
var allProducts1 = products.Where(n => n.Stock < 20);
foreach (var item in allProducts1)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("---------------2. Show all products belonging to the “Fashion” category.");
//2. Show all products belonging to the “Fashion” category.
var allProducts2 = products.Where(n => n.Category == "Fashion");
foreach (var item in allProducts2)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("---------------3. Display product names and prices where price is greater than 10,000.");
//3. Display product names and prices where price is greater than 10,000.
var allProducts3 = products.Where(n => n.Price > 10000);
foreach (var item in allProducts3)
{
    Console.WriteLine($"{item.Name}--- Rs.{item.Price}");
}
Console.WriteLine("----------------4. List all product names sorted by price (descending).");
//4. List all product names sorted by price (descending).
var allProducts4 = products.OrderByDescending(n => n.Price);
foreach (var item in allProducts4)
{
    Console.WriteLine($"{item.Name}---{item.Price}");
}
Console.WriteLine("----------------5.Find the most expensive product in each category.");
//5.Find the most expensive product in each category.
var allProducts5 = products.GroupBy(n => n.Category)
                            .Select(group => new
                            {
                                Category=group.Key,
                                MostExpensiveProduct = group.OrderByDescending(s => s.Price).First()
                            });
foreach (var item in allProducts5)
{
    Console.WriteLine($"{item.Category}---{item.MostExpensiveProduct}");
}

Console.WriteLine("-------------------6.Show total stock per category.");

//6.Show total stock per category.
var allProducts6 = products.GroupBy(n => n.Category)
                            .Select(group => new
                            {
                                Category = group.Key,
                                CountProduct = group.Count(),
                            });
foreach (var item in allProducts6)
{
    Console.WriteLine($"{item.Category}---{item.CountProduct}");
}
Console.WriteLine("---------------------7.Display products whose name starts with ‘S’.");

//7.Display products whose name starts with ‘S’.
var allProducts7 = products.Where(n => n.Name.StartsWith("S"));
foreach (var item in allProducts7)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("----------------------8.Show average price of products in each category.");

//8.Show average price of products in each category.
var allProducts8 = products.GroupBy(n => n.Category)
                            .Select(group => new
                            {
                                Category = group.Key,
                                avgPrice = group.Average(s => s.Price),
                            });
foreach (var item in allProducts8)
{
    Console.WriteLine($"{item.Category}---{item.avgPrice:F2}");
}
Console.WriteLine("-----------------------------------------------------");



var students = new List<Student>
{
    new Student{ Id=1, Name="Asha", Course="C#", Marks=92, City="Bangalore"},
    new Student{ Id=2, Name="Ravi", Course="Java", Marks=85, City="Pune"},
    new Student{ Id=3, Name="Sneha", Course="Python", Marks=78, City="Hyderabad"},
    new Student{ Id=4, Name="Kiran", Course="C#", Marks=88, City="Delhi"},
    new Student{ Id=5, Name="Meena", Course="Python", Marks=95, City="Bangalore"},
    new Student{ Id=6, Name="Vijay", Course="C#", Marks=82, City="Chennai"},
    new Student{ Id=7, Name="Deepa", Course="Java", Marks=91, City="Mumbai"},
    new Student{ Id=8, Name="Arjun", Course="Python", Marks=89, City="Hyderabad"},
    new Student{ Id=9, Name="Priya", Course="C#", Marks=97, City="Pune"},
    new Student{ Id=10, Name="Rohit", Course="Java", Marks=74, City="Delhi"}
};

//Student Tasks
Console.WriteLine("----------------------------------------------------Student");
Console.WriteLine("---------------1.Find the highest scorer in each course.");
//1.Find the highest scorer in each course.
var maxScore = students.Max(n => n.Marks);
var maxScorer = students.Where(n => n.Marks == maxScore).First();
Console.WriteLine($"{maxScorer.Name}---{maxScore}");
Console.WriteLine("---------------2.Display average marks of all students city-wise.");
//2.Display average marks of all students city-wise.
var cityAverages = students
            .GroupBy(n => n.City)
            .Select(group => new
            {
                City = group.Key,
                AverageMarks = group.Average(s => s.Marks)
            });
foreach (var city in cityAverages)
{
    Console.WriteLine($"-------City: {city.City}");
    Console.WriteLine($"-----Average: {city.AverageMarks}");
}
Console.WriteLine("-----------------3.Display names and marks of students ranked by marks.");
//3.Display names and marks of students ranked by marks.
var allStudents = students.OrderByDescending(n => n.Marks);
foreach (var item in allStudents)
{
    Console.WriteLine($"{item.Name}---{item.Marks}");
}
Console.WriteLine("----------------------------------------------------");


var orders = new List<Order>
{
    new Order{ OrderId=1001, CustomerId=1, Amount=2500, OrderDate=new DateTime(2025,5,12)},
    new Order{ OrderId=1002, CustomerId=2, Amount=1800, OrderDate=new DateTime(2025,5,13)},
    new Order{ OrderId=1003, CustomerId=1, Amount=4500, OrderDate=new DateTime(2025,5,20)},
    new Order{ OrderId=1004, CustomerId=3, Amount=6700, OrderDate=new DateTime(2025,6,01)},
    new Order{ OrderId=1005, CustomerId=4, Amount=2500, OrderDate=new DateTime(2025,6,02)},
    new Order{ OrderId=1006, CustomerId=2, Amount=5600, OrderDate=new DateTime(2025,6,10)},
    new Order{ OrderId=1007, CustomerId=5, Amount=3100, OrderDate=new DateTime(2025,6,12)},
    new Order{ OrderId=1008, CustomerId=3, Amount=7100, OrderDate=new DateTime(2025,7,01)},
    new Order{ OrderId=1009, CustomerId=4, Amount=4200, OrderDate=new DateTime(2025,7,05)},
    new Order{ OrderId=1010, CustomerId=5, Amount=2900, OrderDate=new DateTime(2025,7,10)}
};

//Order Tasks
Console.WriteLine("--------------------------------------------------Order");
Console.WriteLine("-------------------1.Find total order amount per month.");
//1.Find total order amount per month.
var totalOrders = orders
            .GroupBy(n => n.OrderDate.Month)
            .Select(group => new
            {
                Month = group.Key,
                totalOrder = group.Sum(s => s.Amount)
            });
foreach (var item in totalOrders)
{
    Console.WriteLine($"-------Month: {item.Month}");
    Console.WriteLine($"-----Total Order: {item.totalOrder}");
}
Console.WriteLine("--------------------2.Show the customer who spent the most in total.");
//2.Show the customer who spent the most in total.
var groupOrder1 = orders
            .GroupBy(n => n.CustomerId)
            .Select(group => new
            {
                Customer = group.Key,
                totalOrder = group.Sum(s => s.Amount)
            });
var maxSpent = groupOrder1.Max(n => n.totalOrder);
var maxCustomer = groupOrder1.Where(n => n.totalOrder == maxSpent);
foreach (var item in maxCustomer)
{
    Console.WriteLine($"Customer Id: {item.Customer}--- {maxSpent}");
}
Console.WriteLine("--------------------3.Display orders grouped by customer and show total amount spent.");

//3.Display orders grouped by customer and show total amount spent.
var groupOrder2 = orders
            .GroupBy(n => n.CustomerId)
            .Select(group => new
            {
                Customer = group.Key,
                totalOrder = group.Sum(s => s.Amount)
            });
foreach (var item in groupOrder2)
{
    Console.WriteLine($"{item.Customer}---{item.totalOrder}");
}
Console.WriteLine("--------------4.Display the top 2 orders with the highest amount.");

//4.Display the top 2 orders with the highest amount.
var order1 = orders.OrderByDescending(n => n.Amount)
                    .Take(2);
foreach(var item in order1)
{
    Console.WriteLine($"Order Id: {item.OrderId}---Rs.{item.Amount}");
}
Console.WriteLine("----------------------------------------------------");
