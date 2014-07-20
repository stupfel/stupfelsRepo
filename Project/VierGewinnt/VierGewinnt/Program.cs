using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VierGewinnt
{
    class Program
    {

                    static int[,] _Feld;
        const int leer = 0;
        const int gesetzt = 1;
        const int MaxReihen = 6;
        const int MaxSpalten = 7;

        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            _Feld = new int[,] {{ 0,0,0,0,0,0,0 },
                                { 1,1,1,1,1,0,0 },
                                { 0,1,0,0,0,0,0 },
                                { 0,1,1,0,0,0,0 },
                                { 0,1,0,1,0,0,0 },
                                { 0,0,0,0,0,0,0 }};
           
            Console.WriteLine(checkArrayWaagerecht(_Feld, gesetzt));
            Console.WriteLine(checkArraySenkrecht(_Feld, gesetzt));
            Console.WriteLine(checkArrayDiagonal(_Feld, gesetzt));

            //Debug.WriteLine(checkArrayWaagerecht(_Feld, gesetzt) + "");
            //Trace.Assert(checkArraySenkrecht(_Feld, gesetzt));

            Console.WriteLine("Ende");
        }

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
