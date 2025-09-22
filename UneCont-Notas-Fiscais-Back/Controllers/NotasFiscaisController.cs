using Microsoft.AspNetCore.Mvc;
using UneCont_Notas_Fiscais.Models;
using UneCont_Notas_Fiscais.DTOs;

namespace UneCont_Notas_Fiscais.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotasFiscaisController : ControllerBase
    {
        private readonly NotasFiscaisService _service;

        public NotasFiscaisController(NotasFiscaisService service)
        {
            _service = service;
        }

        // GET /notas
        [HttpGet("/notas")]
        public ActionResult<IEnumerable<NotasFiscais>> Get()
        {
            return Ok(_service.GetAll());
        }

        // POST /notas
        [HttpPost("/notas")]
        public ActionResult<NotasFiscais> Post([FromBody] NotasFiscaisDto novaNotaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapeamento do DTO para a Entidade completa
            var novaNota = new NotasFiscais
            {
                NumeroDaNota = novaNotaDto.NumeroDaNota,
                NomeCliente = novaNotaDto.NomeCliente,
                Valor = novaNotaDto.Valor,
                DataEmissao = novaNotaDto.DataEmissao
            };

            _service.Add(novaNota);

            return CreatedAtAction(nameof(Get), null, novaNota);
        }

        // GET /notas/buscar
        [HttpGet("/notas/buscar")]
        public ActionResult<IEnumerable<NotasFiscais>> GetByNome([FromQuery] string nome)
        {
            var notasFiltradas = _service.GetByNome(nome);
            return Ok(notasFiltradas);
        }

        // GET /notas/{id}
        [HttpGet("{id}")]
        public ActionResult<NotasFiscais> Get(int id)
        {
            var nota = _service.GetById(id);
            if (nota == null)
            {
                return NotFound();
            }
            return Ok(nota);
        }

        // DELETE /notas/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var sucesso = _service.Delete(id);
            if (!sucesso)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}