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

namespace DockPanelLastChild
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

        private void neu_Click(object sender, RoutedEventArgs e)
        {
            Button sb = sender as Button;
            Object dp = sb.GetValue(DockPanel.DockProperty);

            Button nb = new Button();
            nb.Content = "Neu";
            nb.SetValue(DockPanel.DockProperty, dp);

            Panel p = sb.Parent as Panel;
            p.Children.Add(nb);
        }
    }
}
