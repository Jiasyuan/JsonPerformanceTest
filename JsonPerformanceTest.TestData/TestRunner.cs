using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JsonPerformanceTest.TestData
{
    public static class TestRunner
    {
        public static void Run(int times, string libraryName, Func<List<User>, string> serializeFunc,
            Func<string, List<User>> deserializeFunc)
        {
            List<PerformanceTestData> performanceDataList = new List<PerformanceTestData>();
            for (int i = 0; i < times; i++)
            {
                performanceDataList.Add(PerformanceTest(libraryName, serializeFunc, deserializeFunc));
            }

            long allSerializationMs =0, allDeserializationMs=0;
            performanceDataList.ForEach(e =>
            {
                allSerializationMs += e.SerializeMS;
                allDeserializationMs += e.DeserializeMS;
            });
            Console.WriteLine(libraryName);
            Console.WriteLine($"Average Serialization: {allSerializationMs/times:N0}ms");
            Console.WriteLine($"Average Deserialization: {allDeserializationMs / times:N0}ms");
            Console.Read();

        }

        private static PerformanceTestData PerformanceTest(string libraryName, Func<List<User>, string> serializeFunc,
            Func<string, List<User>> deserializeFunc)
        {
            //隨機假造25萬筆User資料
            List<User> bigList = TestDataGenerator.CreateSerializedData();

            int indexToTest = 1024; //用來比對測試的筆數
            //序列化前取出第indexToTest筆資料的顯示內容
            string beforeSer = bigList[indexToTest].Display;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //將List<User> JSON化
            string json1 = serializeFunc(bigList);
            sw.Stop();
            Console.WriteLine(libraryName);
            long serializationMs = sw.ElapsedMilliseconds;
            Console.WriteLine($"Serialization: {serializationMs:N0}ms");
            sw.Reset();
            sw.Start();

            //反序列
            string afterDeser = deserializeFunc(json1)
                [indexToTest].Display;

            sw.Stop();
            long deserializationMs = sw.ElapsedMilliseconds;
            Console.WriteLine($"Deserialization: {deserializationMs:N0}ms");

            //比對還原後的資料是否相同
            Console.WriteLine($"Before: {beforeSer}");
            Console.WriteLine($"After: {afterDeser}");
            Console.WriteLine($"Pass Test: {beforeSer.Equals(afterDeser)}");
            Console.WriteLine("");
            return new PerformanceTestData()
            {
                SerializeMS = serializationMs,
                DeserializeMS = deserializationMs
            };
        }
    }
}
