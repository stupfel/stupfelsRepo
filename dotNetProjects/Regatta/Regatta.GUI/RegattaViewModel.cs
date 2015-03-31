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
        //RegattaBrett brett;
        RegattaController _control;
        BitmapImage _WindroseSource;
        BitmapImage imageWindrose;

        private const string PathImages = "images/";
        private Dictionary<RegattaLogik.Windrichtung, BitmapImage> dictImages;

        public RegattaViewModel()
        {
            _control = new RegattaController();
            //brett = new RegattaBrett();

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
            return _control.Spielbrett.getWindroseRichtung();
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

        public string WerIstAmZug
        {
            get { return  "Am Zug: " + _control.WerIstAmZug; }
        }
       
        public int MaxReihen
        {
            get { return _control.Spielbrett.MaxReihen; }
        }

        public List<Yacht> Yachten
        {
            get { return _control.Spielbrett.getYachten(); }
        }

        //DEBUG-Buttons
        public void WinrdoseLinks()
        {
            _control.Spielbrett.WindroseLinks();
            LoadWindroseImage();
        }
        public void WinrdoseRechts()
        {
            _control.Spielbrett.WindroseRechts();
            LoadWindroseImage();
        }
    }
}
