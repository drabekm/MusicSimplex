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

namespace Music_Simplex.CustomControls
{
    /// <summary>
    /// Interaction logic for MenuButtons.xaml
    /// </summary>
    public partial class MenuButtons : UserControl
    {
        public event EventHandler autoPlayerBtnClicked;
        public event EventHandler manualPlayerBtnClicked;
        public event EventHandler aboutBtnClicked;

        public MenuButtons()
        {
            InitializeComponent();
        }

        private void BtnAutoPlayer_Click(object sender, RoutedEventArgs e)
        {
            autoPlayerBtnClicked(this, e);
        }

        private void BtnManualPlayer_Click(object sender, RoutedEventArgs e)
        {
            manualPlayerBtnClicked(this, e);
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            aboutBtnClicked(this, e);
        }
    }
}
