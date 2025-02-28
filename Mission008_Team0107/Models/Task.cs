using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission008_Team0107.Models;

    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string? DueDate { get; set; }
        [ForeignKey("QuadrantId")]
        public int QuadrantId { get; set; }
        public Quadrant Quadrant { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool? Completed { get; set; }

    }
