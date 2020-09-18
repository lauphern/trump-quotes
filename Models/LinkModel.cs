using System.Text.Json;

namespace TrumpQuotes.Models
{
  public class Link
  {
    public Self Self { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Link>(this);
    
  }

}