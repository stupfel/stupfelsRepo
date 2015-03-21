using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regatta.Logik
{
    public class RegattaController
    {
        RegattaBrett brett;

        public RegattaController()
        {
            init(2);
        }

        private void init(int AnzahlSpieler)
        {
            brett = new RegattaBrett();
            for (int i = 0; i < AnzahlSpieler; i++)
            {
                brett.CreateYacht();
            }
            
        }
    }
}
