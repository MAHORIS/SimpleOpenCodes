using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleOpenCodes.Extensions;

namespace SimpleOpenCodes.Test.Extensions
{
    /// <summary>
    /// Test extension methods of the DateTime structure.
    /// </summary>
    [TestClass]
    public class DateTimeExtensionTest
    {
        [TestMethod]
        public void CopyTest()
        {
            var source = DateTime.Now;
            Console.WriteLine("Now: {0}", source.ToString());

            var props = new List<System.Reflection.PropertyInfo>();
            var propNames = new[] { "Ticks", "Year", "Month", "Day", "Hour", "Minute", "Second", "Millisecond", };
            foreach (var name in propNames)
            {
                foreach (var prop in typeof(DateTime).GetProperties())
                {
                    if (name.Equals(prop.Name)) props.Add(prop);
                }
            }

            var copied = source.Copy();
            Console.WriteLine("source.{0} [{1}] -> copied.{0} [{2}]", "ToString()", source.ToString(), copied.ToString());

            foreach (var prop in props)
            {
                Console.WriteLine("source.{0} [{1}] -> copied.{0} [{2}]", prop.Name, prop.GetValue(source), prop.GetValue(copied));
            }
            foreach (var prop in props)
            {
                Assert.AreEqual(prop.GetValue(source), prop.GetValue(copied));
            }
        }

        [TestMethod]
        public void GetBeginningOfTheYearTest()
        {
            var date = new DateTime(2016, 4, 13);
            var newDate = date.GetBeginningOfTheYear();
            Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
            Assert.AreEqual(newDate.Year, date.Year);
            Assert.AreEqual(newDate.Month, 1);
            Assert.AreEqual(newDate.Day, 1);
            Assert.AreEqual(newDate.Hour, 0);
            Assert.AreEqual(newDate.Minute, 0);
            Assert.AreEqual(newDate.Second, 0);
            Assert.AreEqual(newDate.Millisecond, 0);
        }

        [TestMethod]
        public void GetEndOfTheYearTest()
        {
            var date = new DateTime(2016, 4, 13);
            var newDate = date.GetEndOfTheYear();
            Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
            Assert.AreEqual(newDate.Year, date.Year);
            Assert.AreEqual(newDate.Month, 12);
            Assert.AreEqual(newDate.Day, 31);
            Assert.AreEqual(newDate.Hour, 0);
            Assert.AreEqual(newDate.Minute, 0);
            Assert.AreEqual(newDate.Second, 0);
            Assert.AreEqual(newDate.Millisecond, 0);
        }

        [TestMethod]
        public void GetBeginningOfTheMonthTest()
        {
            var date = new DateTime(2016, 4, 13);
            var newDate = date.GetBeginningOfTheMonth();
            Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
            Assert.AreEqual(newDate.Year, date.Year);
            Assert.AreEqual(newDate.Month, 4);
            Assert.AreEqual(newDate.Day, 1);
            Assert.AreEqual(newDate.Hour, 0);
            Assert.AreEqual(newDate.Minute, 0);
            Assert.AreEqual(newDate.Second, 0);
            Assert.AreEqual(newDate.Millisecond, 0);
        }

        [TestMethod]
        public void GetEndOfTheMonthTest()
        {
            var date = new DateTime(2016, 4, 13);
            var newDate = date.GetEndOfTheMonth();
            Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
            Assert.AreEqual(newDate.Year, date.Year);
            Assert.AreEqual(newDate.Month, 4);
            Assert.AreEqual(newDate.Day, 30);
            Assert.AreEqual(newDate.Hour, 0);
            Assert.AreEqual(newDate.Minute, 0);
            Assert.AreEqual(newDate.Second, 0);
            Assert.AreEqual(newDate.Millisecond, 0);
        }

        [TestMethod]
        public void GetBeginningOfTheWeekTest()
        {
            Enumerable.Range(10, 7).ToList().ForEach(day =>
            {
                var date = new DateTime(2016, 4, day);
                var newDate = date.GetBeginningOfTheWeek();
                Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
                Assert.AreEqual(newDate.Year, date.Year);
                Assert.AreEqual(newDate.Month, 4);
                Assert.AreEqual(newDate.Day, 10);
                Assert.AreEqual(newDate.Hour, 0);
                Assert.AreEqual(newDate.Minute, 0);
                Assert.AreEqual(newDate.Second, 0);
                Assert.AreEqual(newDate.Millisecond, 0);
            });
            Enumerable.Range(17, 7).ToList().ForEach(day =>
            {
                var date = new DateTime(2016, 4, day);
                var newDate = date.GetBeginningOfTheWeek();
                Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
                Assert.AreEqual(newDate.Year, date.Year);
                Assert.AreEqual(newDate.Month, 4);
                Assert.AreEqual(newDate.Day, 17);
                Assert.AreEqual(newDate.Hour, 0);
                Assert.AreEqual(newDate.Minute, 0);
                Assert.AreEqual(newDate.Second, 0);
                Assert.AreEqual(newDate.Millisecond, 0);
            });
        }

        [TestMethod]
        public void GetEndOfTheWeekTest()
        {
            Enumerable.Range(10, 7).ToList().ForEach(day =>
            {
                var date = new DateTime(2016, 4, day);
                var newDate = date.GetEndOfTheWeek();
                Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
                Assert.AreEqual(newDate.Year, date.Year);
                Assert.AreEqual(newDate.Month, 4);
                Assert.AreEqual(newDate.Day, 16);
                Assert.AreEqual(newDate.Hour, 0);
                Assert.AreEqual(newDate.Minute, 0);
                Assert.AreEqual(newDate.Second, 0);
                Assert.AreEqual(newDate.Millisecond, 0);
            });
            Enumerable.Range(17, 7).ToList().ForEach(day =>
            {
                var date = new DateTime(2016, 4, day);
                var newDate = date.GetEndOfTheWeek();
                Console.WriteLine("{0} -> {1}", date.ToString(), newDate.ToString());
                Assert.AreEqual(newDate.Year, date.Year);
                Assert.AreEqual(newDate.Month, 4);
                Assert.AreEqual(newDate.Day, 23);
                Assert.AreEqual(newDate.Hour, 0);
                Assert.AreEqual(newDate.Minute, 0);
                Assert.AreEqual(newDate.Second, 0);
                Assert.AreEqual(newDate.Millisecond, 0);
            });
        }
    }
}
