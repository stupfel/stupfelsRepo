using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Media;

namespace RessourcenPhysisch
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sImagePath = "images/";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rb_Click(object sender, RoutedEventArgs e)
        {
            Control c = (Control)sender;
            im.Source = new BitmapImage(new Uri(sImagePath + c.Name + ".jpg", UriKind.Relative));
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer("69.mp3");
        }
    }
}
