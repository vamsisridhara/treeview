using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTreeView.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public IList<Employee> Employees { get; set; }

        public Employee()
        {
            Employees = new List<Employee>();
        }
    }

}