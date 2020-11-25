using System;
using System.Collections.Generic;
using System.Diagnostics;
using JsonPerformanceTest.TestData;
using Newtonsoft.Json;

namespace JsonPerformanceTest.JsonDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //隨機假造25萬筆User資料
            List<User> bigList = TestDataGenerator.CreateSerializedData();
            int indexToTest = 1024; //用來比對測試的筆數
            //序列化前取出第indexToTest筆資料的顯示內容
            string beforeSer = bigList[indexToTest].Display;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //將List<User> JSON化
            string json1 = JsonConvert.SerializeObject(bigList);
            sw.Stop();
            Console.WriteLine("Newtonsoft.Json");
            Console.WriteLine("Serialization: {0:N0}ms", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            //字串反序列化還原回List<User>

            //還原後一樣取出第indexToTest筆的User顯示內容
            string afterDeser = JsonConvert.DeserializeObject<List<User>>(json1)
                         [indexToTest].Display;

            sw.Stop();
            Console.WriteLine($"Deserialization: {sw.ElapsedMilliseconds:N0}ms");

            //比對還原後的資料是否相同
            Console.WriteLine($"Before: {beforeSer}");
            Console.WriteLine($"After: {afterDeser}");
            Console.WriteLine($"Pass Test: {beforeSer.Equals(afterDeser)}");
            Console.Read();
        }
    }
}
