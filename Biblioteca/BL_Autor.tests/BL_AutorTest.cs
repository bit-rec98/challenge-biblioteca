using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DTO;
using DATOS;
using NEGOCIO;
using System.Collections.Generic;

namespace TEST_BL_Autor.tests
{
    [TestClass]
    public class BL_AutorTest
    {
        [TestMethod]
        public void mostrarAutores_DeberiaRetornarListaNoNulaYConMasDeUnElemento()
        {
            // Creación del mock del DAO_Autor que simule su comportamiento
            var mockDaoAutor = new Mock<IDAO_Autor>();

            // Configuración del mock para que retorne una lista de 3 autores
            mockDaoAutor.Setup(dao => dao.obtenerAutores()).Returns(new List<DTO_Autor>
            {
                new DTO_Autor { idAutor = 1, nombre = "Autor1", apellido = "Apellido1", idPaisNacimiento = 1 },
                new DTO_Autor { idAutor = 1, nombre = "Autor1", apellido = "Apellido1", idPaisNacimiento = 1 },
                new DTO_Autor { idAutor = 1, nombre = "Autor1", apellido = "Apellido1", idPaisNacimiento = 1 }
            });

            // Instancia de la clase BL_Autor inyectando el mock de DAO_Autor
            BL_Autor blAutor = new BL_Autor(mockDaoAutor.Object);

            // Llamado al método de negocio
            List<DTO_Autor> resultadoConsulta = blAutor.mostrarAutores();

            // Verificación de la lista no nula
            Assert.IsNotNull(resultadoConsulta, "La lista de autores debería ser no nula.");

            // Verificación de lista con más de un elemento
            Assert.IsTrue(resultadoConsulta.Count > 1, "La lista de autores debería contener más de un elemento.");
        }
    }
}
