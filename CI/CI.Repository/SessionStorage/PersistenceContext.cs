using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CI.Repository.SessionStorage
{
    public class PersistenceContext
    {
        private static Configuration _nhibernateConfiguration;

        private static ISessionFactory _sessionFactory;

        public static void Initialize(string connectionString)
        {
            var databaseConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);

            _nhibernateConfiguration = Fluently.Configure()
                .Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersistenceContext>())
                .BuildConfiguration();

            // tell NHibernate to quote columns with reserved names like "Order"
            // note it affects all queries, not only a schema updater
            SchemaMetadataUpdater.QuoteTableAndColumns(_nhibernateConfiguration);

            _sessionFactory = _nhibernateConfiguration.BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }

        private static ISession GetNewSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
