using Microsoft.AspNetCore.Mvc;
using Company_WebApp.Models;
using Company_WebApp.Repositories;

namespace Company_WebApp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        
        public IActionResult Index()
        {
            var Employee1 = employeeRepository.GetEmployee();
            return View(Employee1);
        }

        public IActionResult Create()
        {
            var Employee1 = employeeRepository.CreateEmployee();
            return View(Employee1);
        }



        public IActionResult Edit()
        {
            var Employee1 = new Employee
            {
                Id = 1,
                Address = "Nayamill",
                Email = "arpanparajuli@gmail.com",
                Name = "Arpan Parajuli",
                Phone = "9867710675"
            };
            return View(Employee1);
        }


         public IActionResult Delete()
        {
            var Employee1 = new Employee
            {
                Id = 1,
                Address = "Nayamill",
                Email = "arpanparajuli@gmail.com",
                Name = "Arpan Parajuli",
                Phone = "9867710675"
            };
            return View(Employee1);
        }
    }
}
