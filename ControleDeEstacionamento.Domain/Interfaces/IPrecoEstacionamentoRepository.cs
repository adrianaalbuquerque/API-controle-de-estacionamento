using ControleDeEstacionamento.Domain.Models;

namespace ControleDeEstacionamento.Domain.Interfaces
{
    public interface IPrecoEstacionamentoRepository
    {
        public Task InserePrecoEstacionamentoAsync(PrecoEstacionamento precoEstacionamento);
        public Task<bool> ExisteVigenciaConflitanteAsync(DateTime dataInicio, DateTime dataFimVigencia);
        public Task<PrecoEstacionamento?> BuscaPrecoEstacionamentoVigenteAsync();
        public Task<IEnumerable<PrecoEstacionamento>> BuscarTodosPrecosEstacionamentoAsync();
    }
}
