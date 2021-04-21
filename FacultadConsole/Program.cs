using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacultadLibrary.validaciones;
using FacultadLibrary.entities;
using FacultadLibrary.exceptions;

namespace FacultadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = -1;
            bool esValido = true;
            bool salir = false;

            Facultad facultad = new Facultad();

            Empleado directivo = new Directivo();
            Empleado bedel = new Bedel();
            Empleado docente = new Docente();

            Persona alumno = new Alumno();

            do
            {
                Console.Write("\n por favor seleccione una opcion" +
                    "\n 0 - agregar alumno" +
                    "\n 1- agregar empleado" +
                    "\n  2 - eliminar alumno" +
                    "\n  3 - eliminar empleado" +
                    "\n  4 -modificar empleado" +
                    "\n  5 - traer todos los empleados" +
                     "\n  6 - traer todos los alumnos" +
                     "\n  7 - traer empleado x legajo" +
                     "\n  8  - traer empleados x nombre" +
                     "\n  9  - salir ");

                do
                {   
                    try
                    {
                        Console.WriteLine("Por favor seleccione la opcion");
                        opcion = validaciones.validarInt();
                        esValido = true;

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ocurrio un error al seleccionar la opcion, x favor intente devuelta");
                    }
                } while (!esValido);

                switch (opcion)
                {
                    case 0:
                        try {
                            facultad.agregarAlumno(cargarAlumno());                           
                        } catch (AlumnoYaExistenteExceptioncs ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 1:
                        try
                        {
                            facultad.agregarEmpleado(cargarEmpleado());
                        }
                        catch (EmpleadoYaExistenteException ex)
                        { 
                            Console.WriteLine(ex.Message);
                        }                       
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Por favor ingrese codigo del alumno a eliminar");
                            facultad.eliminarAlumno(validaciones.validarInt());
                        }
                        catch (AlumnoNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Por favor ingrese legajo de empleado a eliminar");
                            facultad.eliminarEmpleado(validaciones.validarInt());
                        }
                        catch (EmpleadoNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("A continuacion va a modificar un empleado");
                            facultad.modificarEmpleado(cargarEmpleado());

                        }
                        catch (EmpleadoNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        try
                        {
                            List<Empleado> empleados = facultad.traerEmpleados();
                            foreach (Empleado emp in empleados)
                            {
                                Console.WriteLine(emp.ToString());
                            }
                        }
                        catch (EmpleadoNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        try
                        {
                            List<Alumno> alumnos = facultad.traerAlumnos();
                            foreach (Alumno alumno1 in alumnos)
                            {
                                Console.WriteLine(alumno1.ToString());
                            }
                        }
                        catch (AlumnoNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 7:
                        try
                        {
                            Console.WriteLine("Por favor ingrese numero legajo a consultar");
                            Empleado empleado = facultad.traerEmpleadoPorLegajo(validaciones.validarInt());
                            Console.WriteLine(empleado.ToString());
                        }
                        catch (AlumnoNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 8:
                        try
                        {
                            Console.WriteLine("Por favor ingrese nombre de empleados a traer");

                        List<Empleado> empleados = facultad.traerEmpleadosPorNombre(validaciones.validarString());
                            foreach (Empleado empleado in empleados)
                            {
                                Console.WriteLine(empleado.ToString());
                            }
                        }
                        catch (EmpleadoNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 9:
                        salir = true;
                        break;
                }

            } while (!salir);

            Console.ReadKey();
        }

        public static Alumno cargarAlumno()
        {
            Alumno alumno = new Alumno();
            Console.WriteLine("Por favor ingrese el nombre del alumno ");
            alumno.Nombre = validaciones.validarString();
            Console.WriteLine("Por favor ingrese el apellido del alumno ");
            alumno.Apellido = validaciones.validarString();
            Console.WriteLine("A continuacion va a ingresar fecha nacimiento del alumno. presione enter ");
            alumno.FechaNac = validaciones.cargarFechasDateTime();
            Console.WriteLine("Por favor ingrese el codigo del alumno ");
            alumno.Codigo = validaciones.validarInt();
            return alumno;
        }

        public static Empleado cargarEmpleado()
        {
            try
            {
                Empleado empleado = tipoEmpleado();
                empleado.Nombre = validaciones.validarString();
                Console.WriteLine("Por favor ingrese el apellido del empleado ");
                empleado.Apellido = validaciones.validarString();
                Console.WriteLine("Por favor ingrese el legajo del empleado ");
                empleado.Legajo = validaciones.validarInt();
                Console.WriteLine("A continuacion va a ingresar fecha nacimiento del empleado. presione enter ");
                empleado.FechaNac = validaciones.cargarFechasDateTime();
                Console.WriteLine("A continuacion va a ingresar fecha ingreso del empleado. presione enter ");
                empleado.FechaIngreso = validaciones.cargarFechasDateTime();
                return empleado;
            }
            catch (EmpleadoNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            
            return null;
        }

        public static Empleado tipoEmpleado()
        {
            Console.Write("\n por favor indique opcion adecuada de acuerdo al tipo de empleado a ingresar" +
                               "\n A - Docente" +
                               "\n B - Directivo" +
                               "\n  C - Bedel" +
                               "\n ");
            Console.WriteLine("Por favor seleccione la opcion ");
            string opcion = validaciones.validarString().ToUpper();
            if (opcion.Equals("A"))
            {
                return new Docente();
            } else if (opcion.Equals("B")){
                return new Directivo();
            } else if (opcion.Equals("C"))
            {
                return new Bedel();
            } else
            {
                throw new EmpleadoNotFoundException("El tipo d empleado ingresado no existe");
            }
        }
    }
}

