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
        MediaPlayer player = new MediaPlayer();

      

        public MainWindow()
        {
            InitializeComponent();
            

            AssignHandlersToUIButtonEvents();

            /*player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };*/

            //MyUserControl.myEvent += MyEventHandler;

            //player.Open(new Uri(@"C:\programovani\MusicSimplex\Music Simplex\bin\Debug\Romashki.mp3", UriKind.Absolute));
            /*  player.Open(new Uri("testmusic.mp3", UriKind.Relative));
              player.Play();
              var position = player.Position;

              MessageBox.Show(position.ToString() + " : " + player.NaturalDuration);*/

        }

        private void AssignHandlersToUIButtonEvents()
        {
            this.MenuButtons.autoPlayerBtnClicked += MenuButtonAutoPlayHandler;
            this.MenuButtons.manualPlayerBtnClicked += MenuButtonManualPlayHandler;
            this.MenuButtons.aboutBtnClicked += MenuButtonAboutPlayHandler;
        }


        #region "Button click handlers"

        static void MyEventHandler(object sender, EventArgs e)
        {
            var myEventArg = (MyEventArg)e;
            
            MessageBox.Show(myEventArg.Content);
        }

        private void MenuButtonAutoPlayHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Auto pressed");
        }

        private void MenuButtonManualPlayHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Manual pressed");
        }

        private void MenuButtonAboutPlayHandler(object sender, EventArgs e)
        {
            MessageBox.Show("About pressed");
        }

        #endregion
    }
}
