using System.Text.Json;

namespace TrumpQuotes.Models
{
  public class Self
  {
    public string Href { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Self>(this);

  }

}
