using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ClassLibrary.Models;

namespace ClassLibrary.Manager
{
    public class EmployeeManager : IDisposable
    {
        private readonly CSVFileParser csvFileParser;

        private CSVFileParser CSVFileParser { get { return this.csvFileParser; } }

        public EmployeeManager(string file)
        {
            if(string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                throw new Exception("File does not exist.");
            }

            csvFileParser = new CSVFileParser(file);
        }

        public List<Employee> GetEmployeesList()
        {
            List<List<string>> itemsList = csvFileParser.ParseFile();
            Employee employee;
            List<Employee> employeeList = new List<Employee>();

            int itemsIndex = 0;
            foreach(List<string> items in itemsList)
            {
                if (itemsIndex == 0)
                {
                    itemsIndex++;
                    continue;
                }

                itemsIndex++;

                int index = 0;
                employee = new Employee();
                foreach(string item in items)
                {
                    if (index == 0)
                    {
                        employee.Name = item;
                    }
                    else if(index == 1)
                    {
                        DateTime birthdate;
                        if(DateTime.TryParse(item, out birthdate))
                        {
                            employee.Birthdate = birthdate;
                            employee.IsValid = false;
                        }
                    }
                    else if(index == 2)
                    {
                        decimal salary;
                        if (decimal.TryParse(item, out salary))
                        {
                            employee.Salary = salary;
                            employee.IsValid = false;
                        }
                    }
                    else if(index == 3)
                    {
                        DateTime dateHired;
                        if (DateTime.TryParse(item, out dateHired))
                        {
                            employee.HiredDate = dateHired;
                            employee.IsValid = false;
                        }

                        employeeList.Add(employee);
                    }

                    index++;

                } // foreach List<string> items in itemsList

            } // foreach List<string> items in itemsList

            return employeeList;
        }

        public void Dispose()
        {
            CSVFileParser.Dispose();
        }
    }
}
