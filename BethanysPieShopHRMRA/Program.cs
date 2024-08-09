
using BethanysPieShopHRMRA.Accounting;
using BethanysPieShopHRMRA.HR;
using System.Runtime.Serialization.Formatters;
using System.Text;

Console.WriteLine("creating an employee");
Console.WriteLine("---------------------\n");

Employee bethany = new Employee("bethany", "smith", "bethany@snowball.be", new DateTime
    (1979, 1, 16), 25, EmployeeType.Manager);

Console.WriteLine("creating an employee");
Console.WriteLine("---------------------\n");

Employee george = new Employee("George", "smith", "george@snowball.be", new DateTime
    (1984, 3, 28), 30, EmployeeType.Research);


#region First Run Bethany
bethany.PerformWork();
bethany.PerformWork(5);
bethany.PerformWork();
bethany.ReceiveWage();
bethany.DisplayEmployeeDetails();
#endregion
#region First run George
george.PerformWork(10);
george.PerformWork();
george.PerformWork();
george.ReceiveWage();
george.DisplayEmployeeDetails();
#endregion

Employee.taxRate = 0.02;
Employee.DisplayTaxRate();

#region Second Run Bethany
bethany.PerformWork();
bethany.PerformWork(5);
bethany.PerformWork();
bethany.ReceiveWage();
bethany.DisplayEmployeeDetails();
#endregion
#region Second run George
george.PerformWork(10);
george.PerformWork();
george.PerformWork();
george.ReceiveWage();
george.DisplayEmployeeDetails();
#endregion

Employee.DisplayTaxRate();

double calculatedWage = bethany.CalculateWage();
Console.WriteLine($"The estimated wage is {calculatedWage}.");

Account account = new Account("123456789");
