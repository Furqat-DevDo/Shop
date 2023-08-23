using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Registration.Services;
using Shop.Application.Clients;
using Shop.Application.Emails.Models;
using Shop.Application.Emails.Options;
using System.Net.Http.Headers;

namespace Shop.Application.Emails.Clients;

public class EmailSenderClient : HttpClient,ISenderClient<SenderResponse,EmailSendRequest>
{
    private readonly ILogger<EmailSenderClient> _logger;
    private readonly IOptions<SendgridOptions> _options;

    public EmailSenderClient(
        IOptions<SendgridOptions> options, 
        ILogger<EmailSenderClient> logger)
    {
        _options = options;
        _logger = logger;
    }

    public async Task<SenderResponse> SendAsync(EmailSendRequest sendRequest)
    {
        if (sendRequest is null)
        {
            _logger.LogError("Request body was null !!!");
            throw new WrongInputException(nameof(EmailSendRequest));
        }

        if (_options.Value is null)
        {
            _logger.LogError("Setting not configured !!!");
            throw new ArgumentNullException(nameof(SendgridOptions));
        }

        var settings = _options.Value;

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(settings.RequestUri),
            Headers =
            {
                { settings.Headers.Key, settings.Headers.KeyValue },
                { settings.Headers.HostValue, settings.Headers.HostValue },
            },
            Content = new StringContent($"{{\"type\": \"stats_notification\"," +
            $" \"email_to\": \"{sendRequest.To}\",\"frequency\": \"daily\"}}")
            //Content = new StringContent("{\r\n \"personalizations\": [\r\n {\r\n \"to\": [\r\n {\r\n \"email\": \"john@example.com\"\r\n}\r\n ],\r\n \"subject\": \"Hello, World!\"\r\n }\r\n ],\r\n \"from\":{\r\n\"email\": \"from_address@example.com\"\r\n },\r\n \"content\": [\r\n {\r\n \"type\": \"text/plain\",\r\n  \"value\": \"Hello, World!\"\r\n }\r\n ]\r\n}")
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue(settings.ContentType)
                }
            }
        };


        using (var response = await SendAsync(request))
        {
            var emailResponse = new SenderResponse();

            try
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                emailResponse.IsSuccess = true;
                emailResponse.StatusCode = (int)response.StatusCode;
                emailResponse.ExceptionMessage = string.Empty;
            }
            catch (Exception ex)
            {
                emailResponse.IsSuccess = false;
                emailResponse.StatusCode = (int)response.StatusCode;
                emailResponse.ExceptionMessage = ex.Message;
            }

            return emailResponse;
        }
    }
}
