using System;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

public class HttpClientManager
{
    private static readonly HttpClient SharedClient = new HttpClient
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
    };

    public static async Task Main(string[] args)
    {
        await GetAsync();
        //await PostAsync();
        await PostAsJsonAsync();
        await PutAsync();
    }

    private static async Task GetAsync()
    {
        using HttpResponseMessage response = await SharedClient.GetAsync("todos/3");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");
    }

    //static async Task PostAsync()
    //{
    //    using StringContent jsonContent = new(
    //        JsonSerializer.Serialize(new
    //        {
    //            userId = 77,
    //            title = "write code sample",
    //            completed = false
    //        }),
    //        Encoding.UTF8,
    //        "application/json");

    //    using HttpResponseMessage response = await SharedClient.PostAsync(
    //        "todos",
    //        jsonContent);

    //    response.EnsureSuccessStatusCode();

    //    var jsonResponse = await response.Content.ReadAsStringAsync();
    //    Console.WriteLine($"{jsonResponse}\n");
    //}

    static async Task PostAsJsonAsync()
    {
        using HttpResponseMessage response = await SharedClient.PostAsJsonAsync(
            "todos",
            new Todo(UserId: 9, Id: 99, Title: "Show extensions", Completed: false));

        response.EnsureSuccessStatusCode();

        var todo = await response.Content.ReadFromJsonAsync<Todo>();
        Console.WriteLine($"{todo}\n");
    }

    static async Task PutAsync()
    {
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                userId = 1,
                id = 1,
                title = "foo bar",
                completed = false
            }),
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await SharedClient.PutAsync(
            "todos/1",
            jsonContent);

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");
    }



}
