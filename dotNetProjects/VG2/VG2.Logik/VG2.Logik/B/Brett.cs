using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG2.Logik.B;
using VG2.Logik.B.Vierer;

namespace VG2.Logik.B
{
    public class Brett
    {
        //das Spielbrett
        public static const int MaxAnzahlReihen = 6;
        public static const int MaxAnzahlSpalten = 7;

        public static const int SPIELSTEIN_KEINER = 0;
        public static const int SPIELSTEIN_ROT = 1;
        public static const int SPIELSTEIN_GELB = 2;

        private int[,] _feld;
        
        public static enum Zustaende
        {
            RotIstAmZug,
            GelbIstAmZug,
            RotHatGewonnen,
            GelbHatGewonnen
        };

        private Zustaende _Zustand;

        public Brett ()
        {
            _feld = new int[MaxAnzahlSpalten, MaxAnzahlReihen];
            _Zustand = Zustaende.RotIstAmZug;
        }

        public void SpieleStein(int Spielfarbe, int Spalte)
        {
            Koordinate koordinate;
            koordinate = BLogik.FindeFreiesFeldInSpalte(this, Spalte);
            if (koordinate != null)
            {
                // keine freie Koordinate gefunden -> voll
            }
            else
            {
                this.setSpielstein(koordinate, Spielfarbe);
            }

        }

        public void setSpielstein(Koordinate koordinate, int iFarbe)
        {
            try
            {
                _feld[koordinate.X - 1, koordinate.Y - 1] = iFarbe;
            }
            catch (Exception)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int getSpielstein(Koordinate koordinate)
        {
            try
            {
                return _feld[koordinate.X - 1, koordinate.Y - 1];
            }
            catch (Exception)
            {
                
                throw new IndexOutOfRangeException();
            }
        }

        public Zustaende Zustand
        {
            get { return _Zustand; }
            set { _Zustand = value; }
        }

        internal static IEnumerable<IVierer> AlleVierer(this Brett brett)
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
