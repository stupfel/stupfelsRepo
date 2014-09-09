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
        public const int MaxAnzahlReihen = 6;
        public const int MaxAnzahlSpalten = 7;

        public const int SPIELSTEIN_KEINER = 0;
        public const int SPIELSTEIN_ROT = 1;
        public const int SPIELSTEIN_GELB = 2;

        private int[,] _feld;
        
        public enum Zustaende
        {
            RotIstAmZug = 0,
            GelbIstAmZug = 1,
            RotHatGewonnen = 2,
            GelbHatGewonnen = 3,
        };

        private Zustaende _Zustand;

        public Brett ()
        {
            _feld = new int[MaxAnzahlSpalten, MaxAnzahlReihen];
            _Zustand = Zustaende.RotIstAmZug;
        }

        public int Gewinner()
        {
            IEnumerable<IVierer> iEnumVierer;
            iEnumVierer = BLogik.SelbeFarbe(BLogik.AlleVierer(this), this);
            if (iEnumVierer.Count<IVierer>() > 0)
            {
                return this.getSpielstein(iEnumVierer.ElementAt<IVierer>(0).Eins);
            }
            return 0;
        }

        public void SpieleStein(int Spielfarbe, int Spalte)
        {
            Koordinate koordinate;
            koordinate = BLogik.FindeFreiesFeldInSpalte(this, Spalte);
            if (koordinate == null)
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

        public string getBrettAsString()
        {
            // String wird von oben nach unten aufgebaut -> also die oberen Reihen zuerst abarbeiten.
            StringBuilder sb = new StringBuilder("");
            for (int iReihe = _feld.GetLength(1) - 1; iReihe >= 0; iReihe--)
            {
                for (int iSpalte = 0; iSpalte < _feld.GetLength(0); iSpalte++)
                {
                    try
                    {
                        sb.Append(_feld[iSpalte, iReihe]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
