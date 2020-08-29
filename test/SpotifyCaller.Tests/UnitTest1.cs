using NUnit.Framework;

namespace SpotifyCaller.Tests
{
    public class Tests
    {
        private SpotifyCaller _caller;

        [SetUp]
        public void Setup()
        {
            _caller = new SpotifyCaller();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}