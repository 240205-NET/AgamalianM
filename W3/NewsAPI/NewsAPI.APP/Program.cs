using System.Text.Json;
using System;
using System.Security.Cryptography.X509Certificates;
using NewsAPI.DTO;

namespace NewsAPI.App
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("News API Consumer Starting...");

            string apikey = "03e900e861e54a2498da1a65855a4e3d";
            string source = "bbc-news";
            HttpClient client = new HttpClient();
            string uri = $"https://newsapi.org/v2/everything?sources={source}&apiKey={apikey}";

            string response = await client.GetStringAsync(uri);

            // Console.WriteLine(response);
            Headline headline = JsonSerializer.Deserialize<Headline>(response);

            foreach (var item in headline.articles)
            {
                Console.WriteLine(item.title);
            }
        }
    }
}