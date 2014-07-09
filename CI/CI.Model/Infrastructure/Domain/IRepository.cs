
namespace CI.Model.Infrastructure.Domain
{
    public interface IRepository<in T> where T : IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
