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
    public class DescontoController : Controller
    {
        private readonly ProdutoContext _context;

        public DescontoController(ProdutoContext context)
        {
            _context = context;
            Mock.Initialize(context);
        }

        [HttpGet]
        public ActionResult<List<Desconto>> GetAll()
        {
            return _context.Descontos.ToList();
        }

        /// <summary>
        /// Pesquisa um desconto pela id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O desconto encontrado.</returns>
        /// <response code="201">Returns o desconto encontrado</response>
        /// <response code="400">se o desconto for nulo</response>
        [HttpGet("{id}", Name = "GetDesconto")]
        public ActionResult<Desconto> GetById(long id)
        {
            var item = _context.Descontos.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Cria um novo desconto.
        /// </summary>
        /// <param name="desconto"></param>
        /// <returns>o novo desconto criado.</returns>
        /// <response code="201">Returns o desconto criado</response>
        /// <response code="400">se o desconto for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Desconto> Create(Desconto desconto)
        {
            _context.Descontos.Add(desconto);
            _context.SaveChanges();

            return CreatedAtRoute("GetDesconto", new { id = desconto.Id }, desconto);
        }

        /// <summary>
        /// Altera um desconto específico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desconto"></param>
        /// <returns>o desconto alterado.</returns>
        /// <response code="201">Returns o desconto alterado</response>
        /// <response code="400">se o desconto for nulo</response>
        [HttpPut("{id}")]
        public IActionResult Update(long id, Desconto desconto)
        {
            if (desconto == null || desconto.Id != id)
            {
                return BadRequest();
            }

            var tp = _context.Descontos.Find(id);
            if (tp == null)
            {
                return NotFound();
            }

            //todo
            _context.Descontos.Update(tp);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Deleta um desconto específico.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var tp = _context.Descontos.Find(id);
            if (tp == null)
            {
                return NotFound();
            }

            _context.Descontos.Remove(tp);
            _context.SaveChanges();
            return NoContent();
        }
    }
};