using Company_Mangement_System.Models;

namespace Company_Mangement_System.Repo.Interface
{
    public interface IEmployeeRepo:IGenericRepo<Employee>
    {
        Task<IEnumerable<Employee>> SearchAsync(string name);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId);
    }
}
