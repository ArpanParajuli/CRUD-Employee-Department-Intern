using Microsoft.AspNetCore.Mvc;
using Company_WebApp.Models;
using Company_WebApp.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var AllEmployeesDetails = await employeeRepository.GetEmployee().ToListAsync();
            return View(AllEmployeesDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments = departmentRepository.GetDepartment();
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            Console.WriteLine("Received Create employye request!");
             
                await employeeRepository.CreateEmployee(employee);
                return RedirectToAction("Index");
        }



        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View();
        //}



        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                 await employeeRepository.UpdateEmployee(employee);
                 return RedirectToPage("index");
            }

            return View("index");
        }


        //[HttpGet]
        //public IActionResult Delete()
        //{
        //    return View();
        //}



        [HttpPost]

        public async Task<ActionResult> Delete(int id)
        {  
         
            var isSuccess = await employeeRepository.DeleteEmployee(id);

            if (isSuccess == false)
            {
                return RedirectToPage("index");
            }

            return View();
        }
    }
}
