using System.Data;
using Microsoft.Data.SqlClient;

namespace Tester;

internal class MSSQLConnectionTester
{
    private readonly string _connectionString;

    public MSSQLConnectionTester(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable GetDatabases()
    {
        DataTable databases = new DataTable();
        string selectDatabasesQuery = "SELECT database_id AS id, name FROM sys.databases;";
        using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        SqlCommand sqlCommand = new SqlCommand(selectDatabasesQuery, sqlConnection);
        sqlConnection.Open();
        using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        sqlDataAdapter.Fill(databases);
        sqlConnection.Close();
        return databases;
    }

    public string GetVersion()
    {
        string selectVersionQuery = "SELECT @@VERSION;";
        using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        SqlCommand sqlCommand = new SqlCommand(selectVersionQuery, sqlConnection);
        sqlConnection.Open();
        string version = (string)sqlCommand.ExecuteScalar();
        sqlConnection.Close();
        return version;
    }
}
