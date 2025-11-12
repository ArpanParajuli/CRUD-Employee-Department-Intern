using Microsoft.AspNetCore.Mvc;
using Company_WebApp.Models;
using Company_WebApp.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company_WebApp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var Employee1 = employeeRepository.GetEmployee();

            return View(Employee1);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = departmentRepository.GetDepartment();
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Console.WriteLine("Received Create employye request!");
    
                employeeRepository.CreateEmployee(employee);
                return RedirectToAction("Index");
        }



        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View();
        //}



        [HttpPost]
        public IActionResult Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                var isSuccess = employeeRepository.UpdateEmployee(employee);

                if (isSuccess == null)
                {
                    return RedirectToPage("index");
                }
            }


            return RedirectToPage("index");
        }


        //[HttpGet]
        //public IActionResult Delete()
        //{
        //    return View();
        //}



        [HttpPost]

        public IActionResult Delete(int id)
        {  
         
            var isSuccess = employeeRepository.DeleteEmployee(id);

            if (isSuccess == false)
            {
                return RedirectToPage("index");
            }

            return View();
        }
    }
}
