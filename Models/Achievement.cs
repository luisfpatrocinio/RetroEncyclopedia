using System.Text.Json.Serialization;

namespace RetroEncyclopedia.Models {
    public class Achievement {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Points")]
        public int Points { get; set; }

        [JsonPropertyName("BadgeName")]
        public string BadgeName { get; set; }

        // Propriedade calculada para montar a URL da imagem da conquista
        public string BadgeImageUrl {
            get {
                return $"https://media.retroachievements.org/Badge/{BadgeName}.png";
            }
        }
    }
}