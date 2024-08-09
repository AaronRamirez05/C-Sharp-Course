using BethanysPieShopHRM.Logic;
using Newtonsoft.Json;
using System.Text;

namespace BethanysPieShopHRMRA.HR
{
    internal class Employee
    {

        public string firstName;
        public string lastName;
        public string email;

        public int numbersOfHoursWorked;
        public double wage;
        public double? hourlyRate;

        public DateTime birthday;

        const int minimalHoursWorkedUnit = 1;

        public EmployeeType employeeType;

        public static double taxRate = 0.15;

        public Employee(string first, string last, string em, DateTime bd)
            : this(first, last, em, bd, 0, EmployeeType.StoreManager)
        {
        }

        public Employee(string first, string last, string em, DateTime bd, double? rate, EmployeeType empType)
        {
            firstName = first;
            lastName = last;
            email = em;
            birthday = bd;
            hourlyRate = rate ?? 10;
            employeeType = empType;
        }

        public void PerformWork()
        {
            PerformWork(minimalHoursWorkedUnit);
        }

        public void PerformWork(int numberOfHours)
        {
            numbersOfHoursWorked += numberOfHours;
            Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHours} hour(s)!");
        }

        public int CalculateBonus(int bonus)
        {
            if (numbersOfHoursWorked > 10)
                bonus *= 2;
            Console.WriteLine($"The employee got a bonus of {bonus}");
            return bonus;
        }

        public int CalculateBonusAndBonusTax(int bonus, out int bonusTax)
        {
            bonusTax = 0;
            if (numbersOfHoursWorked > 10)
                bonus *= 2;
            if (bonus >= 200)
            {
                bonusTax = bonus / 10;
                bonus -= bonusTax;
            }

            Console.WriteLine($"The employee got a bonus of {bonus} and the tax on the bonus is {bonusTax}");
            return bonus;
        }

        public double CalculateWage()
        {
            WageCalculations wageCalculations = new WageCalculations();
            double calculatedValue = wageCalculations.ComplexWageCalculation(wage, taxRate, 3, 42);
            return calculatedValue;
        }

        public string ConvertToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = 0.0;
            if (employeeType == EmployeeType.Manager)
            {
                Console.WriteLine($"An extra was added to the wage since {firstName} is a manager!");
                wageBeforeTax = numbersOfHoursWorked * hourlyRate.Value * 1.25;
            }
            else
            {
                wageBeforeTax = numbersOfHoursWorked * hourlyRate.Value;
            }

            double taxAmount = wageBeforeTax * taxRate;
            wage = wageBeforeTax - taxAmount;

            Console.WriteLine($"{firstName} {lastName} has recieved a wage of {wage} for {numbersOfHoursWorked} hour(s) of work.");
            if (resetHours)
                numbersOfHoursWorked = 0;
            return wage;
        }

        public static void DisplayTaxRate()
        {
            Console.WriteLine($"The current tax rate is {taxRate}");
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t{lastName}\n" +
                $"Email: \t\t{email}\nBirthday: \t{birthday.ToShortDateString()}\nTax rate: \t{taxRate}");
      
        }
    }
}
