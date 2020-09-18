
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrumpQuotes.Models;

namespace TrumpQuotes.WebSite.Services
{
  public class HttpQuoteService
  {
    static HttpClient client = new HttpClient();

    public async Task<QuoteModel> GetQuoteAsync()
    {
      QuoteModel quote = null;
      // They use await with GetAsync in the official tutorial:
      // https://docs.microsoft.com/es-es/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
      // But it wasn't working when I called it from the component
      // Fix src: https://stackoverflow.com/questions/43148155/httpclient-getasync-not-working-as-expected
      HttpResponseMessage response = client.GetAsync("random/quote").Result;
      //TODO error handling
      if (response.IsSuccessStatusCode)
      {
        // https://www.thetopsites.net/article/52660492.shtml
        string data = await response.Content.ReadAsStringAsync();
        quote = JsonSerializer.Deserialize<QuoteModel>(data,
            new JsonSerializerOptions
            {
              PropertyNameCaseInsensitive = true
            });
      }
      //TODO
      Regex rx = new Regex(@"(\\n)*http.*",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

      Type quoteType = typeof(QuoteModel);
      PropertyInfo valueInstance = quoteType.GetProperty("Value");
      valueInstance.SetValue(quote, rx.Replace(quote.Value, ""));
      return quote;
    }

    public static void ConnectApi()
    {
      client.BaseAddress = new Uri("https://api.tronalddump.io/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(
          new MediaTypeWithQualityHeaderValue("application/json"));
    }
  }

}