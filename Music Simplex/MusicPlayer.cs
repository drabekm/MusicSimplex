using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Windows.Media;

namespace Music_Simplex
{
    class MusicPlayer
    {
        MediaPlayer player = new MediaPlayer();

        public event EventHandler SongLoaded;

        public TimeSpan SongPosition { get; private set; }

        public MusicPlayer()
        {
            player.MediaOpened += MediaLoadedHandler;           
        }

        public void PlayTestMusic()
        {
            
            player.Open(new Uri("testmusic.mp3", UriKind.Relative));
            
            player.Play();
        }

        public double GetCurretnSongLenghtSeconds()
        {
            if(this.player.Source == null)
            {
                return 0;
            }

            return Math.Round(player.NaturalDuration.TimeSpan.TotalSeconds);            
        }

        public void SetSongPosition(double seconds)
        {
            this.player.Position = TimeSpan.FromSeconds(seconds);
        }

        public double GetSongPosition()
        {
            if (player.Source == null)
            {
                return 0;
            }

            return player.Position.TotalSeconds;
        }

        public void Pause()
        {
            if(player.CanPause)
            {
                player.Pause();
            }
        }

        public void Play()
        {
            player.Play();
        }

        private void MediaLoadedHandler(object sender, EventArgs e)
        {
            SongLoaded(this, e);
        }
    }
}
