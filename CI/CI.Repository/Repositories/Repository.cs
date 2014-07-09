using CI.Model.Infrastructure.Domain;
using CI.Model.Infrastructure.UnitOfWork;
using CI.Repository.SessionStorage;

namespace CI.Repository.Repositories
{
    public abstract class Repository<T> where T : IAggregateRoot
    {
        private IUnitOfWork _unitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            PersistenceContext.GetCurrentSession().Save(entity);
        }

        public void Remove(T entity)
        {
            PersistenceContext.GetCurrentSession().Delete(entity);
        }

        public void Save(T entity)
        {
            PersistenceContext.GetCurrentSession().SaveOrUpdate(entity);
        }
    }
}
