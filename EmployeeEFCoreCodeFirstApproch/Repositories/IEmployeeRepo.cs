using EmployeeEFCoreCodeFirstApp.Models;
using System.Collections.Generic;

namespace EmployeeEFCoreCodeFirstApp.Repositories
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmployees();
        void AddNewEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        void DeleteEmployee(int id);
    }
}
