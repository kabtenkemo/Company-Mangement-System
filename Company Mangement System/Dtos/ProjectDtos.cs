using Company_Mangement_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Mangement_System.Dtos
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }

    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }

    public class UpdateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }
}
