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
            var employeeobj = EmployeeDbContext.Employees.Include(e => e.Department).AsNoTracking().ToList();
            return employeeobj;
        }

        public Employee CreateEmployee(Employee employee)
        {
            EmployeeDbContext.Employees.Add(employee);
            EmployeeDbContext.SaveChanges();
            return employee;
        }


        public Employee UpdateEmployee(Employee employee)
        {
            EmployeeDbContext.Employees.Update(employee);
            EmployeeDbContext.SaveChanges();
            return employee;
        }



        public bool DeleteEmployee(int EmployeeId)
        {
            var isEmployeeExists = EmployeeDbContext.Employees.FirstOrDefault(e => e.Id == EmployeeId);

            if (isEmployeeExists == null)
            {
                return false;
            }

            EmployeeDbContext.Employees.Remove(isEmployeeExists);

            EmployeeDbContext.SaveChanges();

            return true;
        }
    }
}