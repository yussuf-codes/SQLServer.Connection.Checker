using System.Data;

namespace Tester;

internal static class Program
{
    private static void Main(string[] args)
    {
        string connectionString = args[0];

        MSSQLConnectionTester tester = new MSSQLConnectionTester(connectionString);

        DataTable databases = tester.GetDatabases();

        for (int i = 0; i < databases.Rows.Count; i++)
        {
            System.Console.Write($"Id: {(int)databases.Rows[i]["id"]}");
            System.Console.Write('\t');
            System.Console.Write($"Name: {(string)databases.Rows[i]["name"]}");
            System.Console.Write(System.Environment.NewLine);
        }

        string version = tester.GetVersion();

        System.Console.WriteLine(version);
    }
}
