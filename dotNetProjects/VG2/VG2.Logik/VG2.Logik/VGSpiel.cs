﻿using System;
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

        public VGSpiel()
        { }

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
            }

            if (Spielbrett.Gewinner() == Brett.SPIELSTEIN_ROT)
            {
                Spielbrett.Zustand = Brett.Zustaende.RotHatGewonnen;
            }
            else if(Spielbrett.Gewinner() == Brett.SPIELSTEIN_GELB)
            {
                Spielbrett.Zustand = Brett.Zustaende.GelbHatGewonnen;
            }
        }
    
        public string getSpielbrettToString()
        {
            return Spielbrett.getBrettAsString();
        }
    }
}
