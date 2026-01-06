using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCourses.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string ProfessorId { get; set; } // IdentityUser Id

        [ForeignKey("ProfessorId")]
        public virtual IdentityUser Professor { get; set; }

        public string ImageUrl { get; set; } // Link ose path i fotos së kursit
    }
}
