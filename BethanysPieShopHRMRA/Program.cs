using BethanysPieShopHRMRA;
using System.Runtime.Serialization.Formatters;
using System.Text;

Employee bethany = new Employee("bethany", "smith", "bethany@snowball.be", new DateTime
    (1979, 1, 16), 25, EmployeeType.Manager);

Console.WriteLine("creating an employee");
Console.WriteLine("---------------------\n");

bethany.DisplayEmployeeDetails();
bethany.PerformWork();
bethany.PerformWork();
bethany.PerformWork(5);
bethany.PerformWork();
double receivedWageBethany = bethany.ReceiveWage(true);
Console.WriteLine($"Wage paid (message from Program): {receivedWageBethany}");

Employee george = new Employee("George", "smith", "george@snowball.be", new DateTime
    (1984, 3, 28), 30, EmployeeType.Research);

Console.WriteLine("creating an employee");
Console.WriteLine("---------------------\n");

george.DisplayEmployeeDetails();
george.PerformWork();
george.PerformWork();
george.PerformWork(3);
george.PerformWork();
george.PerformWork(8);
var recievedWageGeorge = george.ReceiveWage(true);

WorkTask task;
task.description = "Bake delicious pies";
task.hours = 3;
task.PerformWorkTask();