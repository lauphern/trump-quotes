using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrumpQuotes.Models
{
  public class QuoteModel
  {
    [JsonPropertyName("appeared_at")]
    public string AppearedAt { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("quote_id")]
    public string QuoteId { get; set; }

    public string[] Tags { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    public string Value { get; set; }

    [JsonPropertyName("_embedded")]
    public Embed Embedded { get; set; }

    [JsonPropertyName("_links")]
    public Link Link { get; set; }

    public override string ToString() => JsonSerializer.Serialize<QuoteModel>(this);

  }

}
