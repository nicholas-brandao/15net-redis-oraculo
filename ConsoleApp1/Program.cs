using StackExchange.Redis;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");

            //IDatabase db = connection.GetDatabase();
            //// Get/Set
            //db.StringSet("abc", "1");
            //var value = db.StringGet("abc");

            var sub = connection.GetSubscriber();

            sub.Subscribe("Perguntas", (ch, msg) =>
            {

                IDatabase redis = connection.GetDatabase();
                redis.HashSet("P1", "Grupo-Nicholas", "Brasilia");

            });

            Console.ReadLine();
            //while (true)
            //{
            //    Console.WriteLine();
            //    string linha = Console.ReadLine();
            //    pub.Publish("net15", "Hello World");
            //}


        }
    }
}
