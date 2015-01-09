﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regatta.Logik
{
    public class Position
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int X
        {
            get {return _x; }
        }

        public int Y
        {
            get { return _y; }
        }
    }
}
