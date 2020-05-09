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

        public double CurrentTime  { get; private set; }

        public TimeBar()
        {
            InitializeComponent();
        }

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

        private void SldTimeDragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.CurrentTime = Math.Round(((Slider)sender).Value);
            sldTimeMouseDragged(this, e);
        }

        private void SldTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.CurrentTime = Math.Round(((Slider)sender).Value);
        }

        private double GetRoundedValueFromSlider(Slider slider)
        {
            return Math.Round(slider.Value);
        }

        public void SetSliderMaxLenght(double lenght)
        {
            this.sldTime.Maximum = lenght;
        }
    }
}
