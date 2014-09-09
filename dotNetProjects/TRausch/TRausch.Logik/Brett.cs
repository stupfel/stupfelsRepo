using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRausch.Logik
{
    public class Brett
    {
        //das Spielbrett
        public const int MaxAnzahlReihen = 20;
        public const int MaxAnzahlSpalten = 20;

        public const int SPIELSTEIN_A = 0;
        public const int SPIELSTEIN_B = 1;
        public const int SPIELSTEIN_C = 2;

        private int[,] _feld;

        public Brett()
        {
            _feld = new int[MaxAnzahlSpalten, MaxAnzahlReihen];
        }

        //public int Gewinner()
        //{
        //    IEnumerable<IVierer> iEnumVierer;
        //    iEnumVierer = BLogik.SelbeFarbe(BLogik.AlleVierer(this), this);
        //    if (iEnumVierer.Count<IVierer>() > 0)
        //    {
        //        return this.getSpielstein(iEnumVierer.ElementAt<IVierer>(0).Eins);
        //    }
        //    return 0;
        //}

        public void SpieleStein(int Spielfarbe, int Spalte)
        {
            Koordinate koordinate;

            koordinate = BLogik.FindeFreiesFeldInSpalte(this, Spalte);
            this.setSpielstein(koordinate, Spielfarbe);

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
