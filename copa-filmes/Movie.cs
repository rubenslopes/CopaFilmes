using System.Text.Json.Serialization;

namespace copa_filmes
{
  public class Movie
  {
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("titulo")]
    public string Title { get; set; }

    [JsonPropertyName("ano")]
    public int Year { get; set; }

    [JsonPropertyName("nota")]
    public decimal Score { get; set; }
  }
}
