using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class DepartmentService
    {
        public ItiContext DbContext { get; set; }

        public DepartmentService()
        {

            DbContext = new ItiContext();
        }

        public IEnumerable<Department> Index()
        {
            return DbContext.Departments.ToList();
        }

        public Department? Details(int id)
        {
            return DbContext.Departments.FirstOrDefault(s => s.Id == id);
        }

        public void Create(Department department)
        {
            DbContext.Add(department);
            DbContext.SaveChanges();
        }

        public void Edit(Department department)
        {
            DbContext.Update(department);
            DbContext.SaveChanges();
        }

        public void Delete(Department department)
        {
            DbContext.Remove(department);
            DbContext.SaveChanges();
        }

    }
}