using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndaForceExtensions.com.andaforce.arazect.collections.linq;
using NUnit.Framework;

namespace AndaForceExtensionsTest.com.andaforce.arazect.collections.linq
{
    [TestFixture]
    public class ClonedLinqCompareMethodsTest
    {
        [Test]
        public static void TestMax()
        {
            var list = new List<float>() {1.0f, 2.0f, 3.0f};
            var result = list.ClonedMax();

            Assert.AreEqual(3.0f, result, "Error");

            Math.
        }

        [Test]
        public static void TestMin()
        {
            var list = new List<float>() { 1.0f, 2.0f, 3.0f };
            var result = list.ClonedMin();

            Assert.AreEqual(1.0f, result, "Error");
        }
    }
}
