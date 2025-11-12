using Microsoft.AspNetCore.Mvc;
using Company_WebApp.Repositories;
using Company_WebApp.Models;

namespace Company_WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var AllDepartment = departmentRepository.GetDepartment();
            return View(AllDepartment);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.AddDepartment(department);
                return RedirectToAction("Index");
            }
            // return View(department);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.UpdateDepartment(department);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }



        //[HttpGet]
        //public IActionResult Delete()
        //{
        //    return View();
        //}


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = departmentRepository.DeleteDepartment(id);
            if (!success)
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}
