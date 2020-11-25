using System;

namespace JsonPerformanceTest.TestData
{
    [Serializable]
    public class User
    {
        public Guid Id { get; set; }

        public DateTime RegDate { get; set; }

        public string Name { get; set; }

        public decimal Score { get; set; }

        public string Display

        {
            get
            {
                return string.Format("{0} / {1:yyyy-MM-dd} / {2:N0}", Name, RegDate, Score);
            }
        }
    }
}
