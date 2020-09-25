using System.Text.Json;

namespace TrumpQuotes.Models
{
    public class Embed
    {
      public Author[] Author { get; set; }

      public Source[] Source { get; set; }

      public override string ToString() => JsonSerializer.Serialize<Embed>(this);

    }

}
