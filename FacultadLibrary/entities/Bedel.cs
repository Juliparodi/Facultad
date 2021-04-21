using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.entities
{
   public class Bedel : Empleado
    {
        string _apodo;

        public string Apodo { get => _apodo; set => _apodo = value; }

        public override string getNombreCompleto()
        {
           return $"Bedel {this.Apellido}";
        }

        public override string ToString()
        {
            return $"{this.getNombreCompleto()} - {base.ToString()} -";
        }
    }
}
