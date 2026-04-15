using RetroEncyclopedia.Models;
using RetroEncyclopedia.Services;
using System.Drawing.Text;

namespace RetroEncyclopedia {
    public partial class Form1 : Form {
        private readonly RetroApiService _apiService = new RetroApiService();
        public Form1() {
            InitializeComponent();

            // Bloqueia a ComboBox para o usu[ario apenas poder escolher as opções.
            cbConsole.DropDownStyle = ComboBoxStyle.DropDownList;

            // Adicionar Consoles
            cbConsole.Items.Add("Mega Drive");
            cbConsole.Items.Add("Super Nintendo (SNES)");
            cbConsole.Items.Add("Nintendo 64");
            cbConsole.Items.Add("Game Boy Advance");
            cbConsole.Items.Add("Playstation 1");

            cbConsole.SelectedIndex = 1;
        }

        private async void btnSearch_Click(object sender, EventArgs e) {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm)) {
                MessageBox.Show("Por favor, digite o nome de um jogo.");
                return;
            }

            // Converter o texto da ComboBox para ID do Console na API
            // @TODO: Testar cada console para garantir que os IDs estão corretos
            int consoleId = 3; // SNES como fallback
            if (cbConsole.SelectedItem != null) {
                switch (cbConsole.SelectedItem.ToString()) {
                    case "Mega Drive": consoleId = 2; break;
                    case "Super Nintendo (SNES)": consoleId = 3; break;
                    case "Nintendo 64": consoleId = 4; break;
                    case "Game Boy Advance": consoleId = 5; break;
                    case "PlayStation 1": consoleId = 12; break;
                }
            }

            try {
                // Desativar botão para evitar múltiplos cliques.
                btnSearch.Enabled = false;

                var gameList = await _apiService.GetGameListAsync(consoleId);

                var foundGame = gameList.FirstOrDefault(g =>
                    g.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) &&
                    !g.Title.Contains("~Hack~", StringComparison.OrdinalIgnoreCase) &&
                    !g.Title.Contains("~Demo~", StringComparison.OrdinalIgnoreCase) &&
                    !g.Title.Contains("~Homebrew~", StringComparison.OrdinalIgnoreCase)
                );

                if (foundGame == null) {
                    MessageBox.Show("Jogo não encontrado nesse console. Verifique o nome ou escolha outro console.", "Não encontrado");
                    return;
                }

                // Obter restante das informações a partir do ID
                var gameDetails = await _apiService.GetGameDetailsAsync(foundGame.Id);
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
            if (!string.IsNullOrEmpty(game.BoxArtFullUrl)) {
                picBoxArt.LoadAsync(game.BoxArtFullUrl);
            }

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
                BackColor = Color.FromArgb(45, 45, 48),
                Margin = new Padding(10)
            };

            var pic = new PictureBox {
                Size = new Size(64, 64),
                Location = new Point(28, 10),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            pic.LoadAsync(ach.BadgeImageUrl);

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
    }
}