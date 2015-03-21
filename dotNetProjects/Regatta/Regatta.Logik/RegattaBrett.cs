using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regatta.Logik
{
    public class RegattaBrett
    {
        enum RegattaZustand
        {
            SpielerAamZug,
            SpielerBamZug
        }

        Boje BojeAStart;
        Boje BojeBStart;
        Boje BojeC;
        Boje BojeD;

        Windrose windrose;

        Wuerfel wuerfel;

        List<Yacht> Yachten;

        private RegattaZustand _WerIstAmZug;

        public RegattaBrett()
        {
            Yachten = new List<Yacht>();
            wuerfel = new Wuerfel(1, 5);
            windrose = new Windrose(RegattaLogik.Windrichtung.N);
            _WerIstAmZug = RegattaZustand.SpielerAamZug;
        }


        public IEnumerable<Yacht> getYachten()
        {
            return Yachten;
        }
        public Yacht CreateYacht()
        {
            Yacht newYacht = new Yacht(getNextYachtID(), this, 0, 0, RegattaLogik.Windrichtung.N);
            Yachten.Add(newYacht);
            return newYacht;
        }
        private int getNextYachtID()
        {
            return Yachten.Count + 1;
        }

        public RegattaLogik.Windrichtung getWindroseRichtung()
        {
            return windrose.Windrichtung;
        }
        public void WindroseLinks()
        {
            windrose.Drehe(RegattaLogik.Richtung.links);
        }
        public void WindroseRechts()
        {
            windrose.Drehe(RegattaLogik.Richtung.rechts);
        }

        public WerIstAmZug()
        {}
    }
}
