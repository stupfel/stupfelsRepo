using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRausch.Logik.Dreier;
using TRausch.Logik.Koordinaten;

namespace TRausch.Logik
{
    public class KoordinatenPaarSenkrecht : IKoordinatenpaar
    {
        Koordinate _k1;
        Koordinate _k2;
        int _AnzahlDreier;
        IEnumerable<IDreier> _enumAlleDreierZuKoordinatenpaar;
        List<IDreier> _listAlleDreierZuKoordinatenpaar;

        public KoordinatenPaarSenkrecht(Koordinate k1)
        {
            _k1 = k1;
            _k2 = new Koordinate(k1.X, k1.Y - 1);
            _AnzahlDreier = 0;
            //_enumAlleDreierZuKoordinatenpaar = BrettLogik.AlleDreierZuKoordinatenpaar(this);
            _listAlleDreierZuKoordinatenpaar = BrettLogik.AlleDreierZuKoordinatenpaarAsList(this);
        }

        public KoordinatenPaarSenkrecht(int x, int y)
        {
            _k1 = new Koordinate(x, y);
            _k2 = new Koordinate(x, y - 1);
            _AnzahlDreier = 0;
            //_enumAlleDreierZuKoordinatenpaar = BrettLogik.AlleDreierZuKoordinatenpaar(this);
            _listAlleDreierZuKoordinatenpaar = BrettLogik.AlleDreierZuKoordinatenpaarAsList(this);
        }


        public Koordinate Eins
        {
            get { return _k1; }
        }

        public Koordinate Zwei
        {
            get { return _k2; }
        }

        public int AnzahlDreier
        {
            get { return _AnzahlDreier; }
            set { _AnzahlDreier = value; }
        }

        public IEnumerable<IDreier> AlleDreierZuKoordinatenpaar
        {
            get { return _enumAlleDreierZuKoordinatenpaar; }
        }

        public List<IDreier> AlleDreierZuKoordinatenpaarAsList
        {
            get { return _listAlleDreierZuKoordinatenpaar; }
        }

        public override string ToString()
        {
            return ("K1: " + _k1.ToString() + "  K2: " + _k2.ToString());
        }
    }
}
