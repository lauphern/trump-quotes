using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrumpQuotes.Models
{

  public class Source
  {

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    public string Filename { get; set; }

    [JsonPropertyName("quote_source_id")]
    public string QuoteSourceId { get; set; }

    public string Remarks { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    public string Url { get; set; }

    [JsonPropertyName("_links")]
    public Link Link { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Source>(this);

  }

}
