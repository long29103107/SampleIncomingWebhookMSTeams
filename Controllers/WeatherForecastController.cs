using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace SendMessageToMSTeams.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://caothangeduvn.webhook.office.com/webhookb2/49a457d1-b3a7-4359-b355-12ceb299d072@de4eb459-7bac-4b6a-87a3-bf1025bf2d8c/IncomingWebhook/07d56538cf304f328ac531c807979c00/83f37674-0a4a-465d-b2df-7935f9e7ab92"))
            {
                request.Content = new StringContent("{'text':'KHPOT server was started'}");
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var response = await httpClient.SendAsync(request);
            }
        }
        return new List<WeatherForecast>();
    }
}
