using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Infrastructure.Domain;
using CI.Model.Infrastructure.UnitOfWork;
using CI.Repository.SessionStorage;
using NHibernate;

namespace CI.Repository
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            PersistenceContext.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            PersistenceContext.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            PersistenceContext.GetCurrentSession().Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction = PersistenceContext.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
