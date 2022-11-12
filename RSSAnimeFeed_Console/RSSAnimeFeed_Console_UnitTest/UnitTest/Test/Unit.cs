using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RSSAnimeFeed_Console.UnitTest.Test
{
    [TestFixture]
    public class Unit
    {
        public Unit()
        {

        }

        [Test]
        public void Get42()
        {
            // arrange
            TestData test = new TestData();

            // act
            test.Get42();

            // assert
            int result = 42;
            Assert.That(test, Is.EqualTo(result));
        }
    }
}
