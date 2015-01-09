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
    }
}
