using Microsoft.AspNetCore.Mvc;
using ServerConnections.Models;

namespace ServerConnections.Controllers
{
    public class CourseController : Controller
    {
        private CollegeContext _context;
        public CourseController(CollegeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TblCourse> Courses = _context.TblCourses.ToList();
            return View(Courses);
        }

        public IActionResult AddCourse()
        {
            TblCourse course = new TblCourse();
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(TblCourse course)
        {
            _context.TblCourses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditCourse(long id)
        {
            TblCourse course = _context.TblCourses.Where(x => x.Id == id).SingleOrDefault();
            return View(course);
        }
        [HttpPost]
        public IActionResult EditCourse(TblCourse course)
        {
            _context.TblCourses.Update(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCourse(long id)
        {
            TblCourse course = _context.TblCourses.Where(x => x.Id == id).SingleOrDefault();
            return View(course);
        }
        [HttpPost]
        public IActionResult DeleteCourse(TblCourse course)
        {
            _context.TblCourses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
