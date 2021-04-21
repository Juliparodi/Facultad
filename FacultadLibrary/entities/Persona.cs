using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.entities
{
    public abstract class Persona
    {
        protected internal string _apellido;
        protected  internal string _nombre;
        protected internal DateTime fechaNac;

        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public  DateTime FechaNac { get => fechaNac; set => fechaNac = value; }

        protected Persona() { }

        protected Persona(string apellido, DateTime fechaNac, string nombre)
        {
            Apellido = apellido;
            FechaNac = fechaNac;
            Nombre = nombre;
        }

        public abstract string getCredencial();

        public virtual string getNombreCompleto(){
            return $"{this.Nombre}  {this.Apellido}";
        }

        public int Edad(DateTime fechaNac)
        {
            DateTime Now = DateTime.Now;
            return new DateTime(DateTime.Now.Subtract(fechaNac).Ticks).Year - 1;
        }
    }
}
