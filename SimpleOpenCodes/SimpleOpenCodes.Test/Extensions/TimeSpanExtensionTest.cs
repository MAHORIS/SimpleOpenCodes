using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleOpenCodes.Extensions;

namespace SimpleOpenCodes.Test.Extensions
{
    /// <summary>
    /// Test extension methods of the TimeSpan structure.
    /// </summary>
    [TestClass]
    public class TimeSpanExtensionTest
    {
        [TestMethod]
        public void CopyTest()
        {
            var randomer = new Random();
            var days = randomer.Next(30);
            var hours = randomer.Next(24);
            var minutes = randomer.Next(60);
            var seconds = randomer.Next(60);
            var milliseconds = randomer.Next(1000);
            var source = new TimeSpan(days, hours, minutes, seconds, milliseconds);
            Console.WriteLine("Source: {0}", source.ToString());

            var props = new List<System.Reflection.PropertyInfo>();
            var propNames = new[] { "Ticks", "Days", "Hours", "Minutes", "Seconds", "Milliseconds", };
            foreach (var name in propNames)
            {
                foreach (var prop in typeof(TimeSpan).GetProperties())
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
        public void RoundDownTest()
        {
            TimeSpan source, threshold, expected, rounded;
            threshold = new TimeSpan(0, 0, 15, 0, 0);

            // 0.00:00:00.000 -> 0.00:00:00.000
            source = new TimeSpan(0, 0, 0, 0, 0);
            expected = new TimeSpan(0, 0, 0, 0, 0);
            rounded = source.RoundDown(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:01:00.000 -> 0.00:00:00.000
            source = new TimeSpan(0, 0, 1, 0, 0);
            expected = new TimeSpan(0, 0, 0, 0, 0);
            rounded = source.RoundDown(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:14:59.999 -> 0.00:00:00.000
            source = new TimeSpan(0, 0, 14, 59, 999);
            expected = new TimeSpan(0, 0, 0, 0, 0);
            rounded = source.RoundDown(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:15:00.000 -> 0.00:15:00.000
            source = new TimeSpan(0, 0, 15, 0, 0);
            expected = new TimeSpan(0, 0, 15, 0, 0);
            rounded = source.RoundDown(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:29:59.999 -> 0.00:15:00.000
            source = new TimeSpan(0, 0, 29, 59, 999);
            expected = new TimeSpan(0, 0, 15, 0, 0);
            rounded = source.RoundDown(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:59:59.999 -> 0.00:45:00.000
            source = new TimeSpan(0, 0, 59, 59, 999);
            expected = new TimeSpan(0, 0, 45, 0, 0);
            rounded = source.RoundDown(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.01:00:00.000 -> 0.01:00:00.000
            source = new TimeSpan(0, 1, 0, 0, 0);
            expected = new TimeSpan(0, 1, 0, 0, 0);
            rounded = source.RoundDown(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);
        }

        [TestMethod]
        public void RoundUpTest()
        {
            TimeSpan source, threshold, expected, rounded;
            threshold = new TimeSpan(0, 0, 15, 0, 0);

            // 0.00:00:00.000 -> 0.00:00:00.000
            source = new TimeSpan(0, 0, 0, 0, 0);
            expected = new TimeSpan(0, 0, 0, 0, 0);
            rounded = source.RoundUp(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:01:00.000 -> 0.00:15:00.000
            source = new TimeSpan(0, 0, 1, 0, 0);
            expected = new TimeSpan(0, 0, 15, 0, 0);
            rounded = source.RoundUp(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:14:59.999 -> 0.00:15:00.000
            source = new TimeSpan(0, 0, 14, 59, 999);
            expected = new TimeSpan(0, 0, 15, 0, 0);
            rounded = source.RoundUp(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:15:00.000 -> 0.00:15:00.000
            source = new TimeSpan(0, 0, 15, 0, 0);
            expected = new TimeSpan(0, 0, 15, 0, 0);
            rounded = source.RoundUp(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:29:59.999 -> 0.00:30:00.000
            source = new TimeSpan(0, 0, 29, 59, 999);
            expected = new TimeSpan(0, 0, 30, 0, 0);
            rounded = source.RoundUp(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.00:59:59.999 -> 0.01:00:00.000
            source = new TimeSpan(0, 0, 59, 59, 999);
            expected = new TimeSpan(0, 1, 0, 0, 0);
            rounded = source.RoundUp(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);

            // 0.01:00:00.000 -> 0.01:00:00.000
            source = new TimeSpan(0, 1, 0, 0, 0);
            expected = new TimeSpan(0, 1, 0, 0, 0);
            rounded = source.RoundUp(threshold);
            Console.WriteLine("[{0}] -> [{1}] expected:[{2}]", source.ToString(), rounded.ToString(), expected.ToString());
            Assert.AreEqual(rounded, expected);
        }
    }
}
