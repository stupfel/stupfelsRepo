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

namespace AnwendungReihenfolge
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

        private void Window_Initialized(object sender, EventArgs e)
        {
            MessageBox.Show("Window_Initialized");
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            MessageBox.Show("Window_Loaded");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if((bool)rb2.IsChecked)
            {
                e.Cancel = true;
                MessageBox.Show("Fenster wird nicht geschlossen");
            }
            else
            {
                MessageBox.Show("Fenster wird geschlossen");
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        { MessageBox.Show("Fenster ist entladen"); }

        private void Window_Closed(object sender, EventArgs e)
        { MessageBox.Show("Fenster ist geschlossen"); }

        private void init(object sender, EventArgs e)
        {           MessageBox.Show(((FrameworkElement)sender).Name                + " initialisiert");
        }
        private void load(object sender, RoutedEventArgs e)
        {            MessageBox.Show(((FrameworkElement)sender).Name                + " geladen");
        }
    }
}
