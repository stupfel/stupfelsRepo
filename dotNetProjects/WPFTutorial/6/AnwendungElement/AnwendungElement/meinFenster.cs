using System;
using System.Windows;
using System.Windows.Controls;
namespace AnwendungEinfach
{
    class meinFenster : Window
    {
        [STAThread]
        public static void Main()
        {
            Application a = new Application();
            meinFenster mf = new meinFenster();
            a.Run(mf);
        }

        public meinFenster()
        {
            Button b = new Button();
            b.Margin = new Thickness(5);
            b.Content = "Hallo";
            b.Click += new RoutedEventHandler(b_Click);

            this.Width = 250;
            this.Height = 80;
            this.Title = "AnwendungELement";
            this.Content = b;
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo");
        }
    }
}
