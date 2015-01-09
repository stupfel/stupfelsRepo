using Regatta.Logik;

namespace Regatta.Logik
{
    class Windrose
    {
        private RegattaLogik.Windrichtung _windrichtung;

        public Windrose(RegattaLogik.Windrichtung windrichtung)
        {
            _windrichtung = windrichtung;
        }

        public RegattaLogik.Windrichtung Windrichtung
        {
            get { return _windrichtung;  }
        }

        public void Drehe(RegattaLogik.Richtung richtung)
        {
            switch (richtung)
            {
                case RegattaLogik.Richtung.links:
                    if (_windrichtung == RegattaLogik.Windrichtung.N)
                    {
                        _windrichtung = RegattaLogik.Windrichtung.NW;
                    }
                    else
                    {
                        _windrichtung = _windrichtung - 1;
                    }
                    break;
                case RegattaLogik.Richtung.rechts:
                    if (_windrichtung == RegattaLogik.Windrichtung.NW)
                    {
                        _windrichtung = RegattaLogik.Windrichtung.N;
                    }
                    else
	                {
                        _windrichtung = _windrichtung + 1;
	                }
                    break;
            }
        }
    }
}
