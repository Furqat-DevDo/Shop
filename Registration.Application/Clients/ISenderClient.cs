namespace Registration.Application.Clients;

public interface ISenderClient<TResponse, TRequest>
{
    Task<TResponse> SendAsync(TRequest request);
}
