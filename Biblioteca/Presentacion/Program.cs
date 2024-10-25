using DATOS;
using DTO;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Presentacion
{
    class Program
    {
        public static void Main(string[] args)
        {
            int opcion = -1;
            mostrarMenu();

            while (opcion != 0)
            {
                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine($"La opción que elegiste es: {opcion}\n");
                switch (opcion)
                {
                    case 1:
                        List<DTO_Autor> listaAutores = new List<DTO_Autor>();
                        try
                        {
                            Console.Write("Autores existentes en la base de datos: \n");

                            // Implementación de interfaz con método para obtener autores - no se implementa DAO_Autor directamente 
                            IDAO_Autor _daoAutor = new DAO_Autor();

                            // Interacción con capa de negocio
                            BL_Autor datosAutores = new BL_Autor(_daoAutor); 
                            listaAutores = datosAutores.mostrarAutores();

                            foreach(DTO_Autor item in listaAutores)
                            {
                                Console.WriteLine($"Nombre completo: {item.nombre} {item.apellido}");
                            }

                            opcion = 0;
                        }
                        catch(Exception error)
                        {
                            Console.Write($"Ocurrió un error: {error}");
                        }

                        Thread.Sleep(5000);
                        break;
                    case 0:
                        Console.Write("¡Gracias por utilizar el servicio!\n");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intentá nuevamente.\n\n\n");
                        mostrarMenu();
                        continue;
                }
            }
        }

        public static void mostrarMenu()
        {
            Console.WriteLine("¡Bienvenido/a al sistema de consulta de la biblioteca!\n");
            Thread.Sleep(1000);
            Console.WriteLine("Seleccioná una de las opciones disponibles:\n1. Consulta de autores de libros existentes. \n0. Salir \n");
        }
    }
}

