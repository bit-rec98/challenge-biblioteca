using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using NEGOCIO;
using DATOS;

namespace NEGOCIO
{
    public class BL_Autor : IBL_Autor
    {
        private readonly IDAO_Autor _daoAutor;

        // Inyección de dependencias en el constructor
        public BL_Autor(IDAO_Autor daoAutor)
        {
            _daoAutor = daoAutor;
        }

        // Implementación de método de interfaz
        public List<DTO_Autor> mostrarAutores()
        {
            List<DTO_Autor> autores = new List<DTO_Autor>();

            try
            {
                // Ejecución de método de la dependencia inyectada - interacción con la interfaz en lugar de la clase directa
                autores = _daoAutor.obtenerAutores();
            }
            catch (Exception error)
            {
                Console.WriteLine($"Ocurrió un error al obtener los datos: {error}");
            }

            return autores;
        }
    }
}
