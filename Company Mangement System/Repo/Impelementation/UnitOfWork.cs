using Company_Mangement_System.Data;
using Company_Mangement_System.Models;
using Company_Mangement_System.Repo.Interface;

namespace Company_Mangement_System.Repo.Impelementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepo<Department> Departments { get; }
        public IEmployeeRepo Employees { get; }
        public IGenericRepo<Project> Projects { get; }
        public IEmployeeprojectRepo EmployeeProjects { get; }
        public UnitOfWork(AppDbContext context, IGenericRepo<Department> departments, IEmployeeRepo employees, IGenericRepo<Project> projects, IEmployeeprojectRepo employeeProjects)
        {
            _context = context;
            Departments = departments;
            Employees = employees;
            Projects = projects;
            EmployeeProjects = employeeProjects;
        }

        public Task<int> save()
        {
            return Task.FromResult(_context.SaveChanges());
        }
    }
}
