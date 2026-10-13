using Company_Mangement_System.Data;
using Company_Mangement_System.Models;
using Company_Mangement_System.Repo.Interface;

namespace Company_Mangement_System.Repo.Impelementation
{
    public class EmployeeProjectRepo:GenericRepo<EmployeeProject>, IEmployeeprojectRepo
    {
        private readonly AppDbContext _context;
        public EmployeeProjectRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeProject>> GetEmployeeProjectsByEmployeeIdAsync(int employeeId)
        {
            var employeeProjects = _context.EmployeeProjects.Where(ep => ep.EmployeeId == employeeId).ToList();
            return await Task.FromResult(employeeProjects);
        }
    }
}
