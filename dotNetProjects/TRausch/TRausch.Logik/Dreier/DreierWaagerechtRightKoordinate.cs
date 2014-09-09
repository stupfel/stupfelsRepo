using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRausch.Logik.Dreier
{
    internal struct DreierWaagerechtRightKoordinate : IDreier
    {
        private readonly int _x;
        private readonly int _y;

        public DreierWaagerechtRightKoordinate(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public Koordinate Eins
        {
            get
            {
                return new Koordinate(_x - 2, _y);
            }
        }

        public Koordinate Zwei
        {
            get { return new Koordinate(_x - 1, _y); }
        }

        public Koordinate Drei
        {
            get { return new Koordinate(_x, _y); }
        }
    }
}
