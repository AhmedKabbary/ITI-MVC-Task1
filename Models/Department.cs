using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Department
    {
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public required ICollection<Student> Students { get; set; }
    }
}