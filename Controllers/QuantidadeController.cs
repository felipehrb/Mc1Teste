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
    public class QuantidadeController : Controller
    {
        private readonly ProdutoContext _context;

        public QuantidadeController(ProdutoContext context)
        {
            _context = context;
            Mock.Initialize(context);
        }

        [HttpGet]
        public ActionResult<List<Quantidade>> GetAll()
        {
            return _context.Quantidades.ToList();
        }

        /// <summary>
        /// Pesquisa um quantidade por produto id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a quantidade por produto encontrado.</returns>
        /// <response code="201">Returns a quantidade por produto encontrado</response>
        /// <response code="400">se o quantidade por produto for nulo</response>
        [HttpGet("{id}", Name = "GetQuantidade")]
        public ActionResult<Quantidade> GetById(long id)
        {
            var item = _context.Quantidades.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Cria um novo quantidade.
        /// </summary>
        /// <param name="quantidade"></param>
        /// <returns>o novo desconto criado.</returns>
        /// <response code="201">Returns a quantidade criado</response>
        /// <response code="400">se a quantidade for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Quantidade> Create(Quantidade quantidade)
        {
            _context.Quantidades.Add(quantidade);
            _context.SaveChanges();

            return CreatedAtRoute("GetQuantidade", new { id = quantidade.Id }, quantidade);
        }

        /// <summary>
        /// Deleta um a quantidade específica.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Quantidades.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Quantidades.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
};