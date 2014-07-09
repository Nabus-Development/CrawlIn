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
