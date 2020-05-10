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


namespace Music_Simplex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        MusicPlayer musicPlayer = new MusicPlayer();

        public MainWindow()
        {
            InitializeComponent();
            

            AssignHandlersToUIControlEvents();

            musicPlayer.SongLoaded += MusicPlayerSongLoadedHandler;

            musicPlayer.PlayTestMusic();

            TimeBar.InitializeTimers();
        }

        private void AssignHandlersToUIControlEvents()
        {
            //Menu buttons
            this.MenuButtons.autoPlayerBtnClicked += MenuButtonAutoPlayHandler;
            this.MenuButtons.manualPlayerBtnClicked += MenuButtonManualPlayHandler;
            this.MenuButtons.aboutBtnClicked += MenuButtonAboutHandler;

            //Time bar buttons
            this.TimeBar.btnPlayClicked += TimeBarPlayHandler;
            this.TimeBar.btnPauseClicked += TimeBarPauseHandler;
            this.TimeBar.btnMoveLeftClicked += TimeBarMoveLeftHandler;
            this.TimeBar.btnMoveRightClicked += TimeBarMoveRightHandler;
            this.TimeBar.sldTimeMouseDragged += TimeBarSliderMouseDragHandler;
            this.TimeBar.timebarRequestPositionUpdate += TimebarUpdateSliderHandler;
            this.TimeBar.timebarVolumeChanged += TimeBarVolumeChangedHandler;
        }

        private void TimebarUpdateSliderHandler(object sender, EventArgs e)
        {
            TimeBar.SetSliderPosition(musicPlayer.GetSongPosition());
        }

        private void TimeBarVolumeChangedHandler(object sender, EventArgs e)
        {
            musicPlayer.SetVolume(TimeBar.Volume);
        }

        #region "Button click handlers"

        private void MenuButtonAutoPlayHandler(object sender, EventArgs e)
        {
           
        }

        private void MenuButtonManualPlayHandler(object sender, EventArgs e)
        {
            
        }

        private void MenuButtonAboutHandler(object sender, EventArgs e)
        {
           
        }

        private void TimeBarPlayHandler(object sender, EventArgs e)
        {
           
            musicPlayer.Play();
        }

        private void TimeBarPauseHandler(object sender, EventArgs e)
        {
            
            musicPlayer.Pause();
        }

        private void TimeBarMoveLeftHandler(object sender, EventArgs e)
        {
            
        }

        private void TimeBarMoveRightHandler(object sender, EventArgs e)
        {
            
        }

        private void TimeBarSliderMouseDragHandler(object sender, EventArgs e)
        {           
            musicPlayer.SetSongPosition(this.TimeBar.CurrentTime);
        }

        #endregion

        private void MusicPlayerSongLoadedHandler(object sender, EventArgs e)
        {
            TimeBar.SetSliderMaxLenght(musicPlayer.GetCurretnSongLenghtSeconds());
        }

        private void UpdateSliderTimerElapsedHandler(object sender, EventArgs e)
        {
            TimeBar.SetSliderPosition(musicPlayer.GetSongPosition());
        }
    }
}
