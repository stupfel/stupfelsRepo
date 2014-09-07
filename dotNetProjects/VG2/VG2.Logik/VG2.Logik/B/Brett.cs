using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG2.Logik.B
{
    public class Brett
    {
        //das Spielbrett
        const int MaxAnzahlReihen = 6;
        const int MaxAnzahlSpalten = 7;

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

    }
}
