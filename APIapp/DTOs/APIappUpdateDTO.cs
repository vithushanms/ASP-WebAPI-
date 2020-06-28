using System.ComponentModel.DataAnnotations;

namespace APIapp.DTOs
{
    public class APIappUpdateDTO
    {
        [Required]
        [MaxLength(250)]
        public string How { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}