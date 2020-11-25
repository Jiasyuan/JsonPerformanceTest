using System.Collections.Generic;
using System.Text.Json;
using JsonPerformanceTest.TestData;

namespace JsonPerformanceTest.TextJson
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = 10;
            string libraryName = "System.Text.Json";
            TestRunner.Run(times, libraryName, Serialize, Deserialize);

        }

        private static List<User> Deserialize(string inputString)
        {
            return JsonSerializer.Deserialize<List<User>>(inputString);
        }

        private static string Serialize(List<User> inputList)
        {
            return JsonSerializer.Serialize(inputList);
        }
    }
}
