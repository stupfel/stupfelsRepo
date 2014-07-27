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

        //static int[,] _Feld;
        //const int leer = 0;
        //const int gesetzt = 1;
        //const int MaxReihen = 6;
        //const int MaxSpalten = 7;

        static void Main(string[] args)
        {
            GameController gc = new GameController();

            //Console.WriteLine("Start");
            //_Feld = new int[,] {{ 0,0,0,0,0,0,0 },
            //                    { 1,1,1,1,1,0,0 },
            //                    { 0,1,0,0,0,0,0 },
            //                    { 0,1,1,0,0,0,0 },
            //                    { 0,1,0,1,0,0,0 },
            //                    { 0,0,0,0,0,0,0 }};
           
            //Console.WriteLine(VierGewinntController.checkArrayWaagerecht(_Feld, gesetzt));
            //Console.WriteLine(VierGewinntController.checkArraySenkrecht(_Feld, gesetzt));
            //Console.WriteLine(VierGewinntController.checkArrayDiagonal(_Feld, gesetzt));

            ////Debug.WriteLine(checkArrayWaagerecht(_Feld, gesetzt) + "");
            ////Trace.Assert(checkArraySenkrecht(_Feld, gesetzt));


            Console.WriteLine("... Press escape, a, then control X");
            // Call ReadKey method and store result in local variable.
            // ... Then test the result for escape.
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("You pressed escape!");
            }
            // Call ReadKey again and test for the letter a.
            info = Console.ReadKey();
            if (info.KeyChar == 'a')
            {
                Console.WriteLine("You pressed a");
            }
            // Call ReadKey again and test for control-X.
            // ... This implements a shortcut sequence.
            info = Console.ReadKey();
            if (info.Key == ConsoleKey.X &&
                info.Modifiers == ConsoleModifiers.Control)
            {
                Console.WriteLine("You pressed control X");
            }
            Console.Read();

            //Console.WriteLine("Ende");
        }

    }
}
