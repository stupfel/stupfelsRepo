using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG
{
    public class GameController
    {
        private VGController vgc;

        public GameController()
        {
            this.GameLoop();
        }

        public void init()
        {
            vgc = new VGController();
        }

        public void GameLoop()
        {
            bool isActive = true;
            bool isEingabeOK = false;
            int Playerstein;

            while (isActive)
            {
                if (vgc == null)
                {
                    init();
                }

                // Wer ist dran
                Playerstein = vgc.getNextPlayerStein();
                if (Playerstein == VGController.SteinLeer)
                {
                    Playerstein = vgc.getStartspieler();
                }

                while (isEingabeOK == false)
                {
                    Console.WriteLine("Spieler " + Playerstein + " Bitte ein Stein einwerfen: (1-7)");
                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Key == ConsoleKey.D1 ||
                        info.Key == ConsoleKey.D2 ||
                        info.Key == ConsoleKey.D3 ||
                        info.Key == ConsoleKey.D4 ||
                        info.Key == ConsoleKey.D5 ||
                        info.Key == ConsoleKey.D6 ||
                        info.Key == ConsoleKey.D7)
                    {
                        isEingabeOK = true;
                    }
                    else
                    {
                        Console.WriteLine("Ungültig");
                        isEingabeOK = false;
                    }
                }

            }
        }
    }
}
