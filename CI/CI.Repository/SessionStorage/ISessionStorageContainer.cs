using NHibernate;

namespace CI.Repository.SessionStorage
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}
