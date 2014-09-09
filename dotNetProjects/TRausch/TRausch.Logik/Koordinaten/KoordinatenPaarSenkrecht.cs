using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRausch.Logik.Koordinaten;

namespace TRausch.Logik
{
    public class KoordinatenPaarSenkrecht : IKoordinatenpaar
    {
        Koordinate _k1;
        Koordinate _k2;

        public KoordinatenPaarSenkrecht(Koordinate k1)
        {
            _k1 = k1;
            _k2 = new Koordinate(k1.X, k1.Y - 1);
        }

        public KoordinatenPaarSenkrecht(int x, int y)
        {
            _k1 = new Koordinate(x, y);
            _k2 = new Koordinate(x, y - 1);
        }


        public Koordinate Eins
        {
            get { return _k1; }
        }

        public Koordinate Zwei
        {
            get { return _k2; }
        }
    }
}
