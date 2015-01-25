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

namespace AttachedPropertys
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

        private void abrufen(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(b1.GetValue(Canvas.LeftProperty).ToString());
        }

        private void setzen(object sender, RoutedEventArgs e)
        {
            b2.SetValue(Canvas.LeftProperty, Int32.Parse(b2.GetValue(Canvas.LeftProperty).ToString()) + 5.0);
        }
    }
}
