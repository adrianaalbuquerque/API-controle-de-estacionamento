using ControleDeEstacionamento.Application.DTOs;
using ControleDeEstacionamento.Domain.Exceptions;
using ControleDeEstacionamento.Domain.Models;
using ControleDeEstacionamento.Model.Services;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                await _service.RegistrarEntradaAsync(carroDto.Placa);
                return Ok(new { mensagem = "Entrada registrada com sucesso" });
            }
            catch (PlacaInvalidaException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (CarroComEntradaSemSaidaException ex)
            {
                return Conflict(new { erro = ex.Message });
            }
            catch (DataEntradaInvalidaException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                // Logar ex se quiser
                return StatusCode(500, new { erro = "Erro interno ao registrar entrada." });
            }
        }

        [HttpPost("saida")]
        public async Task<IActionResult> RegistrarSaidaAsync([FromBody] string placa)
        {
            try
            {
                var entradaSaida = await _service.RegistrarSaidaAsync(placa);

                if (entradaSaida == null)
                    return NotFound(new { mensagem = "Registro não encontrado ou já finalizado" });

                var resposta = new EntradaSaidaDTO
                {
                    PlacaCarro = entradaSaida.PlacaCarro,
                    DataEntrada = entradaSaida.DataEntrada,
                    DataSaida = entradaSaida.DataSaida,
                    ValorAPagar = entradaSaida.ValorAPagar
                };

                return Ok(resposta);
            }
            catch (PlacaInvalidaException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (CarroNaoEncontradoException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (EntradaNaoEncontradaException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (SaidaJaRegistradaException ex)
            {
                return Conflict(new { erro = ex.Message });
            }
            catch (DataHoraSaidaAnteriorAEntradaException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                // Logar se quiser
                return StatusCode(500, new { erro = "Erro interno ao registrar saída." });
            }
        }

        [HttpPost("preco")]
        public async Task<IActionResult> AdicionarPreco([FromBody] PrecoEstacionamentoDTO precoEstacionamentoDTO)
        {
            await _service.AdicionarPrecoEstacionamento(precoEstacionamentoDTO);

            return Ok(new { mensagem = "Preço cadastrado com sucesso." });
        }
    }
}
