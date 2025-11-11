using Company_WebApp.Models;

namespace Company_WebApp.Repositories
{
    public interface IEmployeeRepository
    {
        Employee CreateEmployee();
        List<Employee> GetEmployee();
    }
}