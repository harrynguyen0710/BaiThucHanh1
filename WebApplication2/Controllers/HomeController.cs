using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {   
/*            Person person = new Person();
            person.Name = "Hoang";
            person.Age = 19;
            person.Location = "VietNam";
            return View(person);*/
            return View(Repository.AllEmpoyees);
        }

        // HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }

        // HTTP POST VERSION
        [HttpPost]
        public IActionResult Create(Employee employee) 
        {
            if (ModelState.IsValid)
            {
                Repository.Create(employee);
                return View("Thanks", employee);
            }
            else
                return View();

        }

        /// UPDATE FEATURE
        public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e=>e.Name == empname).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee, string empname) 
        {
            if (ModelState.IsValid)
            {
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Age = employee.Age;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Salary = employee.Salary;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Department = employee.Department;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Sex = employee.Sex;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Name = employee.Name;

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        /// REMOVE FEATURE
        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}