using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetupTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Application is starting.");

                // No parameters. No jobs
                if (!args.Any())
                {
                    Console.WriteLine("Appliction started without parameters. End of work.");

                    Console.ReadLine();

                    return;
                }

                // Make from parameters dictionary
                var parameters = new Dictionary<string, string>();

                foreach (var arg in args)
                {
                    int pos = arg.IndexOf('=');
                    if (pos != -1)
                    {
                        string key = arg.Substring(0, pos);
                        string value = arg.Substring(pos + 1);

                        parameters[key] = value;
                    }
                }

                // Take values of parameters from dictionary
                string rootDirectory, connectionString, createDatabase, updateDatabase;

                parameters.TryGetValue("root_directory", out rootDirectory);
                parameters.TryGetValue("set_connection_string", out connectionString);
                parameters.TryGetValue("create_database", out createDatabase);
                parameters.TryGetValue("update_database", out updateDatabase);

                // Try write connection string to config files
                if (!String.IsNullOrEmpty(rootDirectory))
                {
                    if (!String.IsNullOrEmpty(connectionString))
                    {
                        Console.WriteLine("Writing connection string: \n {0} \n to all config files in root directory:\n {1}", connectionString, rootDirectory);

                        SetConnectionString.Execute(rootDirectory, connectionString);

                        Console.WriteLine("New connection string is set.");
                    }
                    else
                        Console.WriteLine("Can not write connection string to config files. Invalid parameters.");
                }

                // Create database
                if (!string.IsNullOrEmpty(createDatabase))
                {
                    if (createDatabase.ToLower().Trim() == "true")
                    {
                        if (!String.IsNullOrEmpty(connectionString))
                        {
                            Console.WriteLine("Creation database with the connection string:\n {0}", connectionString);

                            SetupDatabase.CreateDatabase(connectionString);

                            Console.WriteLine("Database creation is finished.");
                        }
                        else
                            Console.WriteLine("Error. Connection string not specified for database creation.");
                    }
                }

                // Update database
                if (!string.IsNullOrEmpty(updateDatabase) && string.IsNullOrEmpty(createDatabase))
                {
                    if (updateDatabase.ToLower().Trim() == "true")
                    {
                        if (!String.IsNullOrEmpty(connectionString))
                        {
                            Console.WriteLine("Updating database with the connection string:\n {0}", connectionString);

                            SetupDatabase.UpdateDatabase(connectionString);

                            Console.WriteLine("Database updating is finished.");
                        }
                        else
                            Console.WriteLine("Error. Connection string not specified for database updating.");
                    }
                }

                // Insert default data in database
                DeployDbDefaultData.SaveDefaultData();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error. Try again.\n {0}", exception);
            }
        }
    }
}
