namespace AdvancedMVC2.Infrastructure.MVC.Commands
{
    public interface ICommandHandler<T>
    {
        void Execute(T message);
    }
}