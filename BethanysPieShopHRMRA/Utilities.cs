using BethanysPieShopHRMRA.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRMRA
{
    internal class Utilities
    {
        private static string directory = @"E:\data\BethanysPieShopHRMRA\";
        private static string fileName = "employees.txt";

        internal static void CheckForExistingEmployeeFile()
        {
            string path = $"{directory}{fileName}";
            bool existingFileFound = File.Exists(path);

            if (existingFileFound) 
            {
                Console.WriteLine("An existing file with Employee data is found.");
            }
            else
            {
                if(!Directory.Exists(path)) 
                {
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Directory is ready for saving files.");
                    Console.ResetColor();
                }
            }
        }

        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.WriteLine("Creating an employee");

            Console.WriteLine("What type of employee do you want to register?");
            Console.WriteLine("1. Employee\n2. Manager\n3. Store manager\n4. Researcher\n5. Junior researcher");
            Console.Write("Your selection: ");
            string employeeType = Console.ReadLine();

            if(employeeType != "1" && employeeType != "2" && employeeType != "3" && employeeType != "4" && employeeType != "5") 
            { 
                Console.WriteLine("Invalid selection!");
                return;
            }

            Console.Write("Enter the first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            Console.Write("Enter the birth day: ");
            DateTime birthday = DateTime.Parse(Console.ReadLine()); //ex. 2/16/2008

            Console.Write("Enter the hourly rate: ");
            string hourlyRate = Console.ReadLine();
            double rate = double.Parse(hourlyRate); // we will assume here that input is in the correct format

            Employee employee = null;

            switch(employeeType)
            {
                case "1":
                    employee = new Employee(firstName, lastName, email, birthday, rate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, email, birthday, rate);
                    break;
                case "3":
                    employee = new StoreManager(firstName, lastName, email, birthday, rate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, email, birthday, rate);
                    break;
                case "5":
                    employee = new JuniorResearcher(firstName, lastName, email, birthday, rate);
                    break;
            }
            employees.Add(employee);
            Console.WriteLine("Employee created!");
        }

        internal static void ViewAllEmployees(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                e.DisplayEmployeeDetails();
            }
        }

        internal static void LoadEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            if (File.Exists(path))
            {
                employees.Clear();

                //now read the file
                string[] employeesAsString = File.ReadAllLines(path);
                for (int i = 0; i < employeesAsString.Length; i++)
                {
                    string[] employeeSplits = employeesAsString[i].Split(';');
                    string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);
                    string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1);
                    string email = employeeSplits[2].Substring(employeeSplits[2].IndexOf(':') + 1);
                    DateTime birthDay = DateTime.Parse(employeeSplits[3].Substring(employeeSplits[3].IndexOf(':') + 1));
                    double hourlyRate = double.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(':') + 1));
                    string employeeType = employeeSplits[5].Substring(employeeSplits[5].IndexOf(':') + 1);

                    Employee employee = null;

                    switch (employeeType)
                    {
                        case "1":
                            employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "2":
                            employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "3":
                            employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "4":
                            employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                        case "5":
                            employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                            break;
                    }


                    employees.Add(employee);

                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
                Console.ResetColor();
            }

        }

        internal static void SaveEmployees(List<Employee> employees) 
        {
            string path = $"{directory}{fileName}";
            StringBuilder sb = new StringBuilder();
            foreach (Employee e in employees)
            {
                string type = GetEmployeeType(e);
                sb.Append($"firstName: {e.FirstName};");
                sb.Append($"lastName: {e.LastName};");
                sb.Append($"email: {e.Email};");
                sb.Append($"birthDay: {e.Birthday.ToShortDateString()};");
                sb.Append($"hourlyRate: {e.HourlyRate};");
                sb.Append($"type: {type};");
                sb.Append(Environment.NewLine);
            }
            File.WriteAllText(path, sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved employees successfully");
            Console.ResetColor();
        }

        private static string GetEmployeeType(Employee employee)
        {
            if(employee is Manager)
            {
                return "2";
            }
            if (employee is StoreManager)
            {
                return "3";
            }
            if (employee is JuniorResearcher)
            {
                return "5";
            }
            if (employee is Researcher)
            {
                return "4";
            }
            if (employee is Employee)
            {
                return "1";
            }
            return "0";
        }
    }
}
