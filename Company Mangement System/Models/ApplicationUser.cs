using System.ComponentModel.DataAnnotations;

namespace Company_Mangement_System.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(20),MaxLength(150)]
        public string Name { get; set; }
        [Required,EmailAddress,MaxLength(100)]
        public string Email { get; set; }
        [Required,MaxLength(100)]
        public string Password { get; set; }
        [Required, MaxLength(50)]
        public string Role { get; set; }
    }
}
