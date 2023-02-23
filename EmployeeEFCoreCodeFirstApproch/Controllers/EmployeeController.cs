using EmployeeEFCoreCodeFirstApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using EmployeeEFCoreCodeFirstApp.Models;

namespace EmployeeEFCoreCodeFirstApp.Controllers
{
    public class EmployeeController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        IEmployeeRepo repository;
        public EmployeeController(IEmployeeRepo repo)
        {
            this.repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.GetAllEmployees());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            repository.AddNewEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Employee employee = repository.GetEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            repository.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Employee employee = repository.GetEmployeeById(id);
            if (employee != null)
            {

                return View(employee);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            repository.DeleteEmployee(employee.EmployeeId);
            return RedirectToAction("Index");
        }
    }
}
