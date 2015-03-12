using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Regatta.Logik;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Controls;

namespace Regatta.GUI
{
    public class RegattaViewModel : INotifyPropertyChanged
    {
        RegattaBrett brett;
        Images _WindroseSource;

        public RegattaViewModel()
        {
            brett = new RegattaBrett();
        }

        // Schnittstellen-Ereignis

        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }


        public Image WindroseSource
        {
            get { return _WindroseSource; }
            set
            {
                _WindroseSource = value;
                OnPropertyChanged("WindroseSource");
            }
        }
        public string WindroseSourceName
        {
            get { return _WindroseSource.ToString(); }
        }
        public RegattaLogik.Windrichtung getWindroseRichtung()
        {
            return brett.getWindroseRichtung();
        }
    }
}
