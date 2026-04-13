using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RetroEncyclopedia.Models {
    public class GameDetails {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("ImageIcon")]
        public string ImageIcon { get; set; }

        [JsonPropertyName("Developer")]
        public string Developer { get; set; }

        [JsonPropertyName("Achievements")]
        public Dictionary<string, Achievement> Achievements { get; set; } = new Dictionary<string, Achievement>();

        public string BoxArtFullUrl {
            get {
                // Se a API não mandar imagem, evitamos erros
                if (string.IsNullOrEmpty(ImageIcon)) return string.Empty;

                return $"https://retroachievements.org{ImageIcon}";
            }
        }
    }
}