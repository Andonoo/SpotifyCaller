using NUnit.Framework;
using System;
using System.Collections.Generic;
using SpotifyCaller;

namespace SpotifyCallerTests
{
    public class Tests
    {
        private SpotifyCaller.SpotifyCaller _caller;

        [SetUp]
        public void Setup()
        {
            IEnumerator<string> apiIdSecret = System.IO.File.ReadLines(@"C:\Users\Andrew\source\repos\SpotifyCaller\testKeys.txt").GetEnumerator();
            string clientId = apiIdSecret.Current;
            apiIdSecret.MoveNext();
            string clientSecret = apiIdSecret.Current;

            _caller = new SpotifyCaller.SpotifyCaller(clientId, clientSecret);
        }

        [Test]
        public void Test1()
        {
            List<Album> result = _caller.FindAlbums("Pink Floyd");
            Assert.IsNotEmpty(result);
        }
    }
}