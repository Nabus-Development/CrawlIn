using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CI.Model.Infrastructure.Configuration;
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

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageContainerFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }

        public static void CreateSchema()
        {
            SchemaExport schemaExport = new SchemaExport(GetNHibernateConfiguration());

            schemaExport.Execute(false, true, false);
        }

        public static void UpdateSchema()
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(GetNHibernateConfiguration());

            schemaUpdate.Execute(false, true);
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();

            return _sessionFactory;
        }

        private static Configuration GetNHibernateConfiguration()
        {
            if (_nhibernateConfiguration == null)
                Init();

            return _nhibernateConfiguration;
        }

        private static void Init()
        {
            string connectionString = ApplicationSettingsFactory.GetApplicationSettings().ConnectionString;

            var databaseConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);

            _nhibernateConfiguration = Fluently.Configure()
                .Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IApplicationSettings>())
                .BuildConfiguration();

            // tell NHibernate to quote columns with reserved names like "Order"
            // note it affects all queries, not only a schema updater
            SchemaMetadataUpdater.QuoteTableAndColumns(_nhibernateConfiguration);

            _sessionFactory = _nhibernateConfiguration.BuildSessionFactory();
        }
    }
}
