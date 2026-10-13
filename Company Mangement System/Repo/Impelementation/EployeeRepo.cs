using Company_Mangement_System.Data;
using Company_Mangement_System.Models;
using Company_Mangement_System.Repo.Interface;

namespace Company_Mangement_System.Repo.Impelementation
{
    public class EployeeRepo:GenericRepo<Employee>,IEmployeeRepo
    {
        private readonly AppDbContext _context;
        public EployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> SearchAsync(string name)
        {
            var employees = _context.Employees.Where(e => e.FullName.Contains(name)).ToList();
            return await Task.FromResult(employees);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            var employees = _context.Employees.Where(e => e.DepartmentId == departmentId).ToList();
            return await Task.FromResult(employees);
        }
    }
}
