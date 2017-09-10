using System;

namespace CL
{
    class CL
    {
        static void Main(string[] args)
        {
            var t = new Trie.Trie();
            t.Add("12");
            t.Add("123");
            t.Add("13");
            t.Remove("13");
            Console.WriteLine("{0}, {1}", t.Size(), t.HowManyStartsWithPrefix("1")) ;
            Console.WriteLine("Hello World!");
        }
    }
}
