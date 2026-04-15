using System.Drawing.Text;
using System.Windows.Forms;
using RetroEncyclopedia.Models;

namespace RetroEncyclopedia.Controls {
    public partial class AchievementCard : UserControl {

        // Cores para o hover integradas ao novo tema
        private readonly Color _normalColor = Color.FromArgb(22, 33, 62); 
        private readonly Color _hoverColor = Color.FromArgb(15, 52, 96);  

        public AchievementCard() {
            InitializeComponent();

            // Cor inicial
            this.BackColor = _normalColor;

            // Eventos de mouse para o efeito hover
            this.MouseEnter += OnCardMouseEnter;
            this.MouseLeave += OnCardMouseLeave;

            // Propagar os eventos de mouse para os controles filhos (para evitar que o hover "quebre" quando o mouse estiver sobre um controle interno)
            lblTitle.MouseEnter += OnCardMouseEnter;
            picBadge.MouseEnter += OnCardMouseEnter;

            lblTitle.MouseLeave += OnCardMouseLeave;
            picBadge.MouseLeave += OnCardMouseLeave;
        }

        // Método que o Form1 vai chamar para "injetar" os dados
        public void SetAchievementData(Achievement achievement) {
            lblTitle.Text = $"{achievement.Title}\n({achievement.Points} pts)";
            picBadge.LoadAsync(achievement.BadgeImageUrl);
        }

        private void OnCardMouseEnter(object? sender, EventArgs e)
        {
            this.BackColor = _hoverColor;
        }

        private void OnCardMouseLeave(object? sender, EventArgs e)
        {
            // Verifica se o mouse realmente saiu do limite do painel (para evitar flashes)
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                this.BackColor = _normalColor;
            }
        }
    }
}
