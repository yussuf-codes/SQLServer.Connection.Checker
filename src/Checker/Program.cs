using System.Data;

namespace Checker;

internal static class Program
{
    private static void Main(string[] args)
    {
        string connectionString = args[0];

        MSSQLDataProvider provider = new MSSQLDataProvider(connectionString);

        DataTable databases = provider.GetDatabases();

        for (int i = 0; i < databases.Rows.Count; i++)
        {
            System.Console.Write($"Id: {(int)databases.Rows[i]["id"]}");
            System.Console.Write('\t');
            System.Console.Write($"Name: {(string)databases.Rows[i]["name"]}");
            System.Console.Write(System.Environment.NewLine);
        }

        string version = provider.GetVersion();

        System.Console.WriteLine(version);
    }
}
