using System.ComponentModel.DataAnnotations;
namespace SydneyStudio.Models.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required(ErrorMessage="Class Name is Required." )]
        [StringLength(50, ErrorMessage = "Classname cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }
    }
}
