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

namespace GridAnordnung
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

        // neuer Button anfügen
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Button nb = new Button();
            nb.Content = "Neu";
            nb.SetValue(Grid.RowProperty, 2);
            nb.SetValue(Grid.ColumnProperty, 1);
            gr.Children.Add(nb);
        }

        // neue Spalte anfügen und Button rein
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Button nb = new Button();
            nb.Content = "Neu";
            nb.SetValue(Grid.RowProperty, 0);
            gr.ColumnDefinitions.Add(new ColumnDefinition());
            nb.SetValue(Grid.ColumnProperty, gr.ColumnDefinitions.Count - 1);
            gr.Children.Add(nb);
        }

        // neue Reihe anfügen und Button rein
        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Button nb = new Button();
            nb.Content = "Neu";
            gr.RowDefinitions.Add(new RowDefinition());
            nb.SetValue(Grid.RowProperty, gr.RowDefinitions.Count - 1);
            nb.SetValue(Grid.ColumnProperty, 0);
            gr.Children.Add(nb);
        }
    }
}
