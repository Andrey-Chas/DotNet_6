using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace Assignment.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ImageName { get; set; }
        [DisplayName("Image")]
        [NotMapped]
        [Required]
        public IFormFile Image { get; set; }
        [DisplayName("Author Name")]
        [Required]
        public string AuthorName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Tag")]
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
