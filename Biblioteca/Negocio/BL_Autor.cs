using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Datos;

namespace Negocio
{
    public class BL_Autor
    {
        public List<DTO_Autor> mostrarAutores()
        {
            List<DTO_Autor> autores = new List<DTO_Autor>();

            try
            {
                DAO_Autor autoresEnDb = new DAO_Autor();
                autores = autoresEnDb.obtenerAutores();

            }
            catch (Exception error)
            {
                Console.WriteLine($"Ocurrió un error al obtener los datos: {error}");
            }

            return autores;
        }

    }
}
