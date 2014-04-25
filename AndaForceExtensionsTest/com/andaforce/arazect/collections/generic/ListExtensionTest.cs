using System.Collections;
using System.Collections.Generic;
using AndaForceExtensions.com.andaforce.arazect.collections.generic;
using NUnit.Framework;

namespace AndaForceExtensionsTest.com.andaforce.arazect.collections.generic
{
    [TestFixture]
    public class ListExtensionTest
    {
        [Test]
        public void TestGetRandomItem()
        {
            var list = new List<int>() {1, 2, 3, 4, 5};
            var randomItem = list.GetRandomItem();

            Assert.IsTrue(list.Contains(randomItem), "Wrong item received");
        }

        [Test]
        public void TestGetOneItem()
        {
            var list = new List<int>() {123456789};

            Assert.AreEqual(123456789, list.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestEmpty()
        {
            var list = new List<int>();

            Assert.AreEqual(0, list.GetRandomItem(), "Wrong item received");
        }
    }
}