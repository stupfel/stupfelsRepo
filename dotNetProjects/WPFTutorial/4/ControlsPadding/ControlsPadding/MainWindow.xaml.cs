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

namespace ControlsPadding
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Button b2 = sender as Button;
            b2.Padding = new Thickness(10);
            b2.Content = "2: 10";
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            Button b5 = sender as Button;
            b5.Padding = new Thickness(80, 0, 30, 10);
            b5.Content = ": 80,0,30,10";
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            // geht auch so
            //Button b3 = sender as Button;
            Thickness th = b3.Padding;
            th.Left = 20;
            b3.Padding = th;
            b3.Content = "3: 20,10,10,10";
        }
    }
}
