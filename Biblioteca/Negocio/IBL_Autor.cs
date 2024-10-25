using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEGOCIO
{
    public interface IBL_Autor
    {
        List<DTO_Autor> mostrarAutores();
    }
}
