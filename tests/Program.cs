using System;
using System.Diagnostics;

namespace GameComponents.Tests
{
    static class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            var tests = new GameObjectStressTests();

            timer.Start();
            tests.GetComponents1PerObject();
            Console.WriteLine("1 per object: {0}ms", timer.ElapsedMilliseconds);

            timer.Restart();
            tests.GetComponents10PerObject();
            Console.WriteLine("10 per object: {0}ms", timer.ElapsedMilliseconds);

            timer.Restart();
            tests.GetComponents100PerObject();
            Console.WriteLine("100 per object: {0}ms", timer.ElapsedMilliseconds);

            timer.Stop();

            Console.ReadKey();
        }
    }
}
