using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebPageTest.Models
{   
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Name")]
        [Range(1,500, ErrorMessage ="Order must be between 1 - 500!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}