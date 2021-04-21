using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacultadLibrary.exceptions;

namespace FacultadLibrary.entities
{
   public class Facultad
    {
        List<Alumno> _alumnos;
        int _cantidadSedes;
        List<Empleado> _empleados;
        string _nombre;

        public Facultad() {
            _alumnos = new List<Alumno>();
            _empleados = new List<Empleado>();
        }
        public Facultad(List<Alumno> alumnos, int cantidadSedes, List<Empleado> empleados, string nombre)
        {
            _alumnos = alumnos;
            _cantidadSedes = cantidadSedes;
            _empleados = empleados;
            _nombre = nombre;
        }

        public int CantidadSedes { get => _cantidadSedes; set => _cantidadSedes = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public void agregarAlumno(Alumno al)
        {
            foreach(Alumno alumno in _alumnos)
            {
                if (alumno.Equals(al))
                {
                    throw new AlumnoYaExistenteExceptioncs("El alumno ya existe");
                }
            }
            _alumnos.Add(al);
        }

        public void agregarAlumno(int codigo)
        {
            foreach (Alumno alumno in _alumnos)
            {
                if (alumno.Codigo==codigo)
                {
                    throw new AlumnoYaExistenteExceptioncs("El alumno ya existe");
                }
            }
            _alumnos.Add(new Alumno(codigo));
        }

        public void agregarEmpleado(Empleado emp)
        {
            foreach (Empleado empleado in _empleados)
            {
                if (empleado.Equals(emp))
                {
                    throw new EmpleadoYaExistenteException("El empleado ya existe");
                }
            }
            _empleados.Add(emp);
        }

        public void eliminarAlumno(int codigo)
        {
            if(!(this._alumnos.Any(alumno => alumno.Codigo == codigo)))
            {
                throw new AlumnoNotFoundException($"El alumno con codigo: {codigo} no existe");
            }

            Alumno alumno1 = this._alumnos.FirstOrDefault(al => al.Codigo == codigo);
            this._alumnos.Remove(alumno1);

        }

        public void eliminarEmpleado(int legajo)
        {
                if (!(this._empleados.Any(empleado => empleado.Legajo == legajo)))
                {
                    throw new EmpleadoNotFoundException($"El empleado con legajo: {legajo} no existe");
                }

                Empleado empleado1 = this._empleados.FirstOrDefault(emp => emp.Legajo == legajo);
                this._empleados.Remove(empleado1);          
        }

        public void modificarEmpleado(Empleado empleado)
        {
           Empleado empleadoOriginal = _empleados.Where(i => i.Legajo == empleado.Legajo).First();
            var index = _empleados.IndexOf(empleadoOriginal);

            if (index != -1)
                _empleados[index] = empleado;
        }

        public List<Alumno> traerAlumnos()
        {
            if (!((this._alumnos).Any())){
                throw new AlumnoNotFoundException("No se encuentran alumnos");
            }
            return this._alumnos;
        }

        public List<Empleado> traerEmpleados()
        {
            if (!((this._empleados).Any())){
                throw new EmpleadoNotFoundException("No se encuentran empleados");
            }
            return this._empleados;
        }

        public Empleado traerEmpleadoPorLegajo(int legajo)
        {

            if (!(this._empleados.Any(empleado => empleado.Legajo == legajo)))
            {
                throw new EmpleadoNotFoundException($"El empleado con legajo: {legajo} no existe");
            }

           return this._empleados.FirstOrDefault(emp => emp.Legajo == legajo);
        }

        public List<Empleado> traerEmpleadosPorNombre(string nombre)
        {
            if (!(this._empleados.Any(empleado => empleado.Nombre == nombre)))
            {
                throw new EmpleadoNotFoundException($"El empleado con nombre: {nombre} no existe");
            }

            return this._empleados.Where(emp => emp.Nombre == nombre).ToList();
        }


    }
}
