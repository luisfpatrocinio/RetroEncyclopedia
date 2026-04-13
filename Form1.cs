using RetroEncyclopedia.Models;
using RetroEncyclopedia.Services;
using System.Drawing.Text;

namespace RetroEncyclopedia {
    public partial class Form1 : Form {
        private readonly RetroApiService _apiService = new RetroApiService();
        public Form1() {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e) {
            // Validar se o ID foi digitado
            if (!int.TryParse(txtSearch.Text, out int gameId)) {
                MessageBox.Show("Por favor, digite um ID de jogo válido.");
                return;
            }

            try {
                // Desativar botão para evitar múltiplos cliques.
                btnSearch.Enabled = false;

                var gameDetails = await _apiService.GetGameDetailsAsync(gameId);
                UpdateInterface(gameDetails);
            } catch (Exception ex) {
                MessageBox.Show($"Ocorreu um erro ao buscar os detalhes do jogo: {ex.Message}");
            } finally {
                btnSearch.Enabled = true;
            }
        }

        private void UpdateInterface(GameDetails game) {
            // Atualizar textos básicos
            lblTitle.Text = game.Title;
            lblDeveloper.Text = game.Developer;

            // Carregar a imagem de capa de forma assíncrona
            picBoxArt.LoadAsync(game.BoxArtUrl);

            // Limpar conquistas anteriores
            flpAchievements.Controls.Clear();

            // Percorrer o dicionário de conquistas
            foreach (var item in game.Achievements) {
                var achievement = item.Value;

                // Criar um painel para cada conquista
                //@TODO: Substituir por um UserControl personalizado
                var card = CreateAchievementCard(achievement);
                flpAchievements.Controls.Add(card);
            }
        }

        private Control CreateAchievementCard(Achievement ach) {
            var panel = new Panel {
                Size = new Size(120, 150),
                BackColor = new Color.FromArgb(45, 45, 48),
                Margin = new Padding(10)
            };

            var pic = new PictureBox {
                Size = new Size(64, 64),
                Location = new Point(28, 10),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            var title = new Label {
                Text = ach.Title,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 40
            };

            panel.Controls.Add(pic);
            panel.Controls.Add(title);

            return panel;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}