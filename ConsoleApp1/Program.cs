using System;
using System.Threading;
using System.Threading.Channels;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int a = 1;
            int b = 5;

            // a 改变前为1
            int result1 = Interlocked.Exchange(ref a, 2);

            Console.WriteLine($"a新的值 a = {a}   |  a改变前的值 result1 = {result1}");

            Console.WriteLine();

            // a 改变前为 2，b 为 5
            int result2 = Interlocked.Exchange(ref a, b);

            Console.WriteLine($"a新的值 a = {a}   | b不会变化的  b = {b}   |   a 之前的值  result2 = {result2}");
        }


    }
}
