using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Models
{
    public class Admin
    {
        [Key]
        public string? adminID { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string? adminName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? adminPassword { get; set; } = string.Empty;
        public ICollection<addDropRequest>? AddDropRequests { get; set; }

    }
}
