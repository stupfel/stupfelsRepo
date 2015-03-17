using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Regatta.Logik;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Regatta.GUI
{
    public class RegattaViewModel : INotifyPropertyChanged
    {
        RegattaBrett brett;
        BitmapImage _WindroseSource;
        BitmapImage imageWindrose;

        private const string PathImages = "images/";
        private Dictionary<RegattaLogik.Windrichtung, BitmapImage> dictImages;

        public RegattaViewModel()
        {
            brett = new RegattaBrett();

            dictImages = new Dictionary<RegattaLogik.Windrichtung, BitmapImage>();
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.N + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.N, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.NO + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.NO, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.O + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.O, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.SO + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.SO, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.S + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.S, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.SW + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.SW, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.W + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.W, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.NW + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.NW, imageWindrose);

            //Properties laden
            LoadWindroseImage();
        }

        // Schnittstellen-Ereignis
        public event PropertyChangedEventHandler PropertyChanged;
        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        // Schnittstelle zur Logik
        public RegattaLogik.Windrichtung getWindroseRichtung()
        {
            return brett.getWindroseRichtung();
        }

        //Properties Laden
        public void LoadWindroseImage()
        {
            BitmapImage imagetmp;
            dictImages.TryGetValue(getWindroseRichtung(), out imagetmp);
            WindroseSource = imagetmp;
        }

        //Properties für Ressourcen
        public BitmapImage WindroseSource
        {
            get { return _WindroseSource; }
            set
            {
                _WindroseSource = value;
                OnPropertyChanged("WindroseSource");
            }
        }

        //DEBUG-Buttons
        public void WinrdoseLinks()
        {
            brett.WindroseLinks();
            LoadWindroseImage();
        }
        public void WinrdoseRechts()
        {
            brett.WindroseRechts();
            LoadWindroseImage();
        }
    }
}
