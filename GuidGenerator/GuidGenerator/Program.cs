using System.Text.RegularExpressions;

enum Ses { ADMIN, KOMISIJA, OPERATER, LICITANT }

internal class Program
{
	private static void Main()
	{
		Console.WriteLine("!GUID GENERATOR START!");
		try
		{
			Console.Write("How many Guids do you want to generate: ");
			string? s = Console.ReadLine();
			if (s != null)
			{
				int n = int.Parse(s);
				for (int i = 0; i < n; i++)
				{
					Console.WriteLine(Guid.NewGuid().ToString());
				}
			}
		}
		catch (Exception exception)
		{
			Console.WriteLine("!ERROR!");
			Console.WriteLine(exception.Message);
		}
		Console.WriteLine("!GUID GENERATOR END!");
		Console.ReadLine();
	}
}