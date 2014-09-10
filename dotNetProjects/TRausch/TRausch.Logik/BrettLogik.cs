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
    
        internal static IEnumerable<IDreier> AlleDreierZuKoordinate(Koordinate k)
        {
            yield return new DreierWaagerechtLeftKoordinate(k.X, k.Y);
            yield return new DreierWaagerechtCenterKoordinate(k.X, k.Y);
            yield return new DreierWaagerechtRightKoordinate(k.X, k.Y);
            yield return new DreierSenkrechtTopKoordinate(k.X, k.Y);
            yield return new DreierSenkrechtCenterKoordinate(k.X, k.Y);
            yield return new DreierSenkrechtBottomKoordinate(k.X, k.Y);
        }
        internal static IEnumerable<IDreier> AlleDreierZuKoordinatenpaar(IKoordinatenpaar kPaar)
        {
            //yield return AlleDreierZuKoordinate(kPaar.Eins);
            //yield return AlleDreierZuKoordinate(kPaar.Zwei);
            IEnumerable<IDreier> dreier;
            dreier = AlleDreierZuKoordinate(kPaar.Eins);
            foreach (var drei in dreier)
            {
                yield return drei;
            }
            dreier = AlleDreierZuKoordinate(kPaar.Zwei);
            foreach (var drei in dreier)
            {
                yield return drei;
            }
        }
        // Bekommt eine Liste von Dreiern. Diese Dreier werden überprüft.
        // Jeder Dreier der dessen Spielsteine gleich sind wird zurückgegeben.
        // Es sollten also immer die Dreier zu eier Koordinate bzw. einem Koordinatenpaar übergeben werden.
        // Wichtig ist dann die Anzahl an Dreiern die zurückgegeben werden.
        internal static IEnumerable<IDreier> SelberSpielstein(IEnumerable<IDreier> dreier, Brett brett)
        {
            bool hasDreierSelbeFarbe;
            foreach (var drei in dreier)
            {
                hasDreierSelbeFarbe = false;
                try
                {
                    if ((brett.getSpielstein(drei.Eins) != 0) &&
                       (brett.getSpielstein(drei.Eins) == brett.getSpielstein(drei.Zwei)) &&
                       (brett.getSpielstein(drei.Eins) == brett.getSpielstein(drei.Drei)))
                    {
                        hasDreierSelbeFarbe = true;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    hasDreierSelbeFarbe = false;
                }
                if (hasDreierSelbeFarbe)
                {
                    yield return drei;
                }

            }
        }
    }
}
