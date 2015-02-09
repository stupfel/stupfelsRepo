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

namespace ControlsNeuLoeschen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int nr;
        public MainWindow()
        {
            InitializeComponent();
            nr = 1;
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Button neu = new Button();
            neu.Content = "Neu " + nr;
            nr++;
            neu.Click += new RoutedEventHandler(loeschen);
            sp.Children.Add(neu);
        }


        private void loeschen(object sender, RoutedEventArgs e)
        {
            sp.Children.Remove(sender as UIElement);
        }
    }
}
