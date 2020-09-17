
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using TrumpQuotes.Models;

namespace TrumpQuotes.WebSite.Services
{
  public class HttQuoteService
  {
    public HttQuoteService(IWebHostEnvironment webHostEnvironment)
    {
      WebHostEnvironment = webHostEnvironment;
    }

    public IWebHostEnvironment WebHostEnvironment { get; }

    private string JsonFileName
    {
      get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
    }

    public IEnumerable<QuoteModel> GetQuotes()
    {
      using (var jsonFileReader = File.OpenText(JsonFileName))
      {
        return JsonSerializer.Deserialize<QuoteModel[]>(jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
            {
              PropertyNameCaseInsensitive = true
            });
      }
    }

  }

}