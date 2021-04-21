using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.entities
{
   public class Docente : Empleado
    {
        public override string getNombreCompleto()
        {
            return $"Docente {this.Apellido}";
        }

        public override string ToString()
        {
            return $"{this.getNombreCompleto()} - {base.ToString()} -";
        }
    }
}
