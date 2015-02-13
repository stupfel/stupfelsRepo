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

namespace MausAnzeige
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



        private void mbew(object sender, MouseEventArgs e)
        {
            lb.Content = e.RoutedEvent.Name
                + " X : " + (int)e.GetPosition(this).X
                + " Y : " + (int)e.GetPosition(this).Y;
        }

        private void mdu(object sender, MouseButtonEventArgs e)
        {
            lb.Content = "Ereignis: " + e.RoutedEvent.Name + "\n"
                + "Button-Status: " + e.ButtonState + "\n"
                + "Button: " + e.ChangedButton + "\n"
                + "Anzahl Clicks: " + e.ClickCount + "\n"
                + "Position X: " + (int)e.GetPosition(this).X
                + " Y: " + (int)e.GetPosition(this).Y;
        }

        private void mwh(object sender, MouseWheelEventArgs e)
        {
            lb.Content = "Ereignis: " + e.RoutedEvent.Name + "\n"
                + "Änderung um: " + e.Delta + "\n"
                + "Position X: " + (int)e.GetPosition(this).X
                + " Y: " + (int)e.GetPosition(this).Y;
        }
    }
}
