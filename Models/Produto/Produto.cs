using System.ComponentModel.DataAnnotations;

namespace MC1Test.Models
{
    public class Produto
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int Tipo { get; set; }

    }
}