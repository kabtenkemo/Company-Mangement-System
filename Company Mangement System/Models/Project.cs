using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Mangement_System.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required,Range(1000,10000000)]
        public decimal Budget { get; set; }
        [Required,ForeignKey(nameof(department))]
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        public ICollection<EmployeeProject>? EmployeeProjects { get; set; }
    }
}
