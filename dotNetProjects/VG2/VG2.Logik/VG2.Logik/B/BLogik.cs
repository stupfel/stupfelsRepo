using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG2.Logik.B.Exceptions;
using VG2.Logik.B.Vierer;

namespace VG2.Logik.B
{
    class BLogik
    {

        internal static void Gewinner(Brett brett)
        {
            Brett.AlleVierer(brett);
        }

       
        internal static IEnumerable<IVierer> SelbeFarbe(this IEnumerable<IVierer> vierer, Brett brett)
        {
            foreach(var vier in vierer)
            {
                if ((brett.getSpielstein(vier.Eins) != 0) &&
                    (brett.getSpielstein(vier.Eins) == brett.getSpielstein(vier.Zwei)) &&
                    (brett.getSpielstein(vier.Eins) == brett.getSpielstein(vier.Drei)) &&
                    (brett.getSpielstein(vier.Eins) == brett.getSpielstein(vier.Vier)))
                {
                    yield return vier;
                }
            }
        }

        internal static Koordinate FindeFreiesFeldInSpalte(Brett feld, int Spalte)
        {
            for (int iReihe = 1; iReihe <= Brett.MaxAnzahlReihen; iReihe++)
            {
                Koordinate koordinate = new Koordinate(Spalte, iReihe);
                if (feld.getSpielstein(koordinate) == Brett.SPIELSTEIN_KEINER)
                {
                    return koordinate;
                }
            }
            throw new SpalteVollException();
        }
    }
}
