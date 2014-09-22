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
        public const int MaxAnzahlReihen = 8;
        public const int MaxAnzahlSpalten = 8;

        private const int SpielsteinRangeUnten = 1;
        private const int SpielsteinRangeOben = 7;

        private int[,] _feld;

        public Brett()
        {
            _feld = new int[MaxAnzahlSpalten, MaxAnzahlReihen];
            FuelleBrettMitRandomSpielsteinen();
        }

        public Brett(Brett brett)
        {
            this._feld = brett._feld.Clone() as int[,];
        }

        private void FuelleBrettMitRandomSpielsteinen()
        {
            IEnumerable<IDreier> dreier;
            IEnumerable<IDreier> enumDreierSelberSpielstein;
            for (int x = 0; x < MaxAnzahlSpalten; x++)
            {
                for (int y = 0; y < MaxAnzahlReihen; y++)
                {
                    do
                    {
                        _feld[x, y] = BrettLogik.GenerateRandomNumber(SpielsteinRangeUnten, SpielsteinRangeOben);
                        // jetzt das Feld prüfen -> es darf keiner 3er Gruppen geben, wenn doch muss eine neue Nummer genertiert werden.
                        dreier = BrettLogik.AlleDreierZuKoordinate(new Koordinate(x + 1, y + 1));
                        enumDreierSelberSpielstein = BrettLogik.SelberSpielstein(dreier, this);
                    } while (enumDreierSelberSpielstein.Count<IDreier>() > 0);

                    //_feld[x, y] = 1;


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
            Console.WriteLine("Start SucheKoordinatenpaar");

            IEnumerable<IKoordinatenpaar> enumKoordinatenpaare;
            List<IKoordinatenpaar> listKoordinatenpaare;

            IEnumerable<IDreier> enumDreier;
            List<IDreier> listDreier;

            IEnumerable<IDreier> enumDreierSelberSpielstein;
            List<IKoordinatenpaar> lstKoordinatenpaar = new List<IKoordinatenpaar>();
            

            // jetzt aus static herausholen
            //enumKoordinatenpaare = BrettLogik.AlleKoordinatenpaare(this);
            //enumKoordinatenpaare = BrettLogik.getAlleKoordinatenPaare;
            listKoordinatenpaare = BrettLogik.getAlleKoordinatenPaareAsList;
            
            //foreach (var kPaar in enumKoordinatenpaare)
            foreach (var kPaar in listKoordinatenpaare)
	        {
                try
                {
                    if (getSpielstein(kPaar.Eins) != getSpielstein(kPaar.Zwei))
                    { 
                        TauscheKoordinatenWerte(kPaar.Eins, kPaar.Zwei);

                        // aus Property herausholen 
                        //enumDreier = BrettLogik.AlleDreierZuKoordinatenpaar(kPaar);
                        //enumDreier = kPaar.AlleDreierZuKoordinatenpaar;
                        listDreier = kPaar.AlleDreierZuKoordinatenpaarAsList;
                   
                        //enumDreierSelberSpielstein = BrettLogik.SelberSpielstein(enumDreier, tauschBrett);
                        //kPaar.AnzahlDreier = enumDreierSelberSpielstein.Count();
                        //kPaar.AnzahlDreier = BrettLogik.SelberSpielsteinCount(listDreier, this);
                        kPaar.AnzahlDreier = BrettLogik.CountSelbeFarbeZuKoordinatenpaar(this, kPaar, getSpielstein(kPaar.Eins), getSpielstein(kPaar.Zwei));
                    }
                    else
                    {
                        kPaar.AnzahlDreier = 0;
                    }
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
                    TauscheKoordinatenWerte(kPaar.Eins, kPaar.Zwei);

                }
                catch (IndexOutOfRangeException e)
                {
                    // weiter
                }
                catch (Exception e)
                {
                    throw;
                }
                
	        }

            return lstKoordinatenpaar.ElementAt(0);
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
        public int getSpielstein(int x, int y)
        {
            try
            {
                return _feld[x - 1, y - 1];
            }
            catch (Exception)
            {

                throw new IndexOutOfRangeException();
            }
        }

        public void TauscheKoordinatenWerte(Koordinate k1, Koordinate k2)
        {
            int Wert;
            Wert = this.getSpielstein(k1);
            this.setSpielstein(k1, this.getSpielstein(k2));
            this.setSpielstein(k2, Wert);
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
