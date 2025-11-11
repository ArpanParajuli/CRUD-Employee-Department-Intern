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

        public List<Employee> GetEmployee()
        {
            var employeeobj = EmployeeDbContext.Employees.AsNoTracking().ToList();
            return employeeobj;
        }

        public Employee CreateEmployee()
        {
            var Employee1 = new Employee { Id = 1, Address = "awdawdawd", Email = "awdadawd@adaw", Name = "dawada", Phone = "wdwadada" };
            return Employee1;
        }


        public Employee UpdateEmployee()
        {
            var Employee1 = new Employee { Id = 1, Address = "awdawdawd", Email = "awdadawd@adaw", Name = "dawada", Phone = "wdwadada" };
            return Employee1;
        }
        


         public Employee  DeleteEmployee()
        {
            var Employee1 = new Employee { Id = 1, Address = "awdawdawd", Email = "awdadawd@adaw", Name = "dawada", Phone = "wdwadada" };
            return Employee1;
        }
    }
}