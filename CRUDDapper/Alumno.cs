using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapper
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Edad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public string Matricula { get; set; }
        public string Sexo { get; set; }
        public int IdSemestre { get; set; }
//-----------------------------------------------------INSERTAR-------------------------------------------------
        public static Resultado Add (Alumno alumno)
        {
            Resultado resultado = new Resultado();

            try
            {
                using (var context = new SqlConnection(Conexion.GetConnection()))
                {
                    var query = context.Execute($"AlumnoAdd'{alumno.Nombre}','{alumno.ApellidoPaterno}','{alumno.ApellidoMaterno}','{alumno.Edad}','{alumno.Telefono}','{alumno.Email}','{alumno.FechaNacimiento}','{alumno.Matricula}','{alumno.Sexo}','{alumno.IdSemestre}'");
                    
                    if (query >= 0)
                    {
                        resultado.Mensaje = "Correcto";
                    }
                    else
                    {
                        resultado.Mensaje = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Ocurrio un error al insertar el registro" + ex;

            }

            return resultado;
        }
//---------------------------------------------------MOSTRAR-------------------------------------------------------
        public static Resultado GetAll ()
        {
            Resultado resultado = new Resultado();

            try
            {
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    var query = context.Query<Alumno>($"AlumnoGetAll");
                    resultado.Objetos = new List<Alumno>();
                    
                    if (query != null)
                    {
                        int Contador = 0;
                        foreach ( var objeto in query)
                        {
                            resultado.Objetos.Add(objeto);
                            Contador++;
                        }
                        
                        resultado.Mensaje = "Correcto";
                    }
                    else
                    {
                        resultado.Mensaje = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "No se pudieron mostrar los registros" + ex;

            }

            return resultado;
        }
//--------------------------------------------------------EDITAR-----------------------------------------------------
        public static Resultado UpDate(Alumno alumno)
        {
            Resultado resultado = new Resultado();
            int editarid;
            Console.WriteLine("Ingrese el ID del alumno que desea Editar "); 
            editarid = int.Parse(Console.ReadLine());
            alumno.IdAlumno = editarid;

            try
            {
                using (var context = new SqlConnection(Conexion.GetConnection()))
                {
                    var query = context.Query($"AlumnoUpDate'{alumno.IdAlumno}'");

                    if (query != null)
                    {
                        Console.WriteLine("Ingrese el nombre del alumno");
                        //Quien. Que
                        alumno.Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido paterno del alumno");
                        alumno.ApellidoPaterno = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido materno del alumno");
                        alumno.ApellidoMaterno = Console.ReadLine();
                        Console.WriteLine("ingrese la edad del alumno");
                        alumno.Edad = Console.ReadLine();
                        Console.WriteLine("ingrese el telefono del alumno");
                        alumno.Telefono = Console.ReadLine();
                        Console.WriteLine("ingrese el emaildel alumno");
                        alumno.Email = Console.ReadLine();
                        Console.WriteLine("ingrese lafecha de nacimiento del alumno");
                        alumno.FechaNacimiento = Console.ReadLine();
                        Console.WriteLine("ingrese la Matricula del alumno");
                        alumno.Matricula = Console.ReadLine();
                        Console.WriteLine("ingrese el sexo del alumno");
                        alumno.Sexo = Console.ReadLine();
                        Console.WriteLine("ingrese el semestre del alumno");
                        alumno.IdSemestre = byte.Parse(Console.ReadLine());
                        resultado.Mensaje = "Correcto";
                    }
                    else
                    {
                        resultado.Mensaje = "Error";
                    }
                }
                    
                
            }
               
            catch (Exception ex)
            {
                    resultado.Mensaje = "No se pudieron mostrar los registros" + ex;

            }

            return resultado;
        }
        //----------------------------------------------------------ELIMINAR-------------------------------------------------
        public static Resultado Delete (Alumno alumno)
        {
            Resultado resultado = new Resultado();
            int eliminarid;
            Console.WriteLine("Ingrese el ID del alumno que desea ELIMINAR ");
            eliminarid = int.Parse(Console.ReadLine());
            alumno.IdAlumno=eliminarid;

            try
            {
                using (var context = new SqlConnection(Conexion.GetConnection()))
                {
                    var query = context.Execute($"AlumnoDelete'{alumno.IdAlumno}'");

                            if (query > 0)
                            {
                                resultado.Mensaje = "Correcto";
                            }
                            else
                            {
                                resultado.Mensaje = "Error";
                            }
                    
                }
            }


            catch (Exception ex)
            {
                resultado.Mensaje = "No se pudieron mostrar los registros" + ex;

            }

            return resultado;
        }
    }

}
