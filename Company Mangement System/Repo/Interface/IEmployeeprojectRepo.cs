using Company_Mangement_System.Models;

namespace Company_Mangement_System.Repo.Interface
{
    public interface IEmployeeprojectRepo:IGenericRepo<EmployeeProject>
    {
        Task<IEnumerable<EmployeeProject>> GetEmployeeProjectsByEmployeeIdAsync(int employeeId);
    }
}
