using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRausch.Logik
{
    public class Spielstein
    {
        int _typ;

        public Spielstein(int typ)
        {
            _typ = typ;
        }

        public int Typ
        {
            get {return _typ; }
        }

        public override string ToString()
        {
            return _typ + "";
        }
    }
}
