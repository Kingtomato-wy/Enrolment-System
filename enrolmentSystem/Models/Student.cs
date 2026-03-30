using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enrolmentSystem.Models
{
    public class Student
    {
        [Key]
        public string? studentID { get; set; }

        public int semester { get; set; }

        [Required(ErrorMessage = "Primary Email Address is required! ")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string? studentEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? studentPassword { get; set; } = string.Empty;


        //Student Profile
        [Required(ErrorMessage = "Student Name is required! ")]
        public string? studentName { get; set; } = string.Empty;


        //Email
        [Required(ErrorMessage = "Primary Email Address is required! ")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string? primaryEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Aleternative Email Address is required! ")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string? alternativeEmail { get; set; } = string.Empty;


        //Contact Number
        [Required(ErrorMessage = "Telephone Number is required! ")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Invalid Contact Number! ")]
        [RegularExpression(@"^01\d*$", ErrorMessage = "Invalid Contact Number! ")]
        public string? TelNum { get; set; } = string.Empty;

        [Required(ErrorMessage = "HP Number is required! ")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Invalid Contact Number! ")]
        [RegularExpression(@"^01\d*$", ErrorMessage = "Invalid Contact Number! ")]
        public string? HPNum { get; set; } = string.Empty;


        //Permanant Home Address
        [Required(ErrorMessage = "Address is required! ")]
        public string? permanantAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required! ")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Postal Code must be exactly 5 digits. ")]
        public string? permanantPostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Area is required! ")]
        public string? permanantArea { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required! ")]
        public string? permanantState { get; set; } = string.Empty;


        //Current Mailing Address
        [Required(ErrorMessage = "Address is required! ")]
        public string? CurrentAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required! ")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Postal Code must be exactly 5 digits. ")]
        public string? CurrentPostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Area is required! ")]
        public string? CurrentArea { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required! ")]
        public string? CurrentState { get; set; } = string.Empty;


        //Emergency Contact
        [Required(ErrorMessage = "Relationship is required! ")]
        public string? emergencyContactRelationship { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Person Name is required!")]
        [MinLength(3, ErrorMessage = "Contact Person Name must be at least 3 characters long")]
        public string? emergencyContactName { get; set; } = string.Empty;

        [Required(ErrorMessage = "HP Number is required! ")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Invalid Contact Number! ")]
        [RegularExpression(@"^01\d*$", ErrorMessage = "Invalid Contact Number! ")]
        public string? emergencyHPNum { get; set; } = string.Empty;


        //Bank Details
        public string? bankDetails { get; set; } = string.Empty;

        public ICollection<Enrolment>? Enrolments { get; set; } = new List<Enrolment>();
        public ICollection<Evaluation>? Evaluations { get; set; }
        public ICollection<Inquiry>? Inquiries { get; set; }

        [ForeignKey("Course")]
        public string? courseID { get; set; }
        public Course? Course { get; set; }
        public ICollection<addDropRequest>? AddDropRequests { get; set; }




    }
}
