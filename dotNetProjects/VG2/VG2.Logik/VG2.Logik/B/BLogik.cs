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
       
        internal static IEnumerable<IVierer> SelbeFarbe(IEnumerable<IVierer> vierer, Brett brett)
        {
            bool hasViererSelbeFarbe;
            foreach(var vier in vierer)
            {
                hasViererSelbeFarbe = false;
                try
                {
                    if ((brett.getSpielstein(vier.Eins) != 0) &&
                       (brett.getSpielstein(vier.Eins) == brett.getSpielstein(vier.Zwei)) &&
                       (brett.getSpielstein(vier.Eins) == brett.getSpielstein(vier.Drei)) &&
                       (brett.getSpielstein(vier.Eins) == brett.getSpielstein(vier.Vier)))
                    {
                        hasViererSelbeFarbe = true;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    hasViererSelbeFarbe = false;
                }
                if (hasViererSelbeFarbe)
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

        internal static IEnumerable<IVierer> AlleVierer(Brett brett)
        {
            // Horizontale Vierer
            for (var x = 1; x <= Brett.MaxAnzahlSpalten - 4; x++)
            {
                for (var y = 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    yield return new HorizontalerVierer(x, y);
                }
            }

            // Vertikale Vierer
            for (var x = 1; x <= Brett.MaxAnzahlSpalten - 4; x++)
            {
                for (var y = 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    yield return new VertikalerVierer(x, y);
                }
            }

            // DiagonalHoch Vierer
            for (var x = 1; x <= Brett.MaxAnzahlSpalten - 4; x++)
            {
                for (var y = 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    yield return new DiagonallHochVierer(x, y);
                }
            }

            // DiagonalRunter Vierer
            for (var x = 1; x <= Brett.MaxAnzahlSpalten - 4; x++)
            {
                for (var y = 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    yield return new DiagonallRunterVierer(x, y);
                }
            }
        }
    
    }
}
