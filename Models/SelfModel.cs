using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrumpQuotes.Models
{
  public class Self
  {
    public string Href { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Self>(this);

  }

}
