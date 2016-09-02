using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary.Manager;
using ClassLibrary.Models;

namespace LaceraConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager("C:\\projects\\lacera\\Data.txt");
            List<Employee> employeeList = employeeManager.GetEmployeesList();
            employeeManager.Dispose();

            Console.Write("Name Birthdate Salary Hire Date");

            foreach(Employee employee in employeeList)
            {
                Console.Write(employee.Name);
                Console.Write(" ");
                if (employee.Birthdate.HasValue)
                {
                    Console.Write(employee.Birthdate.Value.Day);
                    Console.Write("\\");
                    Console.Write(employee.Birthdate.Value.Month);
                    Console.Write("\\");
                    Console.Write(employee.Birthdate.Value.Year);
                }
                else
                {
                    Console.Write("Invalid Birthdate");
                }
                Console.Write(" ");

                if (employee.Salary.HasValue)
                {
                    Console.Write("$" + employee.Salary);
                }
                else
                {
                    Console.Write("Invalid Salary");
                }
                Console.Write(" ");

                if (employee.HiredDate.HasValue)
                {
                    Console.Write(employee.HiredDate.Value.Day);
                    Console.Write("\\");
                    Console.Write(employee.HiredDate.Value.Month);
                    Console.Write("\\");
                    Console.Write(employee.HiredDate.Value.Year);
                }
                else
                {
                    Console.Write("Invalid Hired Date");
                }

            Console.WriteLine("");
        }

            Console.ReadLine();
        }
    }
}
