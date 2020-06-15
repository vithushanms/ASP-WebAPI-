using System.ComponentModel.DataAnnotations;

namespace APIapp.Models
{
    public class appCommands
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string How { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}