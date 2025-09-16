using Microsoft.AspNetCore.Mvc;
using ControleDeEstacionamento.Model.Services;
using ControleDeEstacionamento.Application.DTOs;
using ControleDeEstacionamento.Domain.Models;

namespace ControleDeEstacionamento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly EstacionamentoService _service;

        public EstacionamentoController(EstacionamentoService service)
        {
            _service = service;
        }

        // Registrar entrada
        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntradaAsync([FromBody] CarroDTO carroDto)
        {
            await _service.RegistrarEntradaAsync(carroDto.Placa);
            return Ok(new { mensagem = "Entrada registrada com sucesso" });
        }


        [HttpPost("saida")]
        public async Task<IActionResult> RegistrarSaidaAsync([FromBody] EntradaSaidaDTO entradaSaidaDTO)
        {
            await _service.RegistrarSaidaAsync(entradaSaidaDTO.PlacaCarro);

            if (entradaSaidaDTO == null)
                return NotFound(new { mensagem = "Registro não encontrado" });

            var resposta = new EntradaSaidaDTO
            {

            };

            return Ok(resposta);
        }


        [HttpPost("preco")]
        public async Task<IActionResult> AdicionarPreco([FromBody] PrecoEstacionamentoDTO precoEstacionamentoDTO)
        {
            await _service.AdicionarPrecoEstacionamento(precoEstacionamentoDTO);

            return Ok(new { mensagem = "Preço cadastrado com sucesso." });
        }
    }
}
