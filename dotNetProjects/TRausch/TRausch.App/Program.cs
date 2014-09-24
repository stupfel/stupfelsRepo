using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRausch.App
{
    class Program
    {
        static void Main(string[] args)
        {
            TRausch.Logik.TRauschController tController = new Logik.TRauschController();
            

            tController.initialisiereSpiel();
            Console.Write(tController.getSpielbrettToString());
            Console.WriteLine(tController.SucheKoordinatenpaar().ToString());
            tController.LoescheKoordinatenpaar();
            Console.Write(tController.getSpielbrettToString());

            tController.initialisiereSpiel();
            Console.Write(tController.getSpielbrettToString());
            Console.WriteLine(tController.SucheKoordinatenpaar().ToString());
            tController.LoescheKoordinatenpaar();
            Console.Write(tController.getSpielbrettToString());

            tController.initialisiereSpiel();
            Console.Write(tController.getSpielbrettToString());
            Console.WriteLine(tController.SucheKoordinatenpaar().ToString());
            tController.LoescheKoordinatenpaar();
            Console.Write(tController.getSpielbrettToString());

            tController.initialisiereSpiel();
            Console.Write(tController.getSpielbrettToString());
            Console.WriteLine(tController.SucheKoordinatenpaar().ToString());
            tController.LoescheKoordinatenpaar();
            Console.Write(tController.getSpielbrettToString());

            tController.initialisiereSpiel();
            Console.Write(tController.getSpielbrettToString());
            Console.WriteLine(tController.SucheKoordinatenpaar().ToString());
            tController.LoescheKoordinatenpaar();
            Console.Write(tController.getSpielbrettToString());

            Console.Read();
        }
    }
}
