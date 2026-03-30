using System.Dynamic;
using enrolmentSystem.Data;
using enrolmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace enrolmentSystem.Pages
{
    public class AddsubjectModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddsubjectModel(AppDbContext context)
        {
            _context = context;
        }



        public List<Subject> subjects { get; set; } = new();
        public List<Course> courses { get; set; } = new();
        [BindProperty]
        public Subject sub { get; set; }
        public void OnGet()
        {
            Loaddata();
        }

        public void Loaddata()
        {
            subjects = _context.Subjects.ToList();
            courses = _context.Courses.ToList();
        }

        public IActionResult OnpostAddsubject()
        {

            bool subjectcheck = _context.Subjects.Any(s => s.subjectID == sub.subjectID);
            // Add validation errors
            if (subjectcheck)
                ModelState.AddModelError("sub.subjectID", "subject ID already exists");
            if (!ModelState.IsValid)
            {
                Loaddata();
                return Page();
            }
            if (!ModelState.IsValid)
            {
                Loaddata(); // Reload data if validation fails
                return Page();
            }


            _context.Subjects.Add(sub);
            _context.SaveChanges();

            Loaddata();
            return Page();
        }
    }
}
