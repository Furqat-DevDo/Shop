namespace Shop.Application.Clients;

public interface ISenderClient
{
    Task <T1> SendAsync<T1,T2>(T2 message);
}