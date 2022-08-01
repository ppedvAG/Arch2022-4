using System.Data.Common;
using System.Data.SqlClient;

Console.WriteLine("Hello, Factory");

var conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";

DbProviderFactory factory;
if ("SQLSERVER" != "SQLSERVER")
    factory = System.Data.SqlClient.SqlClientFactory.Instance;
else
    factory = Npgsql.NpgsqlFactory.Instance;



DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();

DbCommand cmd = factory.CreateCommand();
cmd.CommandText = "SELECT * FROM Employees";
cmd.Connection = con;

DbDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"{reader.GetString(reader.GetOrdinal("FirstName"))}");
}

