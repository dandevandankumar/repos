using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class HttpClient
{
    static async Task Main(string[] args)
    {
        await SendJsonDataAsync(new HttpClient());
    }

    static async Task SendJsonDataAsync(HttpClient httpClient)
    {
        string apiUrl = "https://api.example.com/endpoint";

        // JSON data to send
        var jsonContent = new StringContent(
            "{\"key1\": \"value1\", \"key2\": \"value2\"}",
            Encoding.UTF8,
            "application/json"
        );

        using (var httpClient = httpClient)
        {
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Request successful");
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine("Request failed");
                Console.WriteLine($"{(int)response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}
