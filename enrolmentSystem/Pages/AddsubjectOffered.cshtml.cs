using enrolmentSystem.Data;
using enrolmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace enrolmentSystem.Pages
{
    public class AddsubjectOfferedModel : PageModel
    {

        private readonly AppDbContext _context;

        public AddsubjectOfferedModel(AppDbContext context)
        {
            _context = context;
        }



        public List<Subject> subjects { get; set; } = new();
        public List<subjectOffered> subjectOffereds { get; set; } = new();
        public List<Lecturer> lecturers { get; set; } = new();
        public List<Session> sessions { get; set; } = new();


        [BindProperty]
        public subjectOffered subjectoo { get; set; }
        public void OnGet()
        {
            Loaddata();
        }

        public IActionResult OnPostAddoffered()
        {

            // Check existence directly from database
            bool subjectExists = _context.Subjects.Any(s => s.subjectID == subjectoo.subjectID);
            bool lecturerExists = _context.Lecturers.Any(l => l.lecturerID == subjectoo.lecturerID);

            // Add validation errors
            if (!subjectExists)
                ModelState.AddModelError("subjectoo.subjectID", "Subject ID does not exist");

            if (!lecturerExists)
                ModelState.AddModelError("subjectoo.lecturerID", "Lecturer ID does not exist");


            // Only return if validation fails
            if (!ModelState.IsValid)
            {
                Loaddata();
                return Page();
            }

            // Save to database

            _context.SubjectsOffered.Add(subjectoo);
            _context.SaveChanges();

            // Clear form and show success
            TempData["SuccessMessage"] = "Subject offered added successfully";
            return RedirectToPage();
        }

        public void Loaddata()
        {
            subjects = _context.Subjects.ToList();
            lecturers = _context.Lecturers.ToList();
            sessions = _context.Sessions.ToList();
        }

        public async Task<JsonResult> OnGetValidateSubject(string id)
        {
            bool exists = await _context.Subjects.AnyAsync(s => s.subjectID == id);
            return new JsonResult(new { exists });
        }
    }
}
