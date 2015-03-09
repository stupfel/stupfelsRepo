using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Regatta.Logik;
using System.ComponentModel;
using System.Windows.Media;

namespace Regatta.GUI
{
    public class RegattaViewModel : INotifyPropertyChanged
    {
        RegattaBrett brett;
        ImageSource _WindroseSource;

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

        public ImageSource WindroseSource
        {
            get { return _WindroseSource; }
            set
            {
                _WindroseSource = value;
                OnPropertyChanged("WindroseSource");
            }
        }
    }
}
