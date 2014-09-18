using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRausch.Logik
{
    public class Koordinate
    {
        private int _x;
        private int _y;

        public Koordinate(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public override string ToString()
        {
            return ("X:" + _x + " Y:" + _y);
        }
    }
}
