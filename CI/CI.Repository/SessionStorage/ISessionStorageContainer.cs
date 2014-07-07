using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace CI.Repository.SessionStorage
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}
