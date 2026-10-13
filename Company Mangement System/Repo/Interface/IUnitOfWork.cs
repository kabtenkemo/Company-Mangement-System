using Company_Mangement_System.Models;

namespace Company_Mangement_System.Repo.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepo<Department> Departments { get; }
        IEmployeeRepo Employees { get; }
        IGenericRepo<Project> Projects { get; }
        IEmployeeprojectRepo EmployeeProjects { get; }
        IUserRepo Users { get; }
        Task<int> save();
    }
}
