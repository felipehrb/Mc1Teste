using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MC1Test.Models;
using Mc1Test.Dados;

namespace MC1Test.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : Controller
    {
        private readonly ProdutoContext _context;

        public RelatorioController(ProdutoContext context)
        {
            _context = context;
            Mock.Initialize(context);
        }

        [HttpGet]
        public ActionResult<List<Relatorio>> GetAll()
        {
            List<Relatorio> relatorios = new List<Relatorio>();

            _context.Produtos.ToList<Produto>().ForEach(p =>
            {
                Tipo tipo = _context.Tipos.Where(t => t.Id == p.Tipo).FirstOrDefault();
                Desconto desconto = _context.Descontos.Where(d => d.Tipo == p.Tipo).FirstOrDefault();
                List<Quantidade> quantidade = _context.Quantidades.Where(q => q.Produto == p.Tipo).ToList<Quantidade>();

                relatorios.Add(new Relatorio
                {
                    Id = p.Id,
                    Produto = p,
                    Tipo = tipo,
                    Desconto = desconto,
                    Quantidades = quantidade,
                    QuantidadeTotal = quantidade.Select(g =>
                        quantidade.Sum(q => q.Quant)
                ).FirstOrDefault()
                });

            });
            
            return relatorios;
        }

        /// <summary>
        /// Pesquisa um Relatorio por produto pela id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O relatorio do produto encontrado.</returns>
        /// <response code="201">Returns relatorio do produto encontrado</response>
        /// <response code="400">se o relatorio do produto for nulo</response>
        [HttpGet("{id}", Name = "GetRelatorio")]
        public ActionResult<Relatorio> GetById(long id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }

            Tipo tipo = _context.Tipos.Where(t => t.Id == produto.Tipo).FirstOrDefault();
            Desconto desconto = _context.Descontos.Where(d => d.Tipo == produto.Tipo).FirstOrDefault();
            List<Quantidade> quantidade = _context.Quantidades.Where(q => q.Produto == produto.Tipo).ToList<Quantidade>();
           
            Relatorio relatorio = new Relatorio
            {
                Id = produto.Id,
                Produto = produto,
                Tipo = tipo,
                Desconto = desconto,
                Quantidades = quantidade,
                QuantidadeTotal = quantidade.Select(g =>
                    quantidade.Sum(q => q.Quant)
                ).FirstOrDefault()
            };

            return relatorio;
        }
    }
}