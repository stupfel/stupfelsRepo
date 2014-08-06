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

                isEingabeOK = false;
                while (isEingabeOK == false)
                {
                    Console.WriteLine("Spieler " + Playerstein + " Bitte ein Stein einwerfen: (1-7)");
                    ConsoleKeyInfo info = Console.ReadKey();
                    switch (info.Key)
                    {
                        case ConsoleKey.D1:
                            isEingabeOK = vgc.SetSpielstein(Playerstein, 1);
                            break;
                        case ConsoleKey.D2:
                            isEingabeOK = vgc.SetSpielstein(Playerstein, 2);
                            break;
                        case ConsoleKey.D3:
                            isEingabeOK = vgc.SetSpielstein(Playerstein, 3);
                            break;
                        case ConsoleKey.D4:
                            isEingabeOK = vgc.SetSpielstein(Playerstein, 4);
                            break;
                        case ConsoleKey.D5:
                            isEingabeOK = vgc.SetSpielstein(Playerstein, 5);
                            break;
                        case ConsoleKey.D6:
                            isEingabeOK = vgc.SetSpielstein(Playerstein, 6);
                            break;
                        case ConsoleKey.D7:
                            isEingabeOK = vgc.SetSpielstein(Playerstein, 7);
                            break;
                        default:
                            isEingabeOK = false;
                            break;
                    }

                    if (isEingabeOK)
                    {
                        //isEingabeOK = true;
                    }
                    else
                    {
                        Console.WriteLine("Ungültig");
                        //isEingabeOK = false;
                    }
                }

                if (vgc.checkPlayerWin(Playerstein))
                {

                    Console.WriteLine("Spieler " + Playerstein + " hat gewonnen.");
                }


                vgc.printSpielbrett();
            }
        }
    }
}
