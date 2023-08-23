using Shop.Application.Emails.Models;

namespace Shop.Application.Helpers;

public static class HttpHelper
{
    public static Task<SenderResponse> ToSenderResponse(this HttpResponseMessage response)
    {
        using (response)
        {
            var emailResponse = new SenderResponse
            {
                StatusCode = (int)response.StatusCode
            };

            try
            {
                response.EnsureSuccessStatusCode();
                emailResponse.IsSuccess = true;
                emailResponse.ExceptionMessage = string.Empty;
            }
            catch (Exception ex)
            {
                emailResponse.IsSuccess = false;
                emailResponse.ExceptionMessage = ex.Message;
            }

            return Task.FromResult(emailResponse);
        }
    }
}
