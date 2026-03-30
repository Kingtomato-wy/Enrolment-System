using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Models
{
    public class Inquiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? inquiryID { get; set; }

        [ForeignKey("Student")]
        public string? studentID { get; set; }
        public Student? Student { get; set; }

        [Required(ErrorMessage = "This field is required! ")]
        public string? title { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required! ")]
        public string? description { get; set; } = string.Empty;

        public DateTime? date { get; set; }
    }
}
