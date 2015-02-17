using System;
using System.Windows;

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
    }
}
