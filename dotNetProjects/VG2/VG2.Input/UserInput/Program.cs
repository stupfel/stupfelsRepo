using System;
using VG2.Logik;

namespace UserInput
{
    class Program
    {
        static void Main(string[] args)
        {

            VGSpiel VierGewinnt = new VGSpiel();
            VierGewinnt.initialisiereSpiel();

            ConsoleKeyInfo info;
            do
            {
                Console.WriteLine(VierGewinnt.getSpielbrettToString());

                info = Console.ReadKey();
                Console.WriteLine("\n");
                try
                {
                    VierGewinnt.LegeSteinInSpalte(ConvertInfoKeyToSpalte(info));
                }
                catch (VG2.Logik.B.Exceptions.SpalteVollException e)
                {
                    Console.WriteLine("Die Spalte ist voll! - Bitte neue Spalte wählen!");
                }
               

            } while (info.Key != ConsoleKey.D0);

            Console.WriteLine(VierGewinnt.getSpielbrettToString());
            Console.WriteLine("Ferig");
        }

        static int ConvertInfoKeyToSpalte(ConsoleKeyInfo infokey)
        {
            int returnValue;
            switch (infokey.Key)
            {
                case ConsoleKey.D1:
                    returnValue = 1;
                    break;
                case ConsoleKey.D2:
                    returnValue = 2;
                    break;
                case ConsoleKey.D3:
                    returnValue = 3;
                    break;
                case ConsoleKey.D4:
                    returnValue = 4;
                    break;
                case ConsoleKey.D5:
                    returnValue = 5;
                    break;
                case ConsoleKey.D6:
                    returnValue = 6;
                    break;
                case ConsoleKey.D7:
                    returnValue = 7;
                    break;
                default:
                    returnValue = -1;
                    break;
            }
            return returnValue;
        }
    }
}
