using ControleDeEstacionamento.Desktop.Modelos;
using System.Text;
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

        public async Task AdicionarPrecoAsync(PrecoEstacionamento preco)
        {
            try
            {
                var json = JsonSerializer.Serialize(preco, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage? response = await _httpClient.PostAsync("api/estacionamento/precos", content);

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
            }
            catch (ErroDeApiException)
            {
                throw;
            }
            catch
            {
                throw new Exception("Erro inesperado ao adicionar preço");
            }
        }

        public async Task<List<EntradaSaida>> BuscarTodasEntradasSaidasAsync()
        {
            try
            {
                HttpResponseMessage? response = await _httpClient.GetAsync("api/estacionamento/entradas-saidas");

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
                var entradasSaidas = JsonSerializer.Deserialize<List<EntradaSaida>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return entradasSaidas ?? new List<EntradaSaida>();
            }
            catch (ErroDeApiException)
            {
                throw;
            }
            catch
            {
                throw new Exception("Erro inesperado ao buscar entradas e saídas");
            }
        }

        public async Task RegistrarEntradaAsync(string placa)
        {
            try
            {
                var carro = new Carro { Placa = placa };
                var json = JsonSerializer.Serialize(carro, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/estacionamento/entrada", content);

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
            }
            catch (ErroDeApiException)
            {
                throw;
            }
            catch
            {
                throw new Exception("Erro inesperado ao registrar entrada");
            }
        }

        public async Task<EntradaSaida> RegistrarSaidaAsync(string placa)
        {
            try
            {
                var json = JsonSerializer.Serialize(placa, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/estacionamento/saida", content);

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

                var responseJson = await response.Content.ReadAsStringAsync();
                var entradaSaida = JsonSerializer.Deserialize<EntradaSaida>(responseJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return entradaSaida ?? throw new ErroDeApiException("Resposta inválida do servidor");
            }
            catch (ErroDeApiException)
            {
                throw;
            }
            catch
            {
                throw new Exception("Erro inesperado ao registrar saída");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}