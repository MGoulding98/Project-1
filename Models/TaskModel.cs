using System;
using System.ComponentModel.DataAnnotations;
using Project_1.Models;

namespace Project_1.Models
{
    public class TaskModel
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        // set up foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; }
    }
}
