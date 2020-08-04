using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25))
            }; 

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        #region New tests

        [TestMethod]
        public void TestWeekendBeforeStart()
        {
            DateTime startDate = new DateTime(2017, 4, 10);
            int count = 7;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 7), new DateTime(2017, 4, 9)),
                new WeekEnd(new DateTime(2017, 4, 13), new DateTime(2017, 4, 14))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 18)));
        }

        [TestMethod]
        public void TestStartOnWeekend()
        {
            DateTime startDate = new DateTime(2017, 4, 10);
            int count = 7;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 8), new DateTime(2017, 4, 12)),
                new WeekEnd(new DateTime(2017, 4, 17), new DateTime(2017, 4, 18))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 21)));
        }

        [TestMethod]
        public void TestConsecutiveWeekends()
        {
            DateTime startDate = new DateTime(2017, 4, 10);
            int count = 7;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 13), new DateTime(2017, 4, 15)),
                new WeekEnd(new DateTime(2017, 4, 16), new DateTime(2017, 4, 17))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 21)));
        }

        [TestMethod]
        public void TestZeroDaysCount()
        {
            DateTime startDate = new DateTime(2017, 4, 10);
            int count = 0;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 13), new DateTime(2017, 4, 15)),
                new WeekEnd(new DateTime(2017, 4, 16), new DateTime(2017, 4, 17))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(startDate));
        }

        #endregion
    }
}
