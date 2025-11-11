using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Company_WebApp.Models;
using Company_WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Company_WebApp.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext DepartmentDbContext;
        public DepartmentRepository(AppDbContext DepartmentDbContext)
        {
            this.DepartmentDbContext = DepartmentDbContext;
        }


        public Department CreateDepartment()
        {
            var Department_obj = new Department { Id = 1, Description = "For food management!", Name = "Food Department" };
            return Department_obj;
        }
        
        public List<Department> GetDepartment()
        {
            var Department_obj = DepartmentDbContext.Departments.AsNoTracking().ToList();
            return Department_obj;
        }
    }
}