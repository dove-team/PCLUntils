using System;
using PCLUntils.Untils;

namespace PCLUntils.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = "Hello World!".SetClipboard();
            Console.WriteLine("SetClipboard: " + result);
            Console.Read();
        }
    }
}