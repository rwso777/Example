using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClassLibrary.Manager;
using ClassLibrary.Models;

namespace LaceraWebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            EmployeeManager employeeManager = new EmployeeManager("C:\\projects\\lacera\\Data.txt");
            List<Employee> employeesList = employeeManager.GetEmployeesList();
            employeeManager.Dispose();
            return View(employeesList);
        }
    }
}