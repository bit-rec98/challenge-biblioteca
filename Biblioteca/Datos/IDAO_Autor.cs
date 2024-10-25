using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATOS
{
    public interface IDAO_Autor
    {
        List<DTO_Autor> obtenerAutores();
    }
}
