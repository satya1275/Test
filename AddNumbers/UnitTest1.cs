using NUnit.Framework;
using Solirus;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CommaSeparatedNumberTest()
        {
            string[] test = new string[] { "", "1,2", "4,5,6" };
            uint result = NumberAddition.AddString(test);
            Assert.AreEqual(result,18);
        }

        [Test]
        public void CommaAndNewLineSeparatedTest()
        {
            string[] test = new string[] { "", "\n1,2", "4\n5,6" };
            uint result = NumberAddition.AddString(test);
            Assert.AreEqual(result, 18);
        }

        [Test]
        public void NumbersWithCommaAndNewLineTogetherIgnored()
        {
            // 1\n,2 is ignored
            // Only 4+5+6 combination is considered
            string[] test = new string[] { "1\n,2", "4\n5,6" };
            uint result = NumberAddition.AddString(test);
            Assert.AreEqual(result, 15);
        }

        [Test]
        public void NegativeNunberTest()
        {
            string[] test = new string[] {  "-1\n2,3" };

            Assert.Throws<FormatException>(() => NumberAddition.AddString(test));
           
        }

        [Test]
        public void NumberGreaterThanThousand()
        {
            string[] test = new string[] { "", "1,2", "4\n5000,6" };
            uint result = NumberAddition.AddString(test);
            Assert.AreEqual(result, 13);
        }

        [Test]
        public void SingleDelimitersTest()
        {
            string[] test = new string[] { "//*\n1*2*3" };
            uint result = NumberAddition.AddString(test);
            Assert.AreEqual(result, 6);
        }

        [Test]
        public void MultipleDelimitersTest()
        {
            string[] test = new string[] { "//*%\n1*2%3" };
            uint result = NumberAddition.AddString(test);
            Assert.AreEqual(result, 6);
        }
    }
}