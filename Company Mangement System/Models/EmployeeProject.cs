using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Mangement_System.Models
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }
        [Required,ForeignKey(nameof(employee))]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
        [Required, ForeignKey(nameof(project))]
        public int ProjectId { get; set; }
        public Project project { get; set; }
        [Required, MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }
    }
}
