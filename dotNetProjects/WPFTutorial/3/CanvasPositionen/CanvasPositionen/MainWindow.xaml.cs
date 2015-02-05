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

namespace CanvasPositionen
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

        private void b1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            Button nb = new Button();
            nb.Content = "Neu";
            nb.SetValue(Canvas.RightProperty, 5.0);
            nb.SetValue(Canvas.BottomProperty, 80.0);
            cv.Children.Add(nb);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
