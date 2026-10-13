using Company_Mangement_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Mangement_System.Dtos
{
    public class CreateEmployeeProjectDto
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        [Required, MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }
    }

    public class UpdateEmployeeProjectDto
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        [Required, MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }
    }


    public class EmployeeProjectDto
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string AssignedRole { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
