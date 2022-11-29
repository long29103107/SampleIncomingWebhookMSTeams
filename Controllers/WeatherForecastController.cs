using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SendMessageToMSTeams.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet("/Message1")]
    public async Task<IActionResult> Message1()
    {
        await PostTemplateAsync("template.json");
        return Ok();
    }


    [HttpGet("/Message2")]
    public async Task<IActionResult> Message2()
    {
        await PostTemplateAsync("template1.json");
        return Ok();
    }

    private async Task PostTemplateAsync(string template)
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://caothangeduvn.webhook.office.com/webhookb2/49a457d1-b3a7-4359-b355-12ceb299d072@de4eb459-7bac-4b6a-87a3-bf1025bf2d8c/IncomingWebhook/4c26d38a949d4aac89da3faf5d3ba3fb/83f37674-0a4a-465d-b2df-7935f9e7ab92"))
            {

                using (var reader = new StreamReader(template))
                {
                    var json = reader.ReadToEnd();
                    request.Content = new StringContent(json);
                }

                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var response = await httpClient.SendAsync(request);
            }
        }
    }
}
class Respone
{
    [JsonPropertyName("@Text")]
    public string Text { get; set; }
}