namespace NetChallenge.Application.Abstractions.Hubs
{
    public interface IOrderHubService
    {
        Task OrderAddMessage(string message);
    }
}
