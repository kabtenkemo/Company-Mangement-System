using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Mangement_System.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required,Range(3000,100000)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required,ForeignKey(nameof(department))]
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        public ICollection<EmployeeProject>? EmployeeProjects { get; set; }
    }
}
