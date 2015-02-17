using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AnwendungReihenfolge
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MessageBox.Show("Anwendung gestartet - Funktion Application_Startup");
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("Anwendung beendet - Funktion Application_Exit");
        }
    }
}
