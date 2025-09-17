using Microsoft.AspNetCore.Mvc;
using UneCont_Notas_Fiscais.Models;
using UneCont_Notas_Fiscais.DTOs;

namespace UneCont_Notas_Fiscais.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotasFiscaisController : ControllerBase
    {
        // Declara uma vari�vel privada para o servi�o
        private readonly NotasFiscaisService _service;

        // O construtor recebe o servi�o por inje��o de depend�ncia
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
            // A valida��o do DTO � feita automaticamente pelo ASP.NET Core.
            // Se o modelo for inv�lido, o framework retorna um Bad Request (400) automaticamente.
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
                return NotFound(); // Retorna 404 Not Found se a nota n�o for encontrada
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
                return NotFound(); // Retorna 404 Not Found se a nota n�o for encontrada
            }
            return NoContent(); // Retorna 204 No Content para indicar sucesso na dele��o
        }
    }
}