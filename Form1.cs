using System;
using System.Windows.Forms;
using RetroEncyclopedia.Services;

namespace RetroEncyclopedia {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // Associa a função ao evento de carregamento (quando a janela é aberta)
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e) {
            try {
                // 1. Instanciamos o nosso serviço
                var apiService = new RetroApiService();

                // 2. Chamamos a API para buscar o jogo com ID 1444 (Teste)
                var gameDetails = await apiService.GetGameDetailsAsync(1444);

                // 3. Montamos uma mensagem de sucesso
                string mensagem = $"Sucesso!\n\n" +
                                  $"Jogo Encontrado: {gameDetails.Title}\n" +
                                  $"Desenvolvedora: {gameDetails.Developer}\n" +
                                  $"Total de Conquistas: {gameDetails.Achievements.Count}";

                // 4. Mostramos a mensagem
                MessageBox.Show(mensagem, "Teste de API", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}