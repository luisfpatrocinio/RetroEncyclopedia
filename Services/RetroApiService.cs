using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RetroEncyclopedia.Models;

namespace RetroEncyclopedia.Services {
    public class RetroApiService {
        private readonly HttpClient _httpClient;
        private readonly string _userName = _userName;
        private readonly string _apiKey = _apiKey;
        private readonly string _baseUrl = "https://retroachievements.org/API/";

        public RetroApiService() {
            _httpClient = new HttpClient();

            // Carrega as credenciais do ambiente (variáveis de ambiente)
            _userName = Environment.GetEnvironmentVariable("RETRO_USERNAME");
            _apiKey = Environment.GetEnvironmentVariable("RETRO_API_KEY");

            // Validação de segurança
            if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_apiKey)) {
                throw new Exception("As variáveis de ambiente do RetroAchievements não foram encontradas. Verifique seu arquivo .env.");
            }
        }

        // Método assíncrono para buscar os detalhes de um jogo específico pelo seu ID
        public async Task<GameDetails> GetGameDetailsAsync(int gameId) {
            // 1. Montar a URL da requisição com os parâmetros de autenticação
            string url = $"{_baseUrl}API_GetGameExtended.php?z={_userName}&y={_apiKey}&i={gameId}";

            try {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Garante que a resposta foi um sucesso (Código 200 OK), senão lança um erro
                response.EnsureSuccessStatusCode();

                // Lê o texto puro (JSON) que veio da internet
                string jsonString = await response.Content.ReadAsStringAsync();
                GameDetails gameDetails = JsonSerializer.Deserialize<GameDetails>(jsonString);

                return gameDetails;
            } catch (Exception ex) {
                throw new Exception($"Erro ao buscar os dados da API: {ex.Message}");
            }
        }
    }
}