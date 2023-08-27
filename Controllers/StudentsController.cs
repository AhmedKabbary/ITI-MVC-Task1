using Microsoft.AspNetCore.Mvc;

using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        public StudentService StudentService { get; set; }
        public DepartmentService DepartmentService { get; set; }

        public StudentsController()
        {

            StudentService = new StudentService();
            DepartmentService = new DepartmentService();
        }

        public IActionResult Index()
        {
            var students = StudentService.Index();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            Student? student = StudentService.Details(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Department> departments = DepartmentService.Index();
            ViewBag.departments = departments;
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Student student)
        {
            StudentService.Create(student);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student? student = StudentService.Details(id);
            if (student == null)
            {
                return NotFound();
            }

            IEnumerable<Department> departments = DepartmentService.Index();
            ViewBag.departments = departments;

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] Student student)
        {
            student.Id = id;
            StudentService.Edit(student);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Student? student = StudentService.Details(id);
            if (student == null)
            {
                return NotFound();
            }
            StudentService.Delete(student);
            return RedirectToAction(nameof(Index));
        }
    }
}