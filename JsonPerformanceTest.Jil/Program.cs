using System;
using System.Collections.Generic;
using System.Diagnostics;
using Jil;
using JsonPerformanceTest.TestData;

namespace JsonPerformanceTest.Jil
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
            string json1 = JSON.Serialize(bigList, Options.ISO8601);
            sw.Stop();
            Console.WriteLine("Jil");
            Console.WriteLine($"Serialization: {sw.ElapsedMilliseconds:N0}ms");
            sw.Reset();
            sw.Start();
            //字串反序列化還原回List<User>

            //還原後一樣取出第indexToTest筆的User顯示內容
            string afterDeser = JSON.Deserialize<List<User>>(json1, Options.ISO8601)
                         [indexToTest].Display;

            sw.Stop();
            Console.WriteLine($"Deserialization: {sw.ElapsedMilliseconds:N0}ms");

            //比對還原後的資料是否相同
            Console.WriteLine($"Before: {beforeSer}");
            Console.WriteLine($"After: {afterDeser}");
            Console.WriteLine($"Pass Test: {beforeSer.Equals(afterDeser)}");
            Console.Read();
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
