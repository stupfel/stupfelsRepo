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

namespace FensterUnter
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

        private void btnNewWindow_Click(object sender, RoutedEventArgs e)
        {
            UnterFenster uf = new UnterFenster(txtBox.Text);
            uf.Owner = this;

            if (uf.ShowDialog() == true)
            {
                lblStatus.Content = "Beendet mit Ok";
                txtBox.Text = uf.Eingabetext;
            }
            else
            {
                lblStatus.Content = "Beendet mit Abbrechen";
            }
        }
    }
}
