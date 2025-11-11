using Microsoft.AspNetCore.Mvc;
using Company_WebApp.Repositories;

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

        public IActionResult Create()
        {
            var CreateDepartment = departmentRepository.CreateDepartment();

            return View(CreateDepartment);
        }
    }
}
