using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClassLibrary.Manager;
using ClassLibrary.Models;

namespace LuceraTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestName()
        {
            EmployeeManager employeeManager = new EmployeeManager("C:\\projects\\lacera\\Data.txt");
            List<Employee> employeesList = employeeManager.GetEmployeesList();
            employeeManager.Dispose();

            if(employeesList[0].Name != "John Smith")
            {
                throw new Exception("Invalid Employee Name");
            }
        }

        [TestMethod]
        public void TestBirthDate()
        {
            EmployeeManager employeeManager = new EmployeeManager("C:\\projects\\lacera\\Data.txt");
            List<Employee> employeesList = employeeManager.GetEmployeesList();
            employeeManager.Dispose();

            if (employeesList[1].Birthdate != (new DateTime(1980, 3, 3)))
            {
                throw new Exception("Invalid Employee Birthdate");
            }
        }

        [TestMethod]
        public void TestSalary()
        {
            EmployeeManager employeeManager = new EmployeeManager("C:\\projects\\lacera\\Data.txt");
            List<Employee> employeesList = employeeManager.GetEmployeesList();
            employeeManager.Dispose();

            if (employeesList[2].Salary.HasValue)
            {
                throw new Exception("Should be an invalid Employee Salary");
            }
        }

        [TestMethod]
        public void TestHiredDate()
        {
            EmployeeManager employeeManager = new EmployeeManager("C:\\projects\\lacera\\Data.txt");
            List<Employee> employeesList = employeeManager.GetEmployeesList();
            employeeManager.Dispose();

            if (employeesList[4].HiredDate.HasValue)
            {
                throw new Exception("Invalid Employee Birthdate");
            }
        }
    }
}
