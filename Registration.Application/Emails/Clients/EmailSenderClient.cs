using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using Registration.Application.Clients;
using Registration.Application.Emails.Clients;
using Registration.Application.Emails.Models;
using Registration.Application.Emails.Options;
using Registration.Application.Helpers;

namespace Registration.Application.Emails.Clients;

public class EmailSenderClient : HttpClient,ISenderClient<SenderResponse,SendEmailRequest>
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

    public async Task<SenderResponse> SendAsync(SendEmailRequest sendRequest)
    {
        if (_options.Value is null)
        {
            _logger.LogError("Setting not configured !!!");
            throw new ArgumentNullException(nameof(SendgridOptions));
        }

        var settings = _options.Value;

        using var request = ToHttpRequest(sendRequest, settings);

        var response = await SendAsync(request);

        if (response is null)
            throw new Exception("Email server is not working.");

        return await response.ToSenderResponse();
    }

    private static HttpRequestMessage ToHttpRequest(SendEmailRequest sendRequest, SendgridOptions settings)
    {
        return new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(settings.RequestUri),
            Headers =
            {
                { settings.Headers.Key, settings.Headers.KeyValue },
                { settings.Headers.HostValue, settings.Headers.HostValue },
            },

            Content = new StringContent(
                        $@"
                {{
                    ""personalizations"": [
                        {{
                            ""to"": [
                                {{
                                    ""email"": ""{sendRequest.To}""
                                }}
                            ],
                            ""subject"": ""{sendRequest.Subject}""
                        }}
                    ],
                    ""from"": {{
                        ""email"": ""{sendRequest.From}""
                    }},
                    ""content"": [
                        {{
                            ""type"": ""text/plain"",
                            ""value"": ""{sendRequest.Body}""
                        }}
                    ]
                }}"
                        )
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue(settings.ContentType)
                }
            }
        };
    }
}
