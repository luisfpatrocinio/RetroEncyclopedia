using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RetroEncyclopedia.Models {
    public class GameDetails {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("BoxArt")]
        public string BoxArtUrl { get; set; }

        [JsonPropertyName("Developer")]
        public string Developer { get; set; }

        [JsonPropertyName("Achievements")]
        public List<Achievement> Achievements { get; set; } = new List<Achievement>();
    }
}