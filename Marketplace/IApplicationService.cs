namespace Marketplace
{
    public interface IApplicationService
    {
        Task Handle(Object command);
    }
}
