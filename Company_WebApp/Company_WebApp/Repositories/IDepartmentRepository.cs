using Company_WebApp.Models;

namespace Company_WebApp.Repositories
{
    public interface IDepartmentRepository
    {
        Department CreateDepartment();

        List<Department> GetDepartment();
    }
}