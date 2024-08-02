using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Employee(string first, string last, string em, DateTime bd)
            :this(first,last,em,bd,0)
        {
        }

        public Employee(string first, string last, string em, DateTime bd, double rate)
        {
            firstName = first;
            lastName = last;
            email = em;
            birthday = bd;
            hourlyRate = rate;
            
        }

        public void PerformWork()
        {
            //numbersOfHoursWorked++;
            PerformWork(minimalHoursWorkedUnit);
            //Console.WriteLine($"{firstName} {lastName} has worked for {numbersOfHoursWorked} hour(s)!");
        }

        public void PerformWork(int numberOfHours)
        {
            numbersOfHoursWorked+=numberOfHours;
            Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHours} hour(s)!");
        }

        public double ReceiveWage(bool resetHours = true)
        {
            wage = numbersOfHoursWorked * hourlyRate;
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
