using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG2.Logik.B.Vierer
{
    interface IVierer
    {
        //private readonly int x;
        //private readonly int y;

        Koordinate Eins
        {
            get;
        }

        Koordinate Zwei
        {
            get;
        }

        Koordinate Drei
        {
            get;
        }

        Koordinate Vier
        {
            get;
        }
    }
}
