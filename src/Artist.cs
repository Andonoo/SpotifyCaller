using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpotifyCaller
{
    class Artist
    {
        private readonly string _name;
        private readonly List<Album> _albums;

        public Artist(string name)
        {
            _name = name;
            _albums = new List<Album>();
        }

        public void addAlbums(Collection<Album> albums)
        {
            _albums.AddRange(albums);
        }
    }
}
