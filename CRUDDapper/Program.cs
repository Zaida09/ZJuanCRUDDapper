using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapper
{
    public class Program
    {


        static void Main(string[] args)
        {
            int opt;
            Console.WriteLine("***** Base de Datos Alumno *****");
            Console.WriteLine("1. Mostrar  registros .");
            Console.WriteLine("2. Insertar un registro.");
            Console.WriteLine("3. Actualizar registro.");
            Console.WriteLine("4. Eliminar un registro.");
            Console.WriteLine("Ingrese el numero que desea consultar.");
            opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
//***********************************************  MOSTRAR *******************************************************
                case 1:
                    GetAll();
                    void GetAll()
                    {

                        Resultado resultado = Alumno.GetAll();
                        if (resultado.Mensaje == "Correcto")
                        {
                            Alumno alumno = new Alumno();
                            Console.Clear();
                            foreach (var objeto in resultado.Objetos)
                            {
                                Console.WriteLine("id: " + objeto.IdAlumno +" Nombre: " + objeto.Nombre + " Apellido Paterno:" + objeto.ApellidoPaterno
                                    + "Apellido materno:" + objeto.ApellidoMaterno + " Edad:" + objeto.Edad + " Telefono:" + objeto.Telefono + " Email:" + objeto.Email + "\nFecha de nacimoento:" + objeto.FechaNacimiento
                                    + "Matricula:" + objeto.Matricula + " Sexo:" + objeto.Sexo + "Semestre:" + objeto.IdSemestre);
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
                            }

                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("No se pudo mostrar la lista");
                            Console.ReadLine();
                        }
                    }
                   break;
//**************************************************** INSERTAR  **************************************************
               case 2:
                    Add();
                     void Add()
                     {
                        Alumno alumno = new Alumno(); //Instancia 
                        Console.Clear();
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

                        Resultado resultado = Alumno.Add(alumno);
                        if (resultado.Mensaje == "Correcto")
                        {
                            Console.WriteLine("Alumno ingresado correctamente");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al insertar al alumno");
                            Console.ReadLine();
                        }

                     }
                    break;
// **************************************************  EDITAR *********************************************************
                case 3:
                    UpDate();
                    void UpDate()
                    {
                        Alumno alumno = new Alumno(); //Instancia 
                        Console.Clear();
                        
                        Resultado resultado = Alumno.UpDate (alumno);
                        if (resultado.Mensaje == "Correcto")
                        {
                            Console.WriteLine("Alumno Actualizado correctamente");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al Actualizar al alumno");
                            Console.ReadLine();
                        }

                    }
                    break;
//********************************************************  ELIMINAR **********************************************
                case 4:
                    Delete();
                    void Delete()
                    {
                        
                        Alumno alumno = new Alumno(); //Instancia 
                        Console.Clear();
                       
                        Resultado resultado = Alumno.Delete(alumno);
                        if (resultado.Mensaje == "Correcto")
                        {
                            Console.WriteLine("Alumno Eliminado correctamente");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al Eliminar al alumno");
                            Console.ReadLine();
                        }

                    }
                    break;
            }
            
        }
       
    }

}
