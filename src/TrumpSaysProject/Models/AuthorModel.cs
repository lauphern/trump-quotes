using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrumpQuotes.Models
{
  public class Author
  {
    [JsonPropertyName("author_id")]
    public string AuthorId { get; set; }

    public string Bio { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonPropertyName("_links")]
    public Link Link { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Author>(this);

  }

}
