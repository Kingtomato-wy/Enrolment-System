using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using enrolmentSystem.Models;
using enrolmentSystem.Data;
using Microsoft.Extensions.Primitives;

namespace enrolmentSystem.Pages
{
    public class EnrolmentModel : PageModel
    {
        private readonly AppDbContext _context;

        public EnrolmentModel(AppDbContext context)
        {
            _context = context;
        }

        // Properties
        public List<subjectOffered> SubjectOfferedList { get; set; } = new();
        public List<Subject> SubjectsList { get; set; } = new();
        public List<Enrolment> Enrolments { get; set; } = new();
        public List<Student> Students { get; set; } = new();

        [BindProperty]
        public List<string> SelectedSubjectIds { get; set; } = new();

        [BindProperty]
        public string StudentId { get; set; }

        public IActionResult OnGet(string studentId = "I22023072")
        {
            var checkstudent = _context.Students
                .FirstOrDefault(so => so.studentID == StudentId);
            if (checkstudent != null)
            {
                StudentId = studentId;
            }
            else
            {
                return RedirectToPage("./Error");
            }
            LoadData();
            return Page();
        }

        public IActionResult OnPostAddsubjects()
        {
            if (!ModelState.IsValid)
            {
                LoadData();
                return Page();
            }

            // Process selected subjects
            TempData["SelectedSubjects"] = SelectedSubjectIds;
            LoadData();
            return Page();
        }

        public IActionResult OnPostEnroll()
        {
            var selectedIds = TempData["SelectedSubjects"] as List<string> ?? new List<string>();

            foreach (var subjectId in selectedIds)
            {
                var enrolment = new Enrolment
                {
                    studentID = StudentId,
                    status = "Pending",
                    enrolDate = DateTime.Now
                };
                _context.Enrolments.Add(enrolment);
            }

            _context.SaveChanges();
            return RedirectToPage("./Success");
        }

        private void LoadData()
        {
            SubjectOfferedList = _context.SubjectsOffered
                .Include(so => so.Subject)
                .ToList();

            SubjectsList = _context.Subjects.ToList();
            Enrolments = _context.Enrolments.ToList();
        }
    }
}
