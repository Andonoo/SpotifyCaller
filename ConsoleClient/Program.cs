using SpotifyCaller;
using System;
using System.Collections.Generic;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerator<string> apiIdSecret = System.IO.File.ReadLines(@"C:\Users\Andrew\source\repos\SpotifyCaller\testKeys.txt").GetEnumerator();
            apiIdSecret.MoveNext();
            string clientId = apiIdSecret.Current;
            apiIdSecret.MoveNext();
            string clientSecret = apiIdSecret.Current;

            SpotifyCaller.SpotifyCaller _caller = new SpotifyCaller.SpotifyCaller(clientId, clientSecret);

            List<Album> result = _caller.FindAlbums("Pink Floyd");

            foreach (Album album in result)
            {
                Console.WriteLine("Name: " + album.Name);
                Console.WriteLine("Id: " + album.Id);
            }
        }
    }
}
