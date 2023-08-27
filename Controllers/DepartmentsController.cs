using Microsoft.AspNetCore.Mvc;

using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class DepartmentsController : Controller
    {
        public DepartmentService DepartmentService { get; set; }

        public DepartmentsController()
        {

            DepartmentService = new DepartmentService();
        }

        public IActionResult Index()
        {
            var deaprtments = DepartmentService.Index();
            return View(deaprtments);
        }

        public IActionResult Details(int id)
        {
            Department? department = DepartmentService.Details(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Department department)
        {
            DepartmentService.Create(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit([FromQuery] int id)
        {
            Department? department = DepartmentService.Details(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] Department department)
        {
            department.Id = id;
            DepartmentService.Edit(department);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Department? department = DepartmentService.Details(id);
            if (department == null)
            {
                return NotFound();
            }
            DepartmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
}