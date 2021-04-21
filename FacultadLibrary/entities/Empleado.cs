using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultadLibrary.entities
{
     public abstract class Empleado : Persona
    {
        DateTime _fechaIngreso;
        int _legajo;
        // salarios;

        protected Empleado() { }

        protected Empleado(DateTime fechaIngreso, int legajo)
        {
            _fechaIngreso = fechaIngreso;
            _legajo = legajo;
        }

        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public int Legajo { get => _legajo; set => _legajo = value; }

        public int Antiguedad() 
        { 
            return new DateTime(DateTime.Now.Subtract(this.FechaIngreso).Ticks).Year - 1;
        }

        public DateTime fechaNacimiento() { return this.FechaNac; }

    public override string getCredencial()
        {
                return $"{this.Legajo} - {base.getNombreCompleto()} salario $ ";
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
            } else if (!(obj is Empleado))
            {
                return false;
            }

            Empleado e = (Empleado)obj;

            return e.Legajo == this.Legajo;
        }

        public override string getNombreCompleto()
        {
            return base.getNombreCompleto();
        }
    }
}
