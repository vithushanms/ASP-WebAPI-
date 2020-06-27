using System.ComponentModel.DataAnnotations;

namespace APIapp.DTOs
{
    public class APIappControllerRead
    {
        public int Id { get; set; }
  
        public string How { get; set; }

        public string Line { get; set; }

        public string Platform { get; set; }
    }
}