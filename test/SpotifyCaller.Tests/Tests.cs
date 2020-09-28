using NUnit.Framework;
using System;
using System.Collections.Generic;
using SpotifyCaller;

namespace SpotifyCallerTests
{
    [TestFixture]
    public class Tests
    {
        private SpotifyCaller.SpotifyCaller _caller;

        [SetUp]
        public void Setup()
        {
            IEnumerator<string> apiIdSecret = System.IO.File.ReadLines(@"C:\Users\Andrew\source\repos\SpotifyCaller\testKeys.txt").GetEnumerator();
            apiIdSecret.MoveNext();
            string clientId = apiIdSecret.Current;
            apiIdSecret.MoveNext();
            string clientSecret = apiIdSecret.Current;

            _caller = new SpotifyCaller.SpotifyCaller(clientId, clientSecret);
        }

        [Test]
        public void TestGetAlbums()
        {
            List<Album> albums = _caller.FindAlbums("Pink Floyd");
            List<string> albumNames = albums.ConvertAll((Album a) => { return a.Name; });

            Assert.Contains("Animals", albumNames);
        }
    }
}