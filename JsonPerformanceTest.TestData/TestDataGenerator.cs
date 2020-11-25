using System;
using System.Collections.Generic;

namespace JsonPerformanceTest.TestData
{
    public static class TestDataGenerator
    {
        public static List<User> CreateSerializedData()
        {
            return GenSimData();
        }


        private static List<User> GenSimData()
        {
            List<User> lst = new List<User>();
            Random rnd = new Random();
            for (int i = 0; i < 250000; i++)
            {
                lst.Add(new User()
                {
                    Id = Guid.NewGuid(),
                    RegDate = DateTime.Today.AddDays(-rnd.Next(5000)),
                    Name = $"User{i}",
                    Score = rnd.Next(10000, 65535)
                });
            }
            return lst;
        }
    }
}
