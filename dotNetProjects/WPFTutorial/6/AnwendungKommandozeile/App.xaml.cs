using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AnwendungKommandozeile
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static int arg0, arg1, erg;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MessageBox.Show(System.Environment.CommandLine);
            MessageBox.Show(String.Join(", ", e.Args));

            if(e.Args.Count() > 0)
            {
                arg0 = Convert.ToInt32(e.Args[0]);
                arg1 = Convert.ToInt32(e.Args[1]);
            }
            else
            {
                arg0 = 0;
                arg1 = 0;
            }
            erg = arg0 + arg1;
        }

         
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            e.ApplicationExitCode = erg;
        }
    }
}
