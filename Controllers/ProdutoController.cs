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
    public class ProdutoController : Controller
    {
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
            Mock.Initialize(context);
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            return _context.Produtos.ToList();
        }

        /// <summary>
        /// Pesquisa um produto pela id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O produto encontrado.</returns>
        /// <response code="201">Returns o produto encontrado</response>
        /// <response code="400">se o produto for nulo</response>
        [HttpGet("{id}", Name = "GetProduto")]
        public ActionResult<Produto> GetById(long id)
        {
            var item = _context.Produtos.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>o novo produto criado.</returns>
        /// <response code="201">Returns o produto criado</response>
        /// <response code="400">se o produto for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Produto> Create(Produto item)
        {
            _context.Produtos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduto", new { id = item.Id }, item);
        }

        /// <summary>
        /// Altera um produto específico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>o novo produto alterado.</returns>
        /// <response code="201">Returns o produto alterado</response>
        /// <response code="400">se o produto for nulo</response>
        [HttpPut("{id}")]
        public IActionResult Update(long id, Produto item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var tp = _context.Produtos.Find(id);
            if (tp == null)
            {
                return NotFound();
            }

            tp.Name = item.Name;

            _context.Produtos.Update(tp);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Deleta um produto específico.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Produtos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}