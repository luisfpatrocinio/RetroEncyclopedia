using RetroEncyclopedia.Models;
using RetroEncyclopedia.Services;
using System.Drawing.Text;

namespace RetroEncyclopedia {
    public partial class Form1 : Form {
        private readonly RetroApiService _apiService = new RetroApiService();

        // Variável para guardar as conquistas na memória e não chamar a API toda vez que o usuário quiser ordenar ou filtrar.
        private List<Achievement> _currentAchievements = new List<Achievement>();

        public Form1() {
            InitializeComponent();

            cbSort.SelectedIndex = 0; // Seleciona o "Padrão" logo ao abrir o programa.

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
                    !g.Title.Contains("~Homebrew~", StringComparison.OrdinalIgnoreCase) &&
                    !g.Title.Contains("~Z~", StringComparison.OrdinalIgnoreCase)
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

            // Salvamos a lista de conquistas na memória
            _currentAchievements = game.Achievements.Values.ToList();

            // Desenhar na tela com o filtro atual
            RenderAchievements();
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
                Text = $"{ach.Title}\n({ach.Points} pts)",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 50
            };

            panel.Controls.Add(pic);
            panel.Controls.Add(title);

            return panel;
        }

        private void RenderAchievements() {
            // Esvazia o painel antes de desenhar
            flpAchievements.Controls.Clear();

            if (_currentAchievements == null || _currentAchievements.Count == 0) {
                return;
            }

            // Começar com lista original
            var processedList = _currentAchievements.AsEnumerable();

            // Filtrar conquistas a partir do termo de busca
            string filter = txtFilterAchievements.Text.Trim();

            if (!string.IsNullOrEmpty(filter)) {
                processedList = processedList.Where(a =>
                    a.Title.Contains(filter, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Aplicar a ordenação com base no ComboBox usando o LINQ
            if (cbSort.SelectedItem != null) {
                switch (cbSort.SelectedItem.ToString()) {
                    case "Menos Pontos":
                        processedList = processedList.OrderBy(a => a.Points);
                        break;
                    case "Mais Pontos":
                        processedList = processedList.OrderByDescending(a => a.Points);
                        break;
                    case "Ordem Alfabética (A-Z)":
                        processedList = processedList.OrderBy(a => a.Title);
                        break;
                }
            }

            // Desenhamos os painéis
            foreach (var ach in processedList) {
                var card = CreateAchievementCard(ach);
                flpAchievements.Controls.Add(card);
            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e) {
            // Renderizar novamente os achievements. Esse método irá aplicar a ordenação selecionada.
            RenderAchievements();
        }

        private void txtFilterAchievements_TextChanged(object sender, EventArgs e) {

        }
    }
}