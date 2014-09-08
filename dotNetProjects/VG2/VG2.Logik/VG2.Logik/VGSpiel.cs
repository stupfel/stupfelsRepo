using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG2.Logik.B;

namespace VG2.Logik
{
    public class VGSpiel
    {
        Brett Spielbrett;

        public void initialisiereSpiel()
        {
            Spielbrett = new Brett();
        }

        public void LegeSteinInSpalte(int Spalte)
        {
            switch (Spielbrett.Zustand)
	        {
                case Brett.Zustaende.RotIstAmZug:
                    Spielbrett.SpieleStein(Brett.SPIELSTEIN_ROT, Spalte);
                    Spielbrett.Zustand = Brett.Zustaende.GelbIstAmZug;
                break;
                case Brett.Zustaende.GelbIstAmZug:
                    Spielbrett.SpieleStein(Brett.SPIELSTEIN_GELB, Spalte);
                    Spielbrett.Zustand = Brett.Zustaende.RotIstAmZug;
                break;
                case Brett.Zustaende.RotHatGewonnen:

                break;
                case Brett.Zustaende.GelbHatGewonnen:

                break;


	        }

            
        }
    }
}
