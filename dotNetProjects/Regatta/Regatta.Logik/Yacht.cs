using System.Collections.Generic;

namespace Regatta.Logik
{
    public class Yacht
    {
        private int _id;
        private RegattaBrett _Brett;
        private Position _position;

        private RegattaLogik.Windrichtung _richtung;
        private bool _spinnackerAktiv;
        private int _AnzahlBoeen;

        public Yacht(int id, RegattaBrett Brett, int x, int y, RegattaLogik.Windrichtung richtung)
        {
            _id = id;
            _Brett = Brett;
            _position = new Position(x, y);
            _richtung = richtung;
            _spinnackerAktiv = false;
            _AnzahlBoeen = 2;
        }

        public RegattaLogik.Windrichtung Richtung
        {
            get { return _richtung;  }
        }

        public void drehe(RegattaLogik.Richtung drehrichtung)
        {
            switch (drehrichtung)
            {
                case RegattaLogik.Richtung.links:
                    if (_richtung == RegattaLogik.Windrichtung.N)
                    {
                        _richtung = RegattaLogik.Windrichtung.NW;
                    }
                    else
                    {
                        _richtung = _richtung - 1;
                    }
                    break;
                case RegattaLogik.Richtung.rechts:
                    if (_richtung == RegattaLogik.Windrichtung.NW)
                    {
                        _richtung = RegattaLogik.Windrichtung.N;
                    }
                    else
	                {
                        _richtung = _richtung + 1;
	                }
                    break;
            }
        }

        // Anzahl der möglichen Felder, die gesegelt werden können
        // Abhängig von Windrichtung, Böe nutzen und Spinnacker
        public int getAnzahlFelder(RegattaLogik.Windrichtung windrichtung, bool BoeeNutzen)
        {
            int AnzahlFelder = 0;

            switch (getWindwinkel(windrichtung))
            {
                case RegattaLogik.Windwinkel.Gegenwind:
                    break;
                case RegattaLogik.Windwinkel.SchraegVorne:
                    AnzahlFelder = AnzahlFelder + 1;
                    break;
                case RegattaLogik.Windwinkel.Seitlich:
                    AnzahlFelder = AnzahlFelder + 2;
                    break;
                case RegattaLogik.Windwinkel.SchraegHinten:
                    AnzahlFelder = AnzahlFelder + 3;
                    break;
                case RegattaLogik.Windwinkel.Hinten:
                    AnzahlFelder = AnzahlFelder + 2;
                    break;
                default:
                    break;
            }

            if (BoeeNutzen)
            {
                AnzahlFelder = AnzahlFelder + 1;
            }

            //Spinnacker darf genutzt werden wenn:
            //Wind von Hinten
            //Wind von SchraegHinten
            //Ist der Spinnacker aktiv und es ist ein anderer Windwinkel ist die Zuglänge 0, denn um diese Richtung zu fahren
            //muss der Spinnacker eingezogen werden.
            if (_spinnackerAktiv)
            {
                AnzahlFelder = AnzahlFelder + 1;
            }
            else
            {
                aaa
            }

            return AnzahlFelder;
        }

        public void move(int AnzahlFelder, out int MoeglicheFelder)
        {
            MoeglicheFelder = 0;

            int dx = 0;
            int dy = 0;

            int xOld;
            int yOld;

            IEnumerable<Yacht> Yachten;
            bool hasColission;
 
            switch (_richtung)
            {
                case RegattaLogik.Windrichtung.N:
                    dy = 1;
                    break;
                case RegattaLogik.Windrichtung.NO:
                    dx = 1;
                    dy = 1;
                    break;
                case RegattaLogik.Windrichtung.O:
                    dx = 1;
                    break;
                case RegattaLogik.Windrichtung.SO:
                    dx = 1;
                    dy = -1;
                    break;
                case RegattaLogik.Windrichtung.S:
                    dy = -1;
                    break;
                case RegattaLogik.Windrichtung.SW:
                    dx = -1;
                    dy = -1;
                    break;
                case RegattaLogik.Windrichtung.W:
                    dx = -1;
                    break;
                case RegattaLogik.Windrichtung.NW:
                    dx = -1;
                    dy = +1;
                    break;
                default:
                    break;
            }

            hasColission = false;
            for (int iFelder = 0; iFelder < AnzahlFelder; iFelder++)
            {
                xOld = _position.X;
                yOld = _position.Y;

                _position.X = _position.X + dx;
                _position.Y = _position.Y + dy;
                MoeglicheFelder = MoeglicheFelder + 1;

                //Kollision?
                Yachten = _Brett.getYachten();
                foreach (Yacht Yacht_tmp in Yachten)
                {
                    if (!this.Equals(Yacht_tmp))
                    {
                        if (this.SamePosition(Yacht_tmp))
                        {
                            hasColission = true;
                            break;
                        }
                    }
                }
                if (hasColission)
                {
                    _position.X = xOld;
                    _position.Y = yOld;
                    MoeglicheFelder = MoeglicheFelder - 1;
                    break;
                }
            }
        }

        public RegattaLogik.Windwinkel getWindwinkel(RegattaLogik.Windrichtung windrichtung)
        {
            return RegattaLogik.BerechneWindwinkel(windrichtung, this);
        }
    
        public void BoeeNutzen()
        {
            _AnzahlBoeen = _AnzahlBoeen - 1;
        }

        public void SpinnackerSetzen()
        {
            _spinnackerAktiv = true;
        }

        public void SpinnackerEinzahlen()
        {
            _spinnackerAktiv = false;
        }

        public bool SamePosition(Yacht y)
        {
            // If parameter is null return false:
            if ((object)y == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (_position.X == y._position.X) && (_position.Y == y._position.Y);
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Yacht y = obj as Yacht;
            if ((System.Object)y == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (_position.X == y._position.X) && (_position.Y == y._position.Y) && (_id != y._id);
        }
        public bool Equals(Yacht y)
        {
            // If parameter is null return false:
            if ((object)y == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (_position.X == y._position.X) && (_position.Y == y._position.Y) && (_id != y._id);
        }
        public override int GetHashCode()
        {
            return _position.X ^ _position.Y ^ _id;
        }
        public int id
        {
            get { return id; }
        }

        public Position Pos
        {
            get { return _position; }
            set { _position = value; }
        }

    }
}
