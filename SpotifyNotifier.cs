using SpotifyNotifierConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyNotifier
{
    public class SpotifyNotifier
    {
        private readonly SpotifyCaller _spotifyCaller;

        public SpotifyNotifier(String clientId, String clientSecret)
        {
            _spotifyCaller = new SpotifyCaller(clientId, clientSecret);
        }

        public void getAlbums(String artistName)
        {
            artistName.Replace(' ', '+');
            _spotifyCaller.findAlbums(artistName);
        }
    }
}
