using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRausch.Logik.Dreier;

namespace TRausch.Logik.Koordinaten
{
    public interface IKoordinatenpaar
    {
        Koordinate Eins
        {
            get;
        }

        Koordinate Zwei
        {
            get;
        }

        int AnzahlDreier
        {
            get;
            set;
        }

        IEnumerable<IDreier> AlleDreierZuKoordinatenpaar
        {
            get;
        }
    }
}
