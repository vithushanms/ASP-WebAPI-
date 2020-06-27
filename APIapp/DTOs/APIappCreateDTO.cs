using System.ComponentModel.DataAnnotations;

namespace APIapp.DTOs
{
    public class APIappCreateDTO
    {
        public string How { get; set; }

        public string Line { get; set; }

        public string Platform { get; set; }
    }
}