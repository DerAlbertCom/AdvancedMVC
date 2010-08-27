namespace AdvancedMVC2.Infrastructure.Repositories
{
    public interface IDatabaseTransaction 
    {
        void BeginTransaction();
        void EndTransaction();
        void ExceptionWhileTransaction();
    }
}