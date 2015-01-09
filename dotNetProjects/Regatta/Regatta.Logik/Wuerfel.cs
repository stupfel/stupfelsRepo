using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regatta.Logik
{
    class Wuerfel
    {
        int _min;
        int _max;

        public Wuerfel(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public int wuerfeln()
        {
            Random r = new Random();
            return r.Next(_min, _max + 1);
        }
    }
}
