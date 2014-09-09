using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG2.Logik.B.Exceptions
{
    public class SpalteVollException : Exception
    {
        public SpalteVollException()
        { }

        public SpalteVollException(string message)
            : base(message)
        { }
    
        public SpalteVollException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
