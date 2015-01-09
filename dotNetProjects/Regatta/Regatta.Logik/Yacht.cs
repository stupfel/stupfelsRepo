
namespace Regatta.Logik
{
    class Yacht
    {
        private Position _position;

        private RegattaLogik.Windrichtung _richtung;
        private bool _spinnackerAktiv;
        private byte _AnzahlBoeen;

        public Yacht(int x, int y, RegattaLogik.Windrichtung richtung)
        {
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

    }
}
