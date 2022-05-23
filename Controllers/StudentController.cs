using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerConnections.Models;

namespace ServerConnections.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private CollegeContext _context;
        public StudentController(CollegeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TblStudent> studentsList = _context.TblStudents.Include(x => x.Course).ToList();
            return View(studentsList);
        }

        public IActionResult AddStudent()
        {
            TblStudent student = new TblStudent();
            ViewBag.courseList = _context.TblCourses.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.CourseName,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(TblStudent student)
        {
            _context.TblStudents.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditStudent(long id)
        {
            TblStudent student = _context.TblStudents.Where(x => x.Id == id).SingleOrDefault();
            ViewBag.courseList = _context.TblCourses.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.CourseName,
                Value = x.Id.ToString()
            });
            return View(student);
        }
        [HttpPost]
        public IActionResult EditStudent(TblStudent student)
        {
            _context.TblStudents.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteStudent(long id)
        {
            TblStudent student = _context.TblStudents.Where(x => x.Id == id).SingleOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteStudent(TblStudent student)
        {
            _context.TblStudents.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
