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

namespace Music_Simplex.User_Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        
        public UserControl1()
        {
            InitializeComponent();

           

            
            
            
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /// casting the content into panel
            Panel mainContainer = (Panel)this.Content;

            /// GetAll UIElement
            UIElementCollection element = mainContainer.Children;

            /// casting the UIElementCollection into List
            List<FrameworkElement> lstElement = element.Cast<FrameworkElement>().ToList();

            /// Geting all Control from list
            var lstControl = lstElement.OfType<Control>();

            foreach (Control contol in lstControl)
            {
                ///Hide all Controls
                contol.Width = this.ActualWidth;

            }
            var eventArg = new MyEventArg("hovno");
            myEvent(this, eventArg);
        }
        public event EventHandler myEvent;
    }
}
