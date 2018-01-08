using MvcTreeView.Data;
using MvcTreeView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTreeView.Repository
{
    public interface IEmployeeData
    {
        List<Employee> getEmployees();
    }
    public class EmployeeRepository : IEmployeeData
    {
        public List<Employee> getEmployees()
        {
            List<Employee> lstEmployees = new List<Employee>();
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var query = context.EmpHierarchies.Select(x => x).ToList();
                foreach (var item in query)
                {
                    lstEmployees.Add(new Employee()
                    {
                        Id = item.ID,
                        Name = item.Name,
                        ManagerId = item.ManagerId

                    });
                }
                return lstEmployees;
                // return AutoMapper.Mapper.Map<List<Employee>>(context.EmpHierarchies.Select(x => x).ToList());
            }
        }
    }
}
