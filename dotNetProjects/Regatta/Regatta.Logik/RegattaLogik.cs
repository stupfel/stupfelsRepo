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
            List<Zug> _listZug = new List<Zug>();
            Zug _currentZug;
            int _AnzahlFelderMax;
            int _AnzzahlFelderMoeglich;
            bool _SpinnakerMoeglich = false;

            yacht.drehe(Richtung.links);
            for (int i = 0; i <= 2; i++)
            {
                _currentZug = new Zug();
                _AnzahlFelderMax = yacht.getAnzahlFelder(windrichtung, false, ref _SpinnakerMoeglich);
                yacht.move(_AnzahlFelderMax, out _AnzzahlFelderMoeglich);
                _currentZug.Laenge = _AnzzahlFelderMoeglich;
                _currentZug.Pos = yacht.Pos;
                _currentZug.Richtung = yacht.Richtung;
                _currentZug.IsSpinnakerMoeglich = _SpinnakerMoeglich;
                _listZug.Add(_currentZug);
                yacht.drehe(Richtung.rechts);
            }

            return _listZug;
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
