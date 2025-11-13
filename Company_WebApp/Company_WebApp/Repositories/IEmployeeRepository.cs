using Company_WebApp.Models;

namespace Company_WebApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateEmployee(Employee employee);
        IQueryable<Employee> GetEmployee();
        Task<bool> DeleteEmployee(int EmployeeId);
        Task UpdateEmployee(Employee employee);

    }
}