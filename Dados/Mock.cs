using MC1Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc1Test.Dados
{
    public class Mock
    {
private Mock() { }


        public static void Initialize(ProdutoContext _context)
        {
            //Mock Produtos
            if (_context.Produtos.Count() == 0)
            {
                _context.Produtos.Add(new Produto
                {
                    Name = "Produto 1",
                    Valor = 5,
                    Marca = "xingling",
                    Tipo = 1,
                });
                _context.Produtos.Add(new Produto
                {
                    Name = "Produto 2",
                    Valor = 5,
                    Marca = "xingling",
                    Tipo = 2,
                });
                _context.SaveChanges();
            }

            //Mock Tipos
            if (_context.Tipos.Count() == 0)
            {
                _context.Tipos.Add(new Tipo
                {
                    Name = "Doce",
                });
                _context.Tipos.Add(new Tipo
                {
                    Name = "Salgado",
                });
                _context.SaveChanges();
            }

            //Mock Descontos
            if (_context.Descontos.Count() == 0)
            {
                _context.Descontos.Add(new Desconto
                {
                    Tipo = 1,
                    Valor = 10,
                });
                _context.Descontos.Add(new Desconto
                {
                    Tipo = 2,
                    Valor = 20,
                });
                _context.SaveChanges();
            }

            //Mock Quantidades
            if (_context.Quantidades.Count() == 0)
            {
                _context.Quantidades.Add(new Quantidade
                {
                    Produto = 1,
                    Quant = 13,
                });
                _context.Quantidades.Add(new Quantidade
                {
                    Produto = 1,
                    Quant = -10,
                });
                _context.Quantidades.Add(new Quantidade
                {
                    Produto = 2,
                    Quant = 10,
                });
                _context.Quantidades.Add(new Quantidade
                {
                    Produto = 2,
                    Quant = 10,
                });
                _context.SaveChanges();
            }
        }
    }
}
