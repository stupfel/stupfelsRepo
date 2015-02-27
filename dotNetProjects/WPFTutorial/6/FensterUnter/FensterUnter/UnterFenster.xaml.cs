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
using System.Windows.Shapes;

namespace FensterUnter
{
    /// <summary>
    /// Interaktionslogik für UnterFenster.xaml
    /// </summary>
    public partial class UnterFenster : Window
    {
        string eingabetext;

        public UnterFenster(string et)
        {
            InitializeComponent();
            txtBox.Text = et;
        }

        public UnterFenster()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            eingabetext = txtBox.Text;
            DialogResult = true;
        }

        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string Eingabetext
        { get { return this.eingabetext;  } }
    }
}
