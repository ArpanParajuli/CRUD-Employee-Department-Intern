using Company_WebApp.Models;

namespace Company_WebApp.Repositories
{
    public interface IDepartmentRepository
    {
        Department CreateDepartment();
        List<Department> GetDepartment();
        bool DeleteDepartment(int DepartmentId);

         void UpdateDepartment(Department department);

        void AddDepartment(Department department);

        Department GetDepartmentById(int id);
    }
}