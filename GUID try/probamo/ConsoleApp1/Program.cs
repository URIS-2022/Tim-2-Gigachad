using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Milan Maglov\\Desktop\\GUID try\\txt guid\\guid.txt";
            Console.WriteLine(filePath);

            List<Guid> guids = new List<Guid>();
            Console.WriteLine("Koliko guida?");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(a);
            List<string> s = new List<string>();

            for (int i = 0; i < a; i++)
            {
                Guid guid = Guid.NewGuid();
                guids.Add(guid);
                s.Add(guid.ToString());
            }

            foreach (string guid in s)
            {
                Console.WriteLine(guid);
            }

            File.WriteAllLines(filePath, s);
        }
    }
}
