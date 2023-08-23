using Shop.Application.Clients;
using System.Net.Http.Headers;

namespace Shop.Application.Emails.Clients;

public class EmailSenderClient : ISenderClient
{
    public async Task<SenderResponse> SendAsync<SenderResponse,SendEmailRequest>
        (SendEmailRequest sendRequest) 
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Patch,
            RequestUri = new Uri("https://rapidprod-sendgrid-v1.p.rapidapi.com/alerts/%7Balert_id%7D"),
            Headers =
            {
                { "X-RapidAPI-Key", "12627086e7msh4966fd7c187df4bp16e572jsn2f3576ea8b75" },
                { "X-RapidAPI-Host", "rapidprod-sendgrid-v1.p.rapidapi.com" },
            },
            Content = new StringContent("{\r\n    \"type\": \"stats_notification\",\r\n    \"email_to\": \"example@test.com\",\r\n    \"frequency\": \"daily\"\r\n}")
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }

        throw new NotImplementedException();
    }
}
