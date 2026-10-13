using System.ComponentModel.DataAnnotations;

namespace Company_Mangement_System.Dtos
{
    public class CreateDepartmentDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
    }

    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class UpdateDepartmentDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
    }
}
