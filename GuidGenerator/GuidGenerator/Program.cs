internal class Program
{
	private static void Main()
	{
		Console.WriteLine("!GUID GENERATOR START!");
		Console.Write("How many Guids do you want to generate: ");
		try
		{
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
		catch (Exception)
		{
			Console.WriteLine("!ERROR!");
		}
		Console.WriteLine("!GUID GENERATOR END!");
		Console.ReadLine();
	}
}