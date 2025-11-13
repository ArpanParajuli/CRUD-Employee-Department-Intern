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

        public IQueryable<Department> GetDepartment()
        {
            IQueryable<Department> GetAllDepartments =  DepartmentDbContext.Departments.AsNoTracking();
            return GetAllDepartments;
        }

        public async Task AddDepartment(Department department)
        {
           await DepartmentDbContext.Departments.AddAsync(department);
           await DepartmentDbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartment(Department department)
        {
            DepartmentDbContext.Departments.Update(department); // update method is sync operation in db
            await DepartmentDbContext.SaveChangesAsync();
        }
        
        public async Task<bool> DeleteDepartment(int DepartmentId)
        {
            var findDeparment = await GetDepartmentById(DepartmentId);
             if (findDeparment is null)  return false; // == null = is null
    
            DepartmentDbContext.Departments.Remove(findDeparment); // remove() is also sync

            await DepartmentDbContext.SaveChangesAsync();
        
            return true;
        }


        public async Task<Department?> GetDepartmentById(int id) // might return null or data 
        {
            return await DepartmentDbContext.Departments
            .AsNoTracking() // for performance improve
            .FirstOrDefaultAsync(d => d.Id == id);
        }

    }
}