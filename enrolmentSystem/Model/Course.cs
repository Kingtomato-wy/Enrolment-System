using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Model
{
    public class Course
    {
        [Key]
        public string? courseID { get; set; }

        public string? courseName{ get; set; }
    }
}
