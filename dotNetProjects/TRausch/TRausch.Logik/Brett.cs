using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRausch.Logik.Dreier;
using TRausch.Logik.Koordinaten;

namespace TRausch.Logik
{
    public class Brett
    {
        //das Spielbrett
        public const int MaxAnzahlReihen = 20;
        public const int MaxAnzahlSpalten = 20;

        private const int SpielsteinRangeUnten = 1;
        private const int SpielsteinRangeOben = 7;

        private int[,] _feld;

        public Brett()
        {
            _feld = new int[MaxAnzahlSpalten, MaxAnzahlReihen];
            FuelleBrettMitRandomSpielsteinen();
        }

        private void FuelleBrettMitRandomSpielsteinen()
        {
            for (int x = 0; x < MaxAnzahlSpalten; x++)
            {
                for (int y = 0; y < MaxAnzahlReihen; y++)
                {
                    _feld[x, y] = BrettLogik.GenerateRandomNumber(SpielsteinRangeUnten, SpielsteinRangeOben);
                }
            }
        }

        //// Erzeugt Spielsteine in der vorgegebenen Range
        //private int getNextRandomSpielstein()
        //{
        //    int returnValue;
        //    Random r = new Random();
        //    returnValue = r.Next(SpielsteinRangeUnten, SpielsteinRangeOben);
        //    Console.Write(returnValue);
        //    return returnValue;
        //}

        // sucht das beste Koordinatenpaar heraus
        public IKoordinatenpaar SucheKoordinatenpaar()
        {
            // TODO Koordinaten müssen noch getauscht werden

            // 1. Liste von allen möglichen Koordinatenpaaren erzeugen.
            // 2. Jede Koordinate im Paar auf mögliche Dreier überprüfen. Die Anzahl an gefundenen Dreiern pro Paar merken.
            // 3. Das Paar mit den meisten Dreiern hat gewonnen und wird zurückgegeben.
            IEnumerable<IKoordinatenpaar> enumKoordinatenpaare;
            IEnumerable<IDreier> enumDreier;
            IEnumerable<IDreier> enumDreierSelberSpielstein;
            List<IKoordinatenpaar> lstKoordinatenpaar = new List<IKoordinatenpaar>();

            enumKoordinatenpaare = BrettLogik.AlleKoordinatenpaare(this);

            foreach (var kPaar in enumKoordinatenpaare)
	        {
                enumDreier = BrettLogik.AlleDreierZuKoordinatenpaar(kPaar);
                enumDreierSelberSpielstein = BrettLogik.SelberSpielstein(enumDreier, this);
                kPaar.AnzahlDreier = enumDreierSelberSpielstein.Count();

                if (lstKoordinatenpaar.Capacity == 0)
                {
                    lstKoordinatenpaar.Add(kPaar);
                }
                else
                {
                    if (lstKoordinatenpaar.ElementAt(0).AnzahlDreier < kPaar.AnzahlDreier)
                    {
                        lstKoordinatenpaar.Insert(0, kPaar);
                    }
                    else
                    {
                        lstKoordinatenpaar.Insert(1, kPaar);
                    }
                }
                
	        }

            return lstKoordinatenpaar.Max<IKoordinatenpaar>();
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

        //public void SpieleStein(int Spielfarbe, int Spalte)
        //{
        //    Koordinate koordinate;

        //    koordinate = BLogik.FindeFreiesFeldInSpalte(this, Spalte);
        //    this.setSpielstein(koordinate, Spielfarbe);

        //}

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
