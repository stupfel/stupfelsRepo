using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRausch.Logik
{
    public class TRauschController
    {
        Brett brett;
        public TRauschController()
        {
            
        }

        public void initialisiereSpiel()
        {
            brett = new Brett();
        }

        public string getSpielbrettToString()
        {
            return brett.getBrettAsString();
        }

        public string SucheKoordinatenpaar()
        {
            return brett.SucheKoordinatenpaar().ToString();
        }
    }
}
