using Newtonsoft.Json;
using System.Text;

namespace BethanysPieShopHRMRA
{
    internal class Employee
    {
        public string firstName;
        public string lastName;
        public string email;

        public int numbersOfHoursWorked;
        public double wage;
        public double hourlyRate;

        public DateTime birthday;

        const int minimalHoursWorkedUnit = 1;

        public EmployeeType employeeType;

        public Employee(string first, string last, string em, DateTime bd)
            :this(first,last,em,bd,0, EmployeeType.StoreManager)
        {
        }

        public Employee(string first, string last, string em, DateTime bd, double rate, EmployeeType empType)
        {
            firstName = first;
            lastName = last;
            email = em;
            birthday = bd;
            hourlyRate = rate;
            employeeType = empType;
        }

        public void PerformWork()
        {
            PerformWork(minimalHoursWorkedUnit);
        }

        public void PerformWork(int numberOfHours)
        {
            numbersOfHoursWorked+=numberOfHours;
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
        public string ConvertToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public double ReceiveWage(bool resetHours = true)
        {
            if(employeeType == EmployeeType.Manager)
            {
                Console.WriteLine($"An extra was added to the wage since {firstName} is a manager!");
                wage = numbersOfHoursWorked * hourlyRate * 1.25;
            }
            else
            {
                wage = numbersOfHoursWorked * hourlyRate;
            }
            Console.WriteLine($"{firstName} {lastName} has recieved a wage of {wage} for {numbersOfHoursWorked} hour(s) of work.");
            if (resetHours)
                numbersOfHoursWorked = 0;
            return wage;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t{lastName}\n" +
                $"Email: \t\t{email}\nBirthday: \t{birthday.ToShortDateString()}\n");
        }
    }
}
