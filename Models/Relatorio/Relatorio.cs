using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MC1Test.Models
{
    public class Relatorio
    {
        public long Id { get; set; }

        public Produto Produto { get; set; }

        public Tipo Tipo { get; set; }

        public Desconto Desconto { get; set; }

        public int QuantidadeTotal { get; set; }

        public List<Quantidade> Quantidades { get; set; }
    }
}