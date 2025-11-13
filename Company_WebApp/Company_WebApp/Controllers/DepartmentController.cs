using Microsoft.AspNetCore.Mvc;
using Company_WebApp.Repositories;
using Company_WebApp.Models;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;

namespace Company_WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var AllDepartment = await departmentRepository.GetDepartment().ToListAsync();
            return View(AllDepartment);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await departmentRepository.AddDepartment(department);
                return RedirectToAction("Index");
            }

           return View(department); // returining view to show errors to client
        }



        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                await departmentRepository.UpdateDepartment(department);
                return RedirectToAction("Index");
            }

            return View(department); // returining view to show errors to client
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var success =  await departmentRepository.DeleteDepartment(id);
            if (!success)
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}
