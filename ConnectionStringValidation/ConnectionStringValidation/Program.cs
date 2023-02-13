using Microsoft.Data.SqlClient;
using System.Data.Common;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("!CONNECTION STRING VALIDATION START!");
		try
		{
			using (SqlConnection conn = new("Data Source=luka\\MSSQL2022;Initial Catalog=KomisijaDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;User ID=uris;Password=uris"))
				conn.Open();
			Console.WriteLine("!SUCCESS!");
		}
		catch (Exception)
		{
			Console.WriteLine("!ERROR!");
		}
		Console.WriteLine("!CONNECTION STRING VALIDATION END!");
		Console.ReadKey();
	}
}