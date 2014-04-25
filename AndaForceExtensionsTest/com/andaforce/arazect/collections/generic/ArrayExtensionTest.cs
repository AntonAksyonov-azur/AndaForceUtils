using System.Linq;
using AndaForceExtensions.com.andaforce.arazect.collections.generic;
using NUnit.Framework;

namespace AndaForceExtensionsTest.com.andaforce.arazect.collections.generic
{
    [TestFixture]
    public class ArrayExtensionTest
    {
        [Test]
        public void TestGetRandomItem()
        {
            var array = new[] {1, 2, 3, 4, 5, 6};
            var randomItem = array.GetRandomItem();

            Assert.IsTrue(array.Contains(randomItem), "Wrong item received");
        }

        [Test]
        public void TestGetOneItem()
        {
            var array = new[] {123456789};

            Assert.AreEqual(123456789, array.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestEmpty()
        {
            var array = new int[0];

            Assert.AreEqual(0, array.GetRandomItem(), "Wrong item received");
        }
    }
}