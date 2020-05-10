using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Music_Simplex.CustomControls
{
    /// <summary>
    /// Interaction logic for AutoPlayer.xaml
    /// </summary>
    public partial class AutoPlayer : UserControl
    {
        private string baseMusicFolder;
        private List<SongsDTO> songsDTOs;
        private List<string> musicFolders;
        public AutoPlayer()
        {
            InitializeComponent();
            songsDTOs = new List<SongsDTO>();
            musicFolders = new List<string>();

            baseMusicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);


            LoadMusic(baseMusicFolder);
            foreach(var songsDTO in songsDTOs)
            {
                lstbMusicFolders.Items.Add(songsDTO.GroupName);
            }
        }

        private void LoadMusic(string currentDirectory)
        {
            musicFolders.AddRange(Directory.GetDirectories(currentDirectory));

            GetSongsFromDirectory(currentDirectory);

            
            musicFolders.Remove(currentDirectory);

            string nextDirectory = musicFolders.FirstOrDefault();

            if(nextDirectory != null)
            {
                LoadMusic(nextDirectory);
            }
            return;
        }

        private void GetSongsFromDirectory(string directory)
        {
            var directoryParts = directory.Split('\\');
            SongsDTO songsDTO = new SongsDTO(directoryParts[directoryParts.Length - 1]);
            songsDTO.AddSongs(Directory.GetFiles(directory, "*.mp3"));
            songsDTOs.Add(songsDTO);
        }
    }
}
