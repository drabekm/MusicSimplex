using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Music_Simplex.CustomControls
{
    /// <summary>
    /// Interaction logic for TimeBar.xaml
    /// </summary>
    public partial class TimeBar : UserControl
    {
        public event EventHandler btnMoveLeftClicked;
        public event EventHandler btnMoveRightClicked;
        public event EventHandler btnPlayClicked;
        public event EventHandler btnPauseClicked;
        public event EventHandler sldTimeMouseDragged;

        public event EventHandler timerRequestPositionUpdate;

        public double CurrentTime  { get; private set; }
        private bool acceptRuntimeSliderUpdate = true;

        System.Windows.Forms.Timer updateSliderTimer = new System.Windows.Forms.Timer();

        public TimeBar()
        {
            InitializeComponent();

            
        }

        /// <summary>
        /// WARNING! This method must be run from somewhere else than the classes constructor.
        /// if you leave it in the TimeBar() method it starts endleslly creating error messageboxes
        /// when you open xaml designer. Best bet is to just run this from the MainWindow.cs 
        /// 
        /// Shits weird man
        /// </summary>
        public void InitializeTimers()
        {
            updateSliderTimer.Interval = 500;
            updateSliderTimer.Tick += SendTimerRequestPositionUpdate;
            updateSliderTimer.Start();
        }

        /// <summary>
        /// Creates event that is handled by MainWindow. Which then returns
        /// musicPlayers current songs location. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTimerRequestPositionUpdate(object sender, EventArgs e)
        {            
            timerRequestPositionUpdate(this, new EventArgs());
        }

        #region "Control Events"

        private void BtnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            btnMoveLeftClicked(this, e);
        }

        private void BtnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            btnMoveRightClicked(this, e);
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            btnPauseClicked(this, e);
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            btnPlayClicked(this, e);
        }

        private void SldTimerDragStarted(object sender, DragStartedEventArgs e)
        {
            updateSliderTimer.Stop();
            acceptRuntimeSliderUpdate = false;
        }

        private void SldTimeDragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.CurrentTime = Math.Round(((Slider)sender).Value);
            updateSliderTimer.Start();
            acceptRuntimeSliderUpdate = true;
            sldTimeMouseDragged(this, e);
        }

        private void SldTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.CurrentTime = Math.Round(((Slider)sender).Value);
        }

        #endregion

        private double GetRoundedValueFromSlider(Slider slider)
        {
            return Math.Round(slider.Value);
        }

        public void SetSliderMaxLenght(double lenght)
        {
            this.sldTime.Maximum = lenght;
        }

        public void SetSliderPosition(double position)
        {
            if (acceptRuntimeSliderUpdate)
            {
                sldTime.Value = position;
            }
        }
    }
}
