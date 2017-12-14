using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {

        private static void Tennivalo(object state)
        {
            System.Console.WriteLine("elindult a folyamat");
            Thread.Sleep(4000);
            System.Console.WriteLine("megállt a folyamat");
        }
        

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Tennivalo);
            ThreadPool.QueueUserWorkItem(Tennivalo);
            ThreadPool.QueueUserWorkItem(Tennivalo);
            ThreadPool.QueueUserWorkItem(Tennivalo);
            ThreadPool.QueueUserWorkItem(Tennivalo);
            ThreadPool.QueueUserWorkItem(Tennivalo);
            ThreadPool.QueueUserWorkItem(Tennivalo);

            Console.ReadLine();
        }
    }
}
