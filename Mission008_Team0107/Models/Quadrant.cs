using System.ComponentModel.DataAnnotations;

namespace Mission008_Team0107.Models;

    public class Quadrant
    {
        [Key]
        public int QuadrantId { get; set; }
        [Required]
        public string QuadrantName { get; set; }
    }
