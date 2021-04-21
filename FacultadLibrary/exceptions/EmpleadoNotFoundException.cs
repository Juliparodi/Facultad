using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.exceptions
{
    public class EmpleadoNotFoundException : Exception
    {
        public EmpleadoNotFoundException (string message) : base() { }
    }
}
