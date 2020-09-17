using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrumpQuotes.Models
{
  public class Link
  {
    public Self Self { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Link>(this);
    
  }

}