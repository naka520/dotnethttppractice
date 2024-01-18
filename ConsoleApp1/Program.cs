using System;
using System.Net.Http;
using System.Threading.Tasks;

public class HttpClientManager
{
    private static readonly HttpClient SharedClient = new HttpClient
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
    };

    public static async Task Main(string[] args)
    {
        await GetAsync();
    }

    private static async Task GetAsync()
    {
        using HttpResponseMessage response = await SharedClient.GetAsync("todos/3");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");
    }
}
