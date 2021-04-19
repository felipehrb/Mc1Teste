using System.ComponentModel.DataAnnotations;

namespace MC1Test.Models
{
    public class Tipo
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
