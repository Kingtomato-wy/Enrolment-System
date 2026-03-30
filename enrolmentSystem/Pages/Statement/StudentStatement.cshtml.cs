using enrolmentSystem.Data;
using enrolmentSystem.Pages.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace enrolmentSystem.Pages.Statement
{
    public class StudentStatementModel : PageModel
    {
        private readonly AppDbContext context;

        public StudentStatementModel(AppDbContext context)
        {
            this.context = context;
        }

        // Get Statement date
        [BindProperty]
        public DateOnly StatementStartDate { get; set; }

        [BindProperty]
        public DateOnly StatementEndDate { get; set; }

        // Current date and time
        public DateOnly CurrentDate { get; set; }
        public TimeOnly CurrentTime { get; set; }

        // Statement data
        public string StatementDate { get; set; } = string.Empty;

        // Student Data
        public string StudentID { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string CourseID { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;

        //Store data retrieved from database
        //public List<Transaction> Transactions { get; set; } = new();

        // Set Student Data function
        public void SetStudentData()
        {
            //StudentID = HttpContext.Session.GetString("StudentID"); //Get StudentID from session
            StudentID = "I22023292";
            var student = context.Student.Include(s => s.Course).FirstOrDefault(s => s.studentID == StudentID);
            if (student != null)
            {
                StudentName = student.studentName;
                CourseID = student.courseID;
                CourseName = student.Course.courseName;
            }
            else
            {
                RedirectToPage("/Login/Login");
            }
        }

        public void OnGet()
        {
            SetStudentData();
            StatementStartDate = DateOnly.FromDateTime(DateTime.Now);
            StatementEndDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public void OnPost() 
        {
            SetStudentData();
            // Set current date and time, statement date
            CurrentDate = DateOnly.FromDateTime(DateTime.Now);
            CurrentTime = TimeOnly.FromDateTime(DateTime.Now);

            StatementDate = StatementStartDate.ToString() + '-' + StatementEndDate.ToString();
        }
    }
}
