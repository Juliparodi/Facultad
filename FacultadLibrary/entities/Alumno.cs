using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.entities
{
    public sealed class Alumno : Persona
    {
        int _codigo;

        public Alumno() { }
        public Alumno(int codigo, string nombre, string apellido, DateTime fechaNac) : base(apellido, fechaNac, nombre)
        {
            _codigo = codigo;
        }

        public Alumno(int codigo)
        {
            _codigo = codigo;
        }

        public int Codigo { get => _codigo; set => _codigo = value; }

        public override string getCredencial()
        {
            return $"Codigo {this.Codigo}) {this.Apellido} {this.Nombre}";
        }

        public override string ToString()
        {
            return getCredencial();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (!(obj is Alumno))
            {
                return false;
            }

            Alumno a = (Alumno)obj;

            return a.Codigo == this.Codigo;
        }
    }
}
