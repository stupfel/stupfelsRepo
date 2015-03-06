using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Regatta.Logik;

namespace Regatta.GUI
{
    public class RegattaViewModel
    {
        RegattaBrett brett;

        public RegattaViewModel()
        {
            brett = new RegattaBrett();
        }
    }
}
