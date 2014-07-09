using System;
using System.IO;
using System.Xml;

namespace SetupTool
{
    public static class SetConnectionString
    {
        public static void Execute(string rootDirectoryName, string connectionString)
        {
            // Get all config files
            Console.WriteLine("Root directory is {0}", rootDirectoryName);
            var rootDirectory = new DirectoryInfo(rootDirectoryName);

            // Replace connection string in config files
            foreach (var file in rootDirectory.GetFiles("*.config", SearchOption.AllDirectories))
            {
                var doc = new XmlDocument();
                Console.WriteLine("Processing configuration file {0}", file.FullName);

                try
                {
                    // Load config file
                    doc.Load(file.FullName);
                }
                catch (XmlException exception)
                {
                    Console.WriteLine("Error loading xml document: {0}", exception);
                    continue;
                }

                // Select nodes where said about connection string
                var nodes = doc.SelectNodes(@"/configuration/connectionStrings/add");

                // If this nodes exist
                if (nodes != null)
                {
                    // Edit all selected nodes
                    foreach (XmlElement element in nodes)
                    {
                        Console.WriteLine("Found element {0}", element.Name);

                        // Take attribute connectionString from node
                        var connectionAttribute = element.Attributes["connectionString"];
                        if (connectionAttribute != null)
                        {
                            // Replace provider connection string in EF connection string
                            var previousString = connectionAttribute.InnerText;
                            Console.WriteLine("Old EF connection is {0}", previousString);

                            // Write new connection string
                            connectionAttribute.InnerText = connectionString;
                            Console.WriteLine("Set connectionString to {0}", connectionString);
                        }
                    }

                    // Save config file
                    doc.Save(file.FullName);
                }
            }
        }
    }
}
