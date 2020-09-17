using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrumpQuotes.Models
{
    public class Embed
    {
      public Author[] Author { get; set; }

      public Source[] Source { get; set; }

    }

}
