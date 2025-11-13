using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Company_WebApp.Models;
using Company_WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Company_WebApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext EmployeeDbContext;
        public EmployeeRepository(AppDbContext EmployeeDbContext)
        {
            this.EmployeeDbContext = EmployeeDbContext;
        }

        public IQueryable<Employee> GetEmployee()
        {
             IQueryable<Employee> GetAllEmployees = EmployeeDbContext
             .Employees.Include(e => e.Department)
             .AsNoTracking();
            return GetAllEmployees;
        }

        public async Task CreateEmployee(Employee employee)
        {
           await EmployeeDbContext.Employees.AddAsync(employee); // sync
           await EmployeeDbContext.SaveChangesAsync();
    
        }


        public async Task UpdateEmployee(Employee employee)
        {
            EmployeeDbContext.Employees.Update(employee); // sync task
            await EmployeeDbContext.SaveChangesAsync();
        }



        public async Task<bool> DeleteEmployee(int EmployeeId)
        {
            var isEmployeeExists = await EmployeeDbContext.Employees.FirstOrDefaultAsync(e => e.Id == EmployeeId);

            if (isEmployeeExists is null) return false;

            EmployeeDbContext.Employees.Remove(isEmployeeExists);

            await EmployeeDbContext.SaveChangesAsync();

            return true;
        }
    }
}