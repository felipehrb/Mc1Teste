using Microsoft.EntityFrameworkCore;

namespace MC1Test.Models
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Desconto> Descontos { get; set; }
        public DbSet<Quantidade> Quantidades { get; set; }

    }
}
