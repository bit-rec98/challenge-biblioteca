using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DTO;
using DATOS;

namespace DATOS
{
    public class DAO_Autor : IDAO_Autor
    {

        // Implementación de método de interfaz
        public List<DTO_Autor> obtenerAutores()
        {
            List<DTO_Autor> autores = new List<DTO_Autor>();

            string stringConector = ConfigurationManager.ConnectionStrings["Capacitacion2024crecabarren"].ToString();

            using (SqlConnection conexion = new SqlConnection(stringConector))
            {
                try
                {
                    string query = "SELECT * FROM BIB_autor";
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
