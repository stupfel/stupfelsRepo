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

namespace RessourcenLogisch
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

        private void rb1_click(object sender, RoutedEventArgs e)
        {
            b.Foreground = FindResource("fgbrush") as Brush;
        }

        private void rb2_Click(object sender, RoutedEventArgs e)
        {
            b.Foreground = FindResource("winbrush") as Brush;
        }
    }
}
