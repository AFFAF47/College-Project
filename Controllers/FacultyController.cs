using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerConnections.Models;

namespace ServerConnections.Controllers
{
    public class FacultyController : Controller
    {
        private CollegeContext _context;
        public FacultyController(CollegeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TblFaculty> facultyList = _context.TblFaculties.Include(x => x.Course).ToList();
            return View(facultyList);
        }
        public IActionResult AddFaculty()
        {
            TblFaculty faculty = new TblFaculty();
            ViewBag.courseList = _context.TblCourses.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.CourseName,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public IActionResult AddFaculty(TblFaculty faculty)
        {
            _context.TblFaculties.Add(faculty);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditFaculty(long id)
        {
            TblFaculty faculty = _context.TblFaculties.Where(x => x.Id == id).SingleOrDefault();
            ViewBag.courseList = _context.TblCourses.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.CourseName,
                Value = x.Id.ToString()

            });
            return View(faculty);
        }
        [HttpPost]
        public IActionResult EditFaculty(TblFaculty faculty)
        {
            _context.TblFaculties.Update(faculty);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFaculty(long id)
        {
            TblFaculty faculty = _context.TblFaculties.Where(x => x.Id == id).SingleOrDefault();
            return View(faculty);
        }
        [HttpPost]
        public IActionResult DeleteFaculty(TblFaculty faculty)
        {
            _context.TblFaculties.Remove(faculty);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
