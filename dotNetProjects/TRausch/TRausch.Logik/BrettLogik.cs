using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TRausch.Logik.Dreier;
using TRausch.Logik.Koordinaten;

namespace TRausch.Logik
{
    class BrettLogik
    {
        private static IEnumerable<IKoordinatenpaar> enumAlleKoordinatenpaare;
        private static List<IKoordinatenpaar> listAlleKoordinatenpaare;
        private static Brett brett;

        //Gibt alle Koordinatenpaare zurück, die zuvor in static Variable gespeichert.
        public static IEnumerable<IKoordinatenpaar> getAlleKoordinatenPaare
        {
            get
            {
                if (enumAlleKoordinatenpaare == null)
                {
                    enumAlleKoordinatenpaare = AlleKoordinatenpaare(brett);
                }                
                return enumAlleKoordinatenpaare;

            }
        }
        public static List<IKoordinatenpaar> getAlleKoordinatenPaareAsList
        {
            get
            {
                if (listAlleKoordinatenpaare == null)
                {
                    listAlleKoordinatenpaare = AlleKoordinatenpaareAsList(brett);
                }
                return listAlleKoordinatenpaare;

            }
        }

        public static Brett StaticBrett
        {
            set
            {
                brett = value;
            }
        }

        internal static IEnumerable<IKoordinatenpaar> AlleKoordinatenpaare(Brett brett)
        {
            for (var x = 1; x <= Brett.MaxAnzahlSpalten; x++)
            {
                for (var y = 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    if (y > 2)
                    {
                        yield return new KoordinatenPaarSenkrecht(x, y);
                    }
                    
                    if (x < Brett.MaxAnzahlSpalten)
                    {
                        yield return new KoordinatenPaarWaagerecht(x, y);
                    }
                }
            }
        }
        internal static List<IKoordinatenpaar> AlleKoordinatenpaareAsList(Brett brett)
        {
            List<IKoordinatenpaar> returnList = new List<IKoordinatenpaar>();
            for (var x = 1; x <= Brett.MaxAnzahlSpalten; x++)
            {
                for (var y = 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    if (y > 2)
                    {
                        returnList.Add(new KoordinatenPaarSenkrecht(x, y));
                    }

                    if (x < Brett.MaxAnzahlSpalten)
                    {
                        returnList.Add(new KoordinatenPaarWaagerecht(x, y));
                    }
                }
            }
            return returnList;
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
        internal static List<IDreier> AlleDreierZuKoordinateAsList(Koordinate k)
        {
            List<IDreier> dreier = new List<IDreier>();
            dreier.Add(new DreierWaagerechtLeftKoordinate(k.X, k.Y));
            //yield return new DreierWaagerechtLeftKoordinate(k.X, k.Y);
            //yield return new DreierWaagerechtCenterKoordinate(k.X, k.Y);
            //yield return new DreierWaagerechtRightKoordinate(k.X, k.Y);
            //yield return new DreierSenkrechtTopKoordinate(k.X, k.Y);
            //yield return new DreierSenkrechtCenterKoordinate(k.X, k.Y);
            //yield return new DreierSenkrechtBottomKoordinate(k.X, k.Y);
            return dreier;
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
        internal static List<IDreier> AlleDreierZuKoordinatenpaarAsList(IKoordinatenpaar kPaar)
        {
            //yield return AlleDreierZuKoordinate(kPaar.Eins);
            //yield return AlleDreierZuKoordinate(kPaar.Zwei);
            List<IDreier> dreier = new List<IDreier>();
            dreier.Add(new DreierWaagerechtLeftKoordinate(kPaar.Eins.X, kPaar.Eins.Y));
            dreier.Add(new DreierWaagerechtCenterKoordinate(kPaar.Eins.X, kPaar.Eins.Y));
            dreier.Add(new DreierWaagerechtRightKoordinate(kPaar.Eins.X, kPaar.Eins.Y));
            dreier.Add(new DreierSenkrechtTopKoordinate(kPaar.Eins.X, kPaar.Eins.Y));
            dreier.Add(new DreierSenkrechtCenterKoordinate(kPaar.Eins.X, kPaar.Eins.Y));
            dreier.Add(new DreierSenkrechtBottomKoordinate(kPaar.Eins.X, kPaar.Eins.Y));

            dreier.Add(new DreierWaagerechtLeftKoordinate(kPaar.Zwei.X, kPaar.Zwei.Y));
            dreier.Add(new DreierWaagerechtCenterKoordinate(kPaar.Zwei.X, kPaar.Zwei.Y));
            dreier.Add(new DreierWaagerechtRightKoordinate(kPaar.Zwei.X, kPaar.Zwei.Y));
            dreier.Add(new DreierSenkrechtTopKoordinate(kPaar.Zwei.X, kPaar.Zwei.Y));
            dreier.Add(new DreierSenkrechtCenterKoordinate(kPaar.Zwei.X, kPaar.Zwei.Y));
            dreier.Add(new DreierSenkrechtBottomKoordinate(kPaar.Zwei.X, kPaar.Zwei.Y));
            return dreier;
        }

        // Bekommt eine Liste von Dreiern. Diese Dreier werden überprüft.
        // Jeder Dreier der dessen Spielsteine gleich sind wird zurückgegeben.
        // Es sollten also immer die Dreier zu eier Koordinate bzw. einem Koordinatenpaar übergeben werden.
        // Wichtig ist dann die Anzahl an Dreiern die zurückgegeben werden.
        internal static IEnumerable<IDreier> SelberSpielstein(IEnumerable<IDreier> dreier, Brett brett)
        {
            bool hasDreierSelbeFarbe;
            IDreier drei;
            for (int x = 0; x < dreier.Count(); x++)
            {
                drei = dreier.ElementAt(x);
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
        internal static int SelberSpielsteinCount_Backup(List<IDreier> dreier, Brett brett)
        {
            int Count = 0;
            bool hasDreierSelbeFarbe;
            //TimeLog.TimeStop("1");
            foreach (var drei in dreier)
            {
                hasDreierSelbeFarbe = false;
                try
                {
                    TimeLog.TimeStop("1");
                    if ((brett.getSpielstein(drei.Eins) != 0) &&
                       (brett.getSpielstein(drei.Eins) == brett.getSpielstein(drei.Zwei)) &&
                       (brett.getSpielstein(drei.Eins) == brett.getSpielstein(drei.Drei)))
                    {
                        hasDreierSelbeFarbe = true;
                    }
                    TimeLog.TimeStop("2");
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    hasDreierSelbeFarbe = false;
                }
                if (hasDreierSelbeFarbe)
                {
                    Count++;
                }
            }
            //TimeLog.TimeStop("2");
            return Count;
        }
        internal static int SelberSpielsteinCount(List<IDreier> dreier, Brett brett)
        {
            int Count = 0;
            bool hasDreierSelbeFarbe;
            //TimeLog.TimeStop("1");
            IDreier drei;
            for (int x = 0; x < dreier.Count(); x++)
            {
                drei = dreier.ElementAt(x);
                hasDreierSelbeFarbe = false;
                try
                {
                    TimeLog.TimeStop("1");
                    //if (brett.getSpielstein(drei.Eins) == brett.getSpielstein(drei.Zwei))// && 
                    //   //(brett.getSpielstein(drei.Eins) == brett.getSpielstein(drei.Drei)))
                    //{
                    if (1 == 1 && 1 == 2)
                    {
                        hasDreierSelbeFarbe = true;
                    }
                    TimeLog.TimeStop("2");
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    hasDreierSelbeFarbe = false;
                }
                if (hasDreierSelbeFarbe)
                {
                    Count++;
                }
            }
            //TimeLog.TimeStop("2");
            return Count;
        }

        // Tauscht die Werte auf einem Brett eines Koordinatenpaars
        internal static Brett TauscheKoordinatenpaarWertAufBrett(Brett brett, IKoordinatenpaar kPaar)
        {
            int Werttmp;
            Werttmp = brett.getSpielstein(kPaar.Eins);
            brett.setSpielstein(kPaar.Eins, brett.getSpielstein(kPaar.Zwei));
            brett.setSpielstein(kPaar.Zwei, Werttmp);
            return brett;
        }

        internal static int CountWaagerechtLinksSelbeFarbe(Brett brett, Koordinate k, int Farbe)
        {
            // zählt die anzahl an selber Farbe links ab Koordinate, verwendet aber übergebene Farbe zur Prüfung
            int iReturnValue = 0;
            for (int x = k.X - 1; x > 0; x--)
            {
                if (brett.getSpielstein(x, k.Y) == Farbe)
                {
                    iReturnValue++;
                }
                else
                {
                    break;
                }
            }
            return iReturnValue;
        }
        internal static int CountWaagerechtRechtsSelbeFarbe(Brett brett, Koordinate k, int Farbe)
        {
            // zählt die anzahl an selber Farbe links ab Koordinate, verwendet aber übergebene Farbe zur Prüfung
            int iReturnValue = 0;
            for (int x = k.X + 1; x <= Brett.MaxAnzahlSpalten; x++)
            {
                if (brett.getSpielstein(x, k.Y) == Farbe)
                {
                    iReturnValue++;
                }
                else
                {
                    break;
                }
            }
            return iReturnValue;
        }
        internal static int CountSenkrechtObenSelbeFarbe(Brett brett, Koordinate k, int Farbe)
        {
            // zählt die anzahl an selber Farbe links ab Koordinate, verwendet aber übergebene Farbe zur Prüfung
            int iReturnValue = 0;
            for (int y = k.Y + 1; y <= Brett.MaxAnzahlReihen; y++)
            {
                if (brett.getSpielstein(k.X, y) == Farbe)
                {
                    iReturnValue++;
                }
                else
                {
                    break;
                }
            }
            return iReturnValue;
        }
        internal static int CountSenkrechtUntenSelbeFarbe(Brett brett, Koordinate k, int Farbe)
        {
            // zählt die anzahl an selber Farbe links ab Koordinate, verwendet aber übergebene Farbe zur Prüfung
            int iReturnValue = 0;
            for (int y = k.Y - 1; y > 0; y--)
            {
                if (brett.getSpielstein(k.X, y) == Farbe)
                {
                    iReturnValue++;
                }
                else
                {
                    break;
                }
            }
            return iReturnValue;
        }

        internal static int CountWaagerechtSelbeFarbe(Brett brett, Koordinate k, int Farbe)
        {
            int value = 1 + CountWaagerechtLinksSelbeFarbe(brett, k, Farbe) + CountWaagerechtRechtsSelbeFarbe(brett, k, Farbe);
            if (value >= 3)
            {
                return value;
            }
            else
            {
                return 0;
            }
        }
        internal static int CountSenkrechtSelbeFarbe(Brett brett, Koordinate k, int Farbe)
        {
            int value = 1 + CountSenkrechtObenSelbeFarbe(brett, k, Farbe) + CountSenkrechtUntenSelbeFarbe(brett, k, Farbe);
            if (value >= 3)
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        internal static int CountSelbeFarbeZuKoordinate(Brett brett, Koordinate k, int Farbe)
        {
            return CountWaagerechtSelbeFarbe(brett, k, Farbe) +
                   CountSenkrechtSelbeFarbe(brett, k, Farbe);
        }
        internal static int CountSelbeFarbeZuKoordinatenpaar(Brett brett, IKoordinatenpaar kPaar, int farbe1, int farbe2)
        {
            return CountSelbeFarbeZuKoordinate(brett, kPaar.Eins, farbe1) + CountSelbeFarbeZuKoordinate(brett, kPaar.Zwei, farbe2);
        }

        public static void KoordinatenpaarTauschenUndLoeschen(Brett brett, IKoordinatenpaar kPaar)
        {
            // ein Koordinatenpaar tauschen und die angrenzenden gleichen Felder erstmal nur mit 0 auffüllen.
            brett.TauscheKoordinatenWerte(kPaar.Eins, kPaar.Zwei);
            // nach links
            KoordinateLoeschen(brett, kPaar.Eins);
            KoordinateLoeschen(brett, kPaar.Zwei);
        }
        internal static void KoordinateLoeschen(Brett brett, Koordinate k)
        {
            bool isLoeschen = false;
            int iFarbe;
            iFarbe = brett.getSpielstein(k);

            if (CountWaagerechtSelbeFarbe(brett, k, iFarbe) >= 3)
            {
                for (int x = k.X - 1; x > 0; x--)
                {
                    if (brett.getSpielstein(x, k.Y) == iFarbe)
                    {
                        brett.setSpielstein(x, k.Y, 0);
                        isLoeschen = true;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int x = k.X + 1; x <= Brett.MaxAnzahlSpalten; x++)
                {
                    if (brett.getSpielstein(x, k.Y) == iFarbe)
                    {
                        brett.setSpielstein(x, k.Y, 0);
                        isLoeschen = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

           
            if (CountSenkrechtSelbeFarbe(brett, k, iFarbe) >= 3)
            {
                for (int y = k.Y + 1; y <= Brett.MaxAnzahlReihen; y++)
                {
                    if (brett.getSpielstein(k.X, y) == iFarbe)
                    {
                        brett.setSpielstein(k.X, y, 0);
                        isLoeschen = true;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int y = k.Y - 1; y > 0; y--)
                {
                    if (brett.getSpielstein(k.X, y) == iFarbe)
                    {
                        brett.setSpielstein(k.X, y, 0);
                        isLoeschen = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (isLoeschen)
            {
                brett.setSpielstein(k.X, k.Y, 0);
            }
            
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider c = new RNGCryptoServiceProvider();
            // Ein integer benötigt 4 Byte
            byte[] randomNumber = new byte[4];
            // dann füllen wir den Array mit zufälligen Bytes
            c.GetBytes(randomNumber);
            // schließlich wandeln wir den Byte-Array in einen Integer um
            int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));
            // da bis jetzt noch keine Begrenzung der Zahlen vorgenommen wurde,
            // wird diese Begrenzung mit einer einfachen Modulo-Rechnung hinzu-
            // gefügt
            return result % max + min;
        }
    }
}
