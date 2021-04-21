using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.entities
{
   public class Directivo : Empleado
    {
        public override string getNombreCompleto()
        {
            return $"Director {this.Apellido}";
        }

        public override string ToString()
        {
            return $"{this.getNombreCompleto()} - {base.ToString()} -";
        }
    }
}
