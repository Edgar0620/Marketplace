namespace Marketplace
{
    public interface IHandleCommand<in T>
    {
        Task Handle(T command);
    }
}
