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

namespace FensterMember
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

        private void btnSizeToContent_Click(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void btnOriginal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGroesser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRechtsUnten_Click(object sender, RoutedEventArgs e)
        {

        }

        private void checkShowInTaskbar_Click(object sender, RoutedEventArgs e)
        {
            ShowInTaskbar = (bool)checkShowInTaskbar.IsChecked;
        }

        private void checkCanResize_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void checkTopMost_Click(object sender, RoutedEventArgs e)
        {
            Topmost = (bool)checkTopMost.IsChecked;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            lblLocation.Content = "Location: Top " + (int)Top + " / Left " + (int)Left;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            lblState.Content = "State: " + WindowState;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            lblSize.Content = "Size: Height " + (int)e.NewSize.Height + " / Width " + (int)e.NewSize.Width;
        }

        private void checkCanResize_Checked(object sender, RoutedEventArgs e)
        {
            ResizeMode = ResizeMode.CanResize;
        }

        private void checkCanResize_Unchecked(object sender, RoutedEventArgs e)
        {
            ResizeMode = ResizeMode.NoResize;
        }
    }
}
