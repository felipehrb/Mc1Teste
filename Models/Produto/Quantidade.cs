using System.ComponentModel.DataAnnotations;

namespace MC1Test.Models
{
    public class Quantidade
    {
        public long Id { get; set; }

        [Required]
        public int Produto { get; set; }

        [Required]
        public int Quant { get; set; }
    }
}