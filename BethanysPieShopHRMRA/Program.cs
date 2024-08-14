
using BethanysPieShopHRMRA.Accounting;
using BethanysPieShopHRMRA.HR;
using System.Runtime.Serialization.Formatters;
using System.Text;

IEmployee bethany = new StoreManager("Bethany", "Smith", "bethany@snowball.be", new DateTime
    (1979, 1, 16), 25);

Console.Write("How many hours do we need to register for Bethany?");
int numberOfHours = 0;
string input  = Console.ReadLine();
numberOfHours = int.Parse(input);

bethany.DisplayEmployeeDetails();
bethany.PerformWork();
bethany.PerformWork(numberOfHours);
