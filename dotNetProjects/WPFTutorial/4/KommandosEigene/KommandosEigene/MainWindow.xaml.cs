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

namespace KommandosEigene
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

        private void Ausgabe_Eins_erlaubt(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (bool)cb1.IsChecked;
        }

        private void Ausgabe_Eins_ausgefuehrt(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Eins");
        }

        private void Ausgabe_Zwei_erlaubt(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (bool)cb2.IsChecked;
        }

        private void Ausgabe_Zwei_ausgefuehrt(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Zwei");
        }
    }
}
