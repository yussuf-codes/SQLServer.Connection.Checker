using System.Data;
using Microsoft.Data.SqlClient;

namespace SQLServer;

static class SqlClient
{
    public static DataTable GetDatabases(string connectionString)
    {
        DataTable databasesTable = new DataTable();
        string selectDatabases = "SELECT database_id AS id, name FROM sys.databases;";
        using SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(selectDatabases, sqlConnection);
            sqlConnection.Open();
            using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(databasesTable);
            sqlConnection.Close();
        return databasesTable;
    }

    public static string GetVersion(string connectionString)
    {
        string selectVersion = "SELECT @@VERSION;";
        using SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(selectVersion, sqlConnection);
            sqlConnection.Open();
            string version = (string)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
        return version;
    }
}

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=master;User Id=sa;Password=Pa$$word;TrustServerCertificate=true;";
        DataTable databases = SqlClient.GetDatabases(connectionString);
        for (int i = 0; i < databases.Rows.Count; i++)
        {
            Console.Write($"Id: {(int)databases.Rows[i]["id"]}");
            Console.Write('\t');
            Console.Write($"Name: {(string)databases.Rows[i]["name"]}");
            Console.Write('\n');
        }

        string version = SqlClient.GetVersion(connectionString);
        Console.WriteLine(version);
    }
}
