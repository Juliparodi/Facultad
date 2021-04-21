using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.exceptions
{
    public class AlumnoNotFoundException : Exception
    {
        public AlumnoNotFoundException (string message) : base() { }
    }
}
