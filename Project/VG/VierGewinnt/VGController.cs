using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt
{
    public class VGController
    {
        /*  Spielfeld
            6 Reihen u. 7 Spalten        
        
         *  -> 2 Dim Array
         * 
         */
        private int[,] _ArrSpielfeld;

        const int SteinPlayer1 = 1;
        const int SteinPlayer2 = 2;
        public const int SteinLeer = 0;

        const int MaxReihen = 6;
        const int MaxSpalten = 7;

        public VGController()
        {
            _ArrSpielfeld = new int[MaxReihen, MaxSpalten];
        }

        public int getStartspieler()
        {
            Random r = new Random();
            return r.Next(SteinPlayer1, SteinPlayer2);
        }

        /*
         * prüft und setzt den Spielerstein in die angegebene Spalte
         * Return True wenn erfolgreich gesetzt. False wenn nicht möglich.
         */
        public bool SetSpielstein(int _PlayerStein, int _Spalte)
        {
            bool returnValue = false;
            if (_Spalte < 1 || _Spalte > MaxSpalten)
            {
                returnValue = false;
            }
            else
            {
                // Prüfe ob in der obersten Reihe der angegebenen Spalte noch Platz ist
                if (_ArrSpielfeld[0, _Spalte - 1] != SteinLeer)
                {
                    returnValue = false;
                }
                else
                {
                    for (int iReihe = MaxReihen - 1; iReihe >= 0; iReihe--)
                    {
                        if (_ArrSpielfeld[iReihe, _Spalte] == SteinLeer)
                        {
                            _ArrSpielfeld[iReihe, _Spalte] = _PlayerStein;
                            returnValue = true;
                            break;
                        }
                    }
                }
            }
            return returnValue;
        }

        /*
         * Gibt immer die Anzahl des übergebenen Steins 
         */
        public int getAnzahlPlayerStein(int _PlayerStein)
        {
            int intAnzahlPlayerStein = 0;

            for (int iReihe = 0; iReihe < MaxReihen; iReihe++)
            {
                for (int iSpalte = 0; iSpalte < MaxSpalten; iSpalte++)
                {
                    if (_ArrSpielfeld[iReihe, iSpalte] == _PlayerStein)
                    {
                        intAnzahlPlayerStein = intAnzahlPlayerStein + 1;
                    }
                }
            }
            return intAnzahlPlayerStein;
        }

        /*
         *  Gibt den Playerstein zurück der als nächstes am Zug ist.
         *  Wenn keiner am Zug ist wird stein leer zurück gegeben.
         */
        public int getNextPlayerStein()
        {
            int intAnzahlPlayer1 = 0;
            int intAnzahlPlayer2 = 0;

            intAnzahlPlayer1 = getAnzahlPlayerStein(SteinPlayer1);
            intAnzahlPlayer2 = getAnzahlPlayerStein(SteinPlayer2);

            if (intAnzahlPlayer1 > intAnzahlPlayer2)
            {
                return SteinPlayer2;
            }
            else if (intAnzahlPlayer1 < intAnzahlPlayer2)
            {
                return SteinPlayer1;
            }
            else
            {
                return SteinLeer;
            }
        }

        /*
         * Prüft ob ein Stein gewonnen hat. 
         * d.h. 4 Steine müssen nebeneinander oder diagonal sein.
         */
        public bool checkPlayerWin(int _PlayerStein)
        {
            bool returnValue = false;
            if (checkArrayDiagonal(this._ArrSpielfeld, _PlayerStein) || checkArrayWaagerecht(this._ArrSpielfeld, _PlayerStein) || checkArraySenkrecht(this._ArrSpielfeld, _PlayerStein))
            {
                returnValue = true;
            }
            return returnValue;
        }

        /* Statische Hilfsfunktionen */
        public static bool checkArrayWaagerecht(int[,] _ArrFeld, int _Pruefwert)
        {
            bool returnValue = false;

            for (int iReihe = 0; iReihe < MaxReihen; iReihe++)
            {
                for (int iSpalte = 0; iSpalte < MaxReihen; iSpalte++)
                {
                    //Console.WriteLine("Check " + iReihe + " " + iSpalte);
                    try
                    {
                        if ((_ArrFeld[iReihe, iSpalte] == _Pruefwert) &&
                            (_ArrFeld[iReihe, iSpalte + 1] == _Pruefwert) &&
                            (_ArrFeld[iReihe, iSpalte + 2] == _Pruefwert) &&
                            (_ArrFeld[iReihe, iSpalte + 3] == _Pruefwert))
                        {
                            returnValue = true;
                        }
                        else
                        { }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
            return returnValue;
        }
        public static bool checkArraySenkrecht(int[,] _ArrFeld, int _Pruefwert)
        {
            bool returnValue = false;

            for (int iReihe = 0; iReihe < MaxReihen; iReihe++)
            {
                for (int iSpalte = 0; iSpalte < MaxReihen; iSpalte++)
                {
                    //Console.WriteLine("Check " + iReihe + " " + iSpalte);
                    try
                    {
                        if ((_ArrFeld[iReihe, iSpalte] == _Pruefwert) &&
                            (_ArrFeld[iReihe + 1, iSpalte] == _Pruefwert) &&
                            (_ArrFeld[iReihe + 2, iSpalte] == _Pruefwert) &&
                            (_ArrFeld[iReihe + 3, iSpalte] == _Pruefwert))
                        {
                            returnValue = true;
                        }
                        else
                        { }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
            return returnValue;

        }
        public static bool checkArrayDiagonal(int[,] _ArrFeld, int _Pruefwert)
        {
            bool returnValue = false;

            for (int iReihe = 0; iReihe < MaxReihen; iReihe++)
            {
                for (int iSpalte = 0; iSpalte < MaxReihen; iSpalte++)
                {
                    //Console.WriteLine("Check " + iReihe + " " + iSpalte);
                    try
                    {
                        if ((_ArrFeld[iReihe, iSpalte] == _Pruefwert) &&
                            (_ArrFeld[iReihe - 1, iSpalte + 1] == _Pruefwert) &&
                            (_ArrFeld[iReihe - 2, iSpalte + 2] == _Pruefwert) &&
                            (_ArrFeld[iReihe - 3, iSpalte + 3] == _Pruefwert))
                        {
                            returnValue = true;
                        }
                        else
                        { }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }

                    try
                    {
                        if ((_ArrFeld[iReihe, iSpalte] == _Pruefwert) &&
                            (_ArrFeld[iReihe + 1, iSpalte + 1] == _Pruefwert) &&
                            (_ArrFeld[iReihe + 2, iSpalte + 2] == _Pruefwert) &&
                            (_ArrFeld[iReihe + 3, iSpalte + 3] == _Pruefwert))
                        {
                            returnValue = true;
                        }
                        else
                        { }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
            return returnValue;

        }

    }
}
