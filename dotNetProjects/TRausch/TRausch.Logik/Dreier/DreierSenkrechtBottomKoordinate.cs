using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRausch.Logik.Dreier
{
    internal struct DreierSenkrechtBottomKoordinate : IDreier
    {
        private readonly int _x;
        private readonly int _y;

        public DreierSenkrechtBottomKoordinate(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public Koordinate Eins
        {
            get
            {
                return new Koordinate(_x, _y + 2);
            }
        }

        public Koordinate Zwei
        {
            get { return new Koordinate(_x, _y + 1); }
        }

        public Koordinate Drei
        {
            get { return new Koordinate(_x, _y); }
        }
    }
}
