using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regatta.Logik;

namespace Regatta.Logik
{
    public class Zug
    {
        Position _pos;
        int _laenge;
        RegattaLogik.Windrichtung _richtung;
        bool _isBoeeMoeglich;
     
        public Position Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public int Laenge
        {
            get { return _laenge; }
            set { _laenge = value; }
        }

        public RegattaLogik.Windrichtung Richtung
        {
            get { return _richtung; }
            set { _richtung = value; }
        }

        public bool IsBoeeMoeglich
        {
            get { return _isBoeeMoeglich; }
            set { _isBoeeMoeglich = value; }
        }
    }
}
