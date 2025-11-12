using Company_WebApp.Models;

namespace Company_WebApp.Repositories
{
    public interface IEmployeeRepository
    {
        Employee CreateEmployee(Employee employee);
        List<Employee> GetEmployee();

        bool DeleteEmployee(int EmployeeId);

         Employee UpdateEmployee(Employee employee);


    }
}