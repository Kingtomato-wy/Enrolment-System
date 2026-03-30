using enrolmentSystem.Data;
using enrolmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace enrolmentSystem.Pages
{
    public class SetTimetableModel : PageModel
    {
        private readonly AppDbContext _context;

        public SetTimetableModel(AppDbContext context)
        {
            _context = context;
        }

        public List<subjectOffered> subjectOffereds { get; set; } = new();
        public List<Timetable> timetables { get; set; } = new();
        [BindProperty]
        public Timetable timett { get; set; }

        public void OnGet(int? subjectOfferedID)
        {
            // Always load the subjects
            subjectOffereds = _context.SubjectsOffered.ToList();

            // Load timetables only if an ID is provided
            if (subjectOfferedID.HasValue)
            {
                timetables = _context.Timetables
                    .Where(t => t.subjectOfferedID == subjectOfferedID.Value)
                    .OrderBy(t => t.day)
                    .ThenBy(t => t.startTime)
                    .ThenBy(t => t.endTime)
                    .ToList();
            }
        }

        public IActionResult OnGetTimetableJson(int subjectoo)
        {
            if (subjectoo != 0)
            {
                var timetableData = _context.Timetables
                    .Where(t => t.subjectOfferedID == subjectoo)
                    .OrderBy(t => t.day)
                    .ThenBy(t => t.startTime)
                    .ThenBy(t => t.endTime)
                    .Select(t => new
                    {
                        timetableID = t.timetableID,
                        day = t.day.ToString(),
                        startTime = t.startTime.ToString(),
                        endTime = t.endTime.ToString(),
                        roomType = t.roomtType
                    })
                    .ToList();

                return new JsonResult(timetableData);
            }

            return new JsonResult(new { message = "No timetable found." });
        }

        public IActionResult OnPostAddtimetable()
        {
            if (!ModelState.IsValid)
            {
                subjectOffereds = _context.SubjectsOffered.ToList();
                return Page();
            }

            _context.Timetables.Add(timett);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Timetable added successfully";
            return RedirectToPage();
        }

        public IActionResult OnPostDeletetimetable()
        {
            var timetableToDelete = _context.Timetables
                .FirstOrDefault(t => t.timetableID == timett.timetableID);

            if (timetableToDelete != null)
            {
                _context.Timetables.Remove(timetableToDelete);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Timetable deleted successfully";
            }

            return RedirectToPage();
        }
    }
}