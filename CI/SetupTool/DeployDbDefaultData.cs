using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CI.Model.Infrastructure;

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
