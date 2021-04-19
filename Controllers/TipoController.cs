using Mc1Test.Dados;
using MC1Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace MC1Test.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : Controller
    {
        private readonly ProdutoContext _context;

        public TipoController(ProdutoContext context)
        {
            _context = context;
            Mock.Initialize(context);
        }

        [HttpGet]
        public ActionResult<List<Tipo>> GetAll()
        {
            return _context.Tipos.ToList();
        }

        /// <summary>
        /// Pesquisa um tipo pela id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O produto encontrado.</returns>
        /// <response code="201">Returns o produto encontrado</response>
        /// <response code="400">se o produto for nulo</response>
        [HttpGet("{id}", Name = "GetTipo")]
        public ActionResult<Tipo> GetById(long id)
        {
            var item = _context.Tipos.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Cria um novo tipo.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>o novo tipo criado.</returns>
        /// <response code="201">Returns o tipo criado</response>
        /// <response code="400">se o tipo for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Produto> Create(Tipo tipo)
        {
            _context.Tipos.Add(tipo);
            _context.SaveChanges();

            return CreatedAtRoute("GetTipo", new { id = tipo.Id }, tipo);
        }

        /// <summary>
        /// Altera um tipo específico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <returns>o tipo alterado.</returns>
        /// <response code="201">Returns o tipo alterado</response>
        /// <response code="400">se o tipo for nulo</response>
        [HttpPut("{id}")]
        public IActionResult Update(long id, Tipo tipo)
        {
            if (tipo == null || tipo.Id != id)
            {
                return BadRequest();
            }

            var tp = _context.Tipos.Find(id);
            if (tp == null)
            {
                return NotFound();
            }

            tp.Name = tipo.Name;

            _context.Tipos.Update(tp);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Deleta um tipo específico.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Tipos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Tipos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}