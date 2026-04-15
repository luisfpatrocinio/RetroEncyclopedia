using System.Windows.Forms;
using RetroEncyclopedia.Models;

namespace RetroEncyclopedia.Controls {
    public partial class AchievementCard : UserControl {
        public AchievementCard() {
            InitializeComponent();
        }

        // Método que o Form1 vai chamar para "injetar" os dados
        public void SetAchievementData(Achievement achievement) {
            lblTitle.Text = $"{achievement.Title}\n({achievement.Points} pts)";
            picBadge.LoadAsync(achievement.BadgeImageUrl);
        }
    }
}
