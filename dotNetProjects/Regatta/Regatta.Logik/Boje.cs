using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regatta.Logik
{
    class Boje
    {
        private Position _position;

        public Boje(int x, int y)
        {
            _position = new Position(x, y);
        }

        public int PosX
        {
            get { return _position.X; }
        }
    
        public int PosY
        {
            get { return _position.Y; }
        }

        public  Position Position
        {
            get { return _position; }
        }
    
    }


}
