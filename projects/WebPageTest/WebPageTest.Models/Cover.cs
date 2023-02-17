using System.ComponentModel.DataAnnotations;

namespace WebPageTest.Models
{
    public class Cover
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cover type")]
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }
    }
}
