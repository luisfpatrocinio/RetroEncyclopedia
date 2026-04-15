using System.Globalization;
using System.Threading;
using System.ComponentModel;
using RetroEncyclopedia.Models;
using RetroEncyclopedia.Services;
using System.Drawing.Text;

namespace RetroEncyclopedia {
    public partial class Form1 : Form
    {
        private readonly RetroApiService _apiService = new RetroApiService();

        // Variável para guardar as conquistas na memória e não chamar a API toda vez que o usuário quiser ordenar ou filtrar.
        private List<Achievement> _currentAchievements = new List<Achievement>();

        public Form1()
        {
            InitializeComponent();

            // Bloqueia a ComboBox para o usu[ario apenas poder escolher as opções.
            cbConsole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;

            // Criar um dicionário com o ID da API (Key) e o Nome (Value)
            var consoles = new Dictionary<int, string> {
                { 2, "Mega Drive" },
                { 3, "Super Nintendo (SNES)" },
                { 4, "Nintendo 64" },
                { 5, "Game Boy Advance" },
                { 12, "PlayStation 1" }
            };

            // Vincular o dicionário à ComboBox
            cbConsole.DataSource = new BindingSource(consoles, null);
            cbConsole.DisplayMember = "Value";  // O que é mostrado para o usuário
            cbConsole.ValueMember = "Key";      // O valor real por trás dos pano
            cbConsole.SelectedValue = 3;

            UpdateSortComboBox();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Por favor, digite o nome de um jogo.");
                return;
            }

            // Tenta pegar o valor e já converte para 'int' com segurança. 
            // PS: Aqui a variável consoleId é definida.
            if (cbConsole.SelectedValue is not int consoleId)
            {
                MessageBox.Show("Erro interno: Console inválido selecionado.");
                return;
            }

            try
            {
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

                if (foundGame == null)
                {
                    MessageBox.Show("Jogo não encontrado nesse console. Verifique o nome ou escolha outro console.", "Não encontrado");
                    return;
                }

                // Obter restante das informações a partir do ID
                var gameDetails = await _apiService.GetGameDetailsAsync(foundGame.Id);
                UpdateInterface(gameDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao buscar os detalhes do jogo: {ex.Message}");
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        private void UpdateInterface(GameDetails game)
        {
            // Atualizar textos básicos
            lblTitle.Text = game.Title;
            lblDeveloper.Text = game.Developer;

            // Carregar a imagem de capa de forma assíncrona
            if (!string.IsNullOrEmpty(game.BoxArtFullUrl))
            {
                picBoxArt.LoadAsync(game.BoxArtFullUrl);
            }

            // Salvamos a lista de conquistas na memória
            _currentAchievements = game.Achievements.Values.ToList();

            // Desenhar na tela com o filtro atual
            RenderAchievements();
        }

        private void RenderAchievements()
        {
            // Esvazia o painel antes de desenhar
            flpAchievements.Controls.Clear();

            if (_currentAchievements == null || _currentAchievements.Count == 0)
            {
                return;
            }

            // Começar com lista original
            var processedList = _currentAchievements.AsEnumerable();

            // Filtrar conquistas a partir do termo de busca
            string filter = txtFilterAchievements.Text.Trim();

            if (!string.IsNullOrEmpty(filter))
            {
                processedList = processedList.Where(a =>
                    a.Title.Contains(filter, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Se o valor selecionado for validamente o nosso Enum, aplicamos o filtro
            if (cbSort.SelectedValue is SortOption selectedSort)
            {
                switch (selectedSort)
                {
                    case SortOption.LowestPoints:
                        processedList = processedList.OrderBy(a => a.Points);
                        break;
                    case SortOption.HighestPoints:
                        processedList = processedList.OrderByDescending(a => a.Points);
                        break;
                    case SortOption.Alphabetical:
                        processedList = processedList.OrderBy(a => a.Title);
                        break;
                        // O Default não precisa fazer nada, pois a lista já está na ordem da API
                }
            }

            // Desenhamos os painéis
            foreach (var ach in processedList)
            {
                var card = new Controls.AchievementCard();
                card.SetAchievementData(ach);
                flpAchievements.Controls.Add(card);
            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Renderizar novamente os achievements. Esse método irá aplicar a ordenação selecionada.
            RenderAchievements();
        }

        private void menuLangEnglish_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");
        }

        private void menuLangPortuguese_Click(object sender, EventArgs e)
        {
            ChangeLanguage("pt-BR");
        }

        private void ChangeLanguage(string cultureCode)
        {
            // Muda a cultura da aplicação em tempo de execução
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);

            // Manager para ler os arquivos de resources e atualizar os textos dos controles
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));

            // Atualiza os textos do formulário e dos controles
            resources.ApplyResources(this, "$this");
            resources.ApplyResources(btnSearch, "btnSearch");
            resources.ApplyResources(txtFilterAchievements, "txtFilterAchievements");

            // Atualiza a label de título
            resources.ApplyResources(lblTitle, "lblTitle");

            // Atualizar o ComboBox de ordenação
            UpdateSortComboBox();
        }

        private void UpdateSortComboBox()
        {
            // Guardar o valor que estava selecionado antes de atualizar
            var previousSelection = cbSort.SelectedValue;

            // Atualiza os textos do ComboBox de ordenação com base na cultura atual
            var sortOptions = new Dictionary<SortOption, string> {
                { SortOption.Default, Properties.Resources.SortDefault },
                { SortOption.LowestPoints, Properties.Resources.SortLowestPoints },
                { SortOption.HighestPoints, Properties.Resources.SortHighestPoints },
                { SortOption.Alphabetical, Properties.Resources.SortAlphabetical }
            };

            cbSort.DataSource = new BindingSource(sortOptions, null);
            cbSort.DisplayMember = "Value";
            cbSort.ValueMember = "Key";

            // Restaura a seleção se existir, senão volta ao Default
            cbSort.SelectedValue = previousSelection ?? SortOption.Default;
        }
    }
}