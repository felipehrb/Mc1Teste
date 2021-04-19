using System.ComponentModel.DataAnnotations;

namespace MC1Test.Models
{
    public class Desconto
    {
        public long Id { get; set; }

        [Required]
        public int Tipo { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}