using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRausch.Logik.Dreier;
using TRausch.Logik.Koordinaten;

namespace TRausch.Logik
{
    class BrettLogik
    {
        internal static IEnumerable<IKoordinatenpaar> AlleKoordinatenpaare(Brett brett)
        {
            for (var x = 1; x <= Brett.MaxAnzahlSpalten; x++)
            {
                for (var y = 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    yield return new KoordinatenPaarSenkrecht(x, y);
                    yield return new KoordinatenPaarWaagerecht(x, y);
                }
            }
        }
    }
}
