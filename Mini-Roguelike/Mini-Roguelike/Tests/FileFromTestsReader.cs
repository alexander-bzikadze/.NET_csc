using System.IO;
using NUnit.Framework;

namespace Mini_Roguelike.Tests
{
    public class FileFromTestsReader
    {
        public static string GetFile(string s) 
            => Path.Combine(Path.Combine(TestContext.CurrentContext.TestDirectory, "../../Tests"), s);
    }
}