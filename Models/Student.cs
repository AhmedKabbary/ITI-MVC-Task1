﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Student
    {
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int Age { get; set; }

        [Required]
        public required int DeptNo { get; set; }

        [ForeignKey(nameof(DeptNo))]
        public Department? Department { get; set; }
    }
}