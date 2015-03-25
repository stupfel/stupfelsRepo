using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regatta.Logik
{
    public class RegattaBrett
    {

        private Boje _BojeAStart;
        private Boje _BojeBStart;
        private Boje _BojeC;
        private Boje _BojeD;

        private Windrose _windrose;

        private Wuerfel _wuerfel;

        private List<Yacht> _Yachten;

        private Yacht _currentYacht;
        
        public RegattaBrett()
        {
            _Yachten = new List<Yacht>();
            _wuerfel = new Wuerfel(1, 5);
            _windrose = new Windrose(RegattaLogik.Windrichtung.N);
        }

        public IEnumerable<Yacht> getYachten()
        {
            return _Yachten;
        }
        public Yacht CreateYacht()
        {
            Yacht newYacht = new Yacht(getNextYachtID(), this, 0, 0, RegattaLogik.Windrichtung.N);
            _Yachten.Add(newYacht);
            return newYacht;
        }
        private int getNextYachtID()
        {
            return _Yachten.Count + 1;
        }

        public RegattaLogik.Windrichtung getWindroseRichtung()
        {
            return _windrose.Windrichtung;
        }
        public void WindroseLinks()
        {
            _windrose.Drehe(RegattaLogik.Richtung.links);
        }
        public void WindroseRechts()
        {
            _windrose.Drehe(RegattaLogik.Richtung.rechts);
        }

        public string WerIstAmZug
        {
            get 
            {
                if (_currentYacht != null)
                {
                    return _currentYacht.id + "";
                }
                else
                {
                    return "niemand";
                }
            }
        }
    }
}
