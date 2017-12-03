using System;
using System.IO;
using System.Reflection;

namespace MyNUnit
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    foreach (var line in new TestRunner(arg).RunTests())
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("No assemblies to test!");
            }
        }
    }
}