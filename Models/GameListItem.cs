using System.Text.Json.Serialization;

namespace RetroEncyclopedia.Models {
    public class GameListItem {
        [JsonPropertyName("ID")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }
    }
}