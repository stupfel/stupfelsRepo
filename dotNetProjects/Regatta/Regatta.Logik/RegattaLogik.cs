using System.Collections.Generic;

namespace Regatta.Logik
{
    public static class RegattaLogik
    {
        public enum Richtung
        {
            links,
            geradeaus,
            rechts
        }

        public enum Windrichtung : byte
        {
            N = 1,
            NO = 2,
            O = 3,
            SO = 4,
            S = 5,
            SW = 6,
            W = 7,
            NW = 8
        }

        public enum Windwinkel
        {
            Gegenwind,
            SchraegVorne,
            Seitlich,
            SchraegHinten,
            Hinten
        }
    
        public static List<Zug> ErmittleZugmoeglichkeiten(RegattaLogik.Windrichtung windrichtung, Yacht yacht, List<Yacht> listYachten)
        {
            // Ermittelt alle Zugmöglichkeiten der aktuellen Yacht
            List<Zug> listZug = new List<Zug>();
            Zug currentZug;

            currentZug = new Zug();
            yacht.drehe(Richtung.links);

            yacht.getAnzahlFelder(yacht.Richtung, windrichtung, false);



            return listZug;
        }

        public static Windwinkel BerechneWindwinkel(Windrichtung windrichtung, Yacht yacht)
        {
            Windwinkel winkel = Windwinkel.Hinten;
            Windrose windroseRechts = new Windrose(windrichtung);
            Windrose windroseLinks = new Windrose(windrichtung);

            if (windrichtung == yacht.Richtung)
            {
                winkel = Windwinkel.Hinten;
            }
            else
            {
                windroseRechts.Drehe(Richtung.rechts);
                windroseLinks.Drehe(Richtung.links);

                // Schräg hinten
                if (windroseRechts.Windrichtung == yacht.Richtung || windroseLinks.Windrichtung == yacht.Richtung)
                {
                    winkel = Windwinkel.SchraegHinten;
                }
                else
                {
                    windroseRechts.Drehe(Richtung.rechts);
                    windroseLinks.Drehe(Richtung.links);

                    //Seite
                    if (windroseRechts.Windrichtung == yacht.Richtung || windroseLinks.Windrichtung == yacht.Richtung)
                    {
                        winkel = Windwinkel.Seitlich;
                    }
                    else
                    {
                        windroseRechts.Drehe(Richtung.rechts);
                        windroseLinks.Drehe(Richtung.links);

                        // Schräg vorne
                        if (windroseRechts.Windrichtung == yacht.Richtung || windroseLinks.Windrichtung == yacht.Richtung)
                        {
                            winkel = Windwinkel.SchraegVorne;
                        }
                        else
                        {
                            winkel = Windwinkel.Gegenwind;
                        }
                    }
                }
            }
            return winkel;
        }
    
    }
}
