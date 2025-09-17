using ControleDeEstacionamento.Desktop.Modelos;
using System.Text.Json;

namespace ControleDeEstacionamento.Desktop.ClientesAPI
{
    public class EstacionamentoApiClient
    {
        private readonly HttpClient _httpClient;

        public EstacionamentoApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Configuracao.ESTACIONAMENTO_URL_BASE);
        }

        public async Task<List<PrecoEstacionamento>> BuscarTodosPrecosEstacionamentoAsync()
        {
            try
            {
                HttpResponseMessage? response = await _httpClient.GetAsync("api/estacionamento/precos");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var apiError = JsonSerializer.Deserialize<ApiError>(errorContent, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        throw new ErroDeApiException(apiError?.Erro ?? "Erro do servidor");
                    }
                    catch (JsonException)
                    {
                        throw new ErroDeApiException("Erro do servidor");
                    }
                }

                var json = await response.Content.ReadAsStringAsync();
                var precos = JsonSerializer.Deserialize<List<PrecoEstacionamento>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return precos ?? new List<PrecoEstacionamento>();
            }
            catch
            {
                throw new Exception("Erro inesperado ao buscar preços");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}