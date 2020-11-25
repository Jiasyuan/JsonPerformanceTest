using System.Collections.Generic;
using JsonPerformanceTest.TestData;
using Newtonsoft.Json;

namespace JsonPerformanceTest.JsonDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = 10;
            string libraryName = "Newtonsoft.Json";
            TestRunner.Run(times, libraryName, Serialize, Deserialize);
        }

        private static List<User> Deserialize(string inputString)
        {
            return JsonConvert.DeserializeObject<List<User>>(inputString);
        }

        private static string Serialize(List<User> inputList)
        {
            return JsonConvert.SerializeObject(inputList);
        }
    }
}
