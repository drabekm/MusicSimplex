using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Simplex
{
    class SongsDTO
    {
        public string GroupName { get; private set; }
        public List<string> SongPaths { get; private set; }
        public SongsDTO(string songGroupName)
        {
            GroupName = songGroupName;
            SongPaths = new List<string>();
        }

        public void AddSong(string songPath)
        {
            SongPaths.Add(songPath);
        }

        public void AddSongs(string[] songPaths)
        {
            SongPaths.AddRange(songPaths);
        }

    }
}
