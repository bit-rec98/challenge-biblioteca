using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DTO;

namespace Datos
{
    public class DAO_Autor : DTO_Autor
    {

        public List<DTO_Autor> obtenerAutores()
        {
            List<DTO_Autor> autores = new List<DTO_Autor>();

            // Conexión a SQL server enviando el nombre del string conector como argumento
            string stringConector = ConfigurationManager.ConnectionStrings["Capacitacion2024crecabarren"].ToString();

            // Uso de string conector para habilitar la conexión
            using (SqlConnection conexion = new SqlConnection(stringConector))
            {
                try
                {
                    // Definición de query
                    string query = "SELECT * FROM BIB_autor";

                    // Creación de comando sql y establecimiento de conexión
                    using (SqlCommand sqlCommand = new SqlCommand(query, conexion))
                    {
                        DataSet setDatos = new DataSet();
                        SqlDataAdapter adaptadorDatos = new SqlDataAdapter(sqlCommand);
                        conexion.Open();

                        adaptadorDatos.Fill(setDatos);

                        foreach (DataRow item in setDatos.Tables[0].Rows)
                        {
                            DTO_Autor autorDTO = new DTO_Autor();
                            autorDTO.nombre = (string)item["AUT_nombre"];
                            autorDTO.apellido = (string)item["AUT_apellido"];

                            autores.Add(autorDTO);
                        }
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Hubo un error en la solicitud: {error}.");
                }
            }

            return autores;
        }
    }
}
