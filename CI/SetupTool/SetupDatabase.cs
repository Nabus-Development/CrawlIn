using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Infrastructure.Configuration;
using CI.Repository.SessionStorage;

namespace SetupTool
{
    public static class SetupDatabase
    {
        public static void CreateDatabase()
        {
            PersistenceContext.CreateSchema();
        }

        public static void UpdateDatabase()
        {
            PersistenceContext.UpdateSchema();
        }
    }
}
