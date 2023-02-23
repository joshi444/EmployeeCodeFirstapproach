using System.Collections.Generic;
using EmployeeEFCoreCodeFirstApp.Models;
using System.Linq;
using System.Security.Cryptography;
namespace EmployeeEFCoreCodeFirstApp.Repositories
{
    public class TestEmployeeRepo:IEmployeeRepo
    {
        EmployeeContext context;
        public TestEmployeeRepo(EmployeeContext employeeContext)
        {
            context = employeeContext;
        }
        public void AddNewEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }
        public void UpdateEmployee(Employee newemployee)
        {
            Employee employee = context.Employees.FirstOrDefault(d =>
            d.EmployeeId == newemployee.EmployeeId);
            if (employee != null)
            {
                employee.EmployeeId = newemployee.EmployeeId;
                employee.Name = newemployee.Name;
                employee.DepartmentName = newemployee.DepartmentName;
               
                employee.Address=newemployee.Address;
                employee.Contact=newemployee.Contact;
                context.SaveChanges();
            }

        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = context.Employees.Find(id);
            return emp;
        }
    }
}
