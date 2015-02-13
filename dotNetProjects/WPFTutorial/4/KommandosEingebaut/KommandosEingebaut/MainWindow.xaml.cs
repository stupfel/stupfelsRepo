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

namespace KommandosEingebaut
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool bearbeitet1;
        bool bearbeitet2;

        public MainWindow()
        {
            InitializeComponent();
            bearbeitet1 = false;
            bearbeitet2 = false;
        }

        private void erlaubt(object sender, CanExecuteRoutedEventArgs e)
        {
            if (bearbeitet1 || bearbeitet2)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void ausfuehren(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void tc1(object sender, TextChangedEventArgs e)
        {
            bearbeitet1 = true;
        }

        private void tc2(object sender, TextChangedEventArgs e)
        {
            bearbeitet2 = true;
        }
    }
}
