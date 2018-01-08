using MvcTreeView.Data;
using MvcTreeView.Models;
using MvcTreeView.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTreeView.Controllers
{
    public class EmpHierarchyController : Controller
    {
        
        // GET: EmpHierarchy
        public ActionResult Index()
        {
            IEmployeeData _iEmpData = new EmployeeRepository();
            var employeeList = _iEmpData.getEmployees();
            var president = employeeList.Where(x => x.ManagerId == null).FirstOrDefault();
            setChildren(president, employeeList);
            return View(president);
        }

        private void setChildren(Employee president, List<Employee> employeeList)
        {
            var childs = employeeList.Where(x => x.ManagerId == president.Id).ToList();
            if (childs.Count > 0)
            {
                foreach (var child in childs)
                {
                    setChildren(child, employeeList);
                    president.Employees.Add(child);
                }
            }
        }
    }
}