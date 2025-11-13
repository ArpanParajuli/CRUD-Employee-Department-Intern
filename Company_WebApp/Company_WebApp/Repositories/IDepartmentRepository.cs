using Company_WebApp.Models;

namespace Company_WebApp.Repositories
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> GetDepartment();
        Task<bool> DeleteDepartment(int DepartmentId);
        Task UpdateDepartment(Department department);
        Task AddDepartment(Department department);
        Task<Department?> GetDepartmentById(int id);
    }
}