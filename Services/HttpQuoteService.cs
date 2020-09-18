
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using TrumpQuotes.Models;

namespace TrumpQuotes.WebSite.Services
{
  // public class HttQuoteService
  // {
  //   public HttQuoteService(IWebHostEnvironment webHostEnvironment)
  //   {
  //     WebHostEnvironment = webHostEnvironment;
  //   }

  //   public IWebHostEnvironment WebHostEnvironment { get; }

  //   private string JsonFileName
  //   {
  //     get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
  //   }

  //   public IEnumerable<QuoteModel> GetQuotes()
  //   {
  //     using (var jsonFileReader = File.OpenText(JsonFileName))
  //     {
  //       return JsonSerializer.Deserialize<QuoteModel[]>(jsonFileReader.ReadToEnd(),
  //           new JsonSerializerOptions
  //           {
  //             PropertyNameCaseInsensitive = true
  //           });
  //     }
  //   }

  // }

  public class HttpQuoteService
  {
    static HttpClient client = new HttpClient();

    // static void ShowProduct(QuoteModel product)
    // {
    //   Console.WriteLine($"Name: {product.Name}\tPrice: " +
    //       $"{product.Price}\tCategory: {product.Category}");
    // }

    // static async Task<Uri> CreateProductAsync(QuoteModel product)
    // {
    //   HttpResponseMessage response = await client.PostAsJsonAsync(
    //       "api/products", product);
    //   response.EnsureSuccessStatusCode();

    //   // return URI of the created resource.
    //   return response.Headers.Location;
    // }

    public async Task<QuoteModel> GetQuoteAsync()
    {
      QuoteModel quote = null;
      // string quote = null;
      HttpResponseMessage response = await client.GetAsync("random/quote");
      //TODO error handling
      if (response.IsSuccessStatusCode)
      {
        // quote = await response.Content.ReadAsAsync<QuoteModel>();
        // https://www.thetopsites.net/article/52660492.shtml
        string data = await response.Content.ReadAsStringAsync();
        quote = JsonSerializer.Deserialize<QuoteModel>(data,
            new JsonSerializerOptions
            {
              PropertyNameCaseInsensitive = true
            });
        // quote = await response.Content.ReadAsAsync<string>();
      }
      //TODO
      //sometimes the quote value comes with a link
      //usar regex para ver algo que empiece con http y quitarlo (si hay link en source)
      return quote;
      // return new QuoteModel(quote);
      // return JsonSerializer.Deserialize<QuoteModel>(quote,
      //       new JsonSerializerOptions
      //       {
      //         PropertyNameCaseInsensitive = true
      //       });
    }

    // static async Task<QuoteModel> UpdateProductAsync(QuoteModel product)
    // {
    //   HttpResponseMessage response = await client.PutAsJsonAsync(
    //       $"api/products/{product.Id}", product);
    //   response.EnsureSuccessStatusCode();

    //   // Deserialize the updated product from the response body.
    //   product = await response.Content.ReadAsAsync<QuoteModel>();
    //   return product;
    // }

    // static async Task<HttpStatusCode> DeleteProductAsync(string id)
    // {
    //   HttpResponseMessage response = await client.DeleteAsync(
    //       $"api/products/{id}");
    //   return response.StatusCode;
    // }

    // static async Task RunAsync()
    public static void ConnectApi()
    {
      client.BaseAddress = new Uri("https://api.tronalddump.io/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(
          new MediaTypeWithQualityHeaderValue("application/json"));
    }
  }

}