using Microsoft.EntityFrameworkCore;
using Company_Mangement_System.Models;
using Microsoft.Identity.Client;

namespace Company_Mangement_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Projects)
                .WithOne(p => p.department)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
                .HasData(
                    new Department { Id = 1, Name = "Human Resources", Location = "Building A" },
                    new Department { Id = 2, Name = "IT", Location = "Building B" },
                    new Department { Id = 3, Name = "Finance", Location = "Building C" }
                );

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Id = 1, FullName = "John Doe", Email = "john.doe@example.com", Salary = 50000, DepartmentId = 1, HireDate = new DateTime(2023,11,25) },
                    new Employee { Id = 2, FullName = "Jane Smith", Email = "jane.smith@example.com", Salary = 60000, DepartmentId = 2, HireDate = new DateTime(2023,11,20) },
                    new Employee { Id = 3, FullName = "Alice Johnson", Email = "alice.johnson@example.com", Salary = 70000, DepartmentId = 3, HireDate = new DateTime(2023,9,15) },
                    new Employee { Id = 4, FullName = "Bob Brown", Email = "bob.brown@example.com", Salary = 80000, DepartmentId = 1, HireDate = new DateTime(2025,12,10) },
                    new Employee { Id = 5, FullName = "Charlie Davis", Email = "charlie.davis@example.com", Salary = 90000, DepartmentId = 2, HireDate = new DateTime(2024,10,5) },
                    new Employee { Id = 6, FullName = "Diana Evans", Email = "diana.evans@example.com", Salary = 100000, DepartmentId = 3, HireDate = new DateTime(2023,11,15) },
                    new Employee { Id = 7, FullName = "Ethan Foster", Email = "ethan.foster@example.com", Salary = 110000, DepartmentId = 1, HireDate = new DateTime(2023,11,15) },
                    new Employee { Id = 8, FullName = "Fiona Green", Email = "fiona.green@example.com", Salary = 120000, DepartmentId = 2, HireDate = new DateTime(2023,11,15) }
                );

            modelBuilder.Entity<Project>()
                .HasData(
                    new Project { Id = 1, Name = "Project Alpha", Description = "Description for Project Alpha", StartDate = DateTime.Now.AddDays(-30), Budget = 50000, DepartmentId = 1 },
                    new Project { Id = 2, Name = "Project Beta", Description = "Description for Project Beta", StartDate = DateTime.Now.AddDays(-20), Budget = 75000, DepartmentId = 2 },
                    new Project { Id = 3, Name = "Project Gamma", Description = "Description for Project Gamma", StartDate = DateTime.Now.AddDays(-10), Budget = 100000, DepartmentId = 3 },
                    new Project { Id = 4, Name = "Project Delta", Description = "Description for Project Delta", StartDate = DateTime.Now.AddDays(-5), Budget = 120000, DepartmentId = 1 }
                );
            modelBuilder.Entity<EmployeeProject>()
                .HasData(
                    new EmployeeProject { Id = 1, EmployeeId = 1, ProjectId = 1, AssignedRole = "Developer", AssignedDate = DateTime.Now.AddDays(-10) },
                    new EmployeeProject { Id = 2, EmployeeId = 2, ProjectId = 2, AssignedRole = "Tester", AssignedDate = DateTime.Now.AddDays(-5) },
                    new EmployeeProject { Id = 3, EmployeeId = 3, ProjectId = 3, AssignedRole = "Manager", AssignedDate = DateTime.Now.AddDays(-15) },
                    new EmployeeProject { Id = 4, EmployeeId = 4, ProjectId = 4, AssignedRole = "Designer", AssignedDate = DateTime.Now.AddDays(-20) },
                    new EmployeeProject { Id = 5, EmployeeId = 5, ProjectId = 1, AssignedRole = "Developer", AssignedDate = DateTime.Now.AddDays(-8) },
                    new EmployeeProject { Id = 6, EmployeeId = 6, ProjectId = 2, AssignedRole = "Tester", AssignedDate = DateTime.Now.AddDays(-12) }
                );
        }        
    }
}
