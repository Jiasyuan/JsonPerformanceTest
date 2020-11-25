using System;
using System.Collections.Generic;
using Jil;
using JsonPerformanceTest.TestData;

namespace JsonPerformanceTest.Jil
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = 10;
            string libraryName = "Jil";
            TestRunner.Run(times, libraryName, Serialize, Deserialize);
        }

        private static List<User> Deserialize(string inputString)
        {
            return JSON.Deserialize<List<User>>(inputString, Options.ISO8601);
        }

        private static string Serialize(List<User> inputList)
        {
            return JSON.Serialize(inputList, Options.ISO8601);
        }

        private static void JilDateTime()
        {
            var dt = DateTime.Now;

            Console.WriteLine(JSON.Serialize(dt));
            Console.WriteLine(JSON.Deserialize<DateTime>(JSON.Serialize(dt)).ToLocalTime());
            Console.Read();
        }
    }
}
