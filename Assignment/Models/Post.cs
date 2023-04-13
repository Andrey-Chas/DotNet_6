using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
