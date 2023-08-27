using Microsoft.EntityFrameworkCore;

using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class StudentService
    {
        public ItiContext DbContext { get; set; }

        public StudentService()
        {

            DbContext = new ItiContext();
        }

        public IEnumerable<Student> Index()
        {
            return DbContext.Students.Include(s => s.Department).ToList();
        }

        public Student? Details(int id)
        {
            return DbContext.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Create(Student student)
        {
            DbContext.Add(student);
            DbContext.SaveChanges();
        }

        public void Edit(Student student)
        {
            DbContext.Update(student);
            DbContext.SaveChanges();
        }

        public void Delete(Student student)
        {
            DbContext.Remove(student);
            DbContext.SaveChanges();
        }

    }
}