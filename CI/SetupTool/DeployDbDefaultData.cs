using System.Reflection;

namespace SetupTool
{
    public static class DeployDbDefaultData
    {
        public static void SaveDefaultData()
        {
            var dbDataCreator = new InitializeDbDefaultData();
            var methods = dbDataCreator.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var methodInfo in methods)
            {
                methodInfo.Invoke(dbDataCreator, new object[] { });
            }
        }
    }
}
