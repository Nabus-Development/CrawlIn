This utility is used for configuration of application's database.
It is console utility. They are input parameters(key=value):
1. root_directory="name of root directory, where you want to make changes"
2. set_connection_string="connection string for database" - set connection string in all
	*.config files in root_directory. Used only with root_directory.
3. create_database=True - create database and it's structure. Used only with set_connection_string parameter.
	Before starting this utility you must create database in sql server. If database structure is created
	this action will update structure of database.
4. update_database=True - update database structure. It is used only with set_connection_string.
	If you use create_database, this parameter is not required.

Recommended variant of call:
.\SetupTool\bin\Debug\SetupTool.exe root_directory="." set_connection_string="server=.\SQLEXPRESS;Initial Catalog=CrawlIn;Integrated Security=True" create_database=True