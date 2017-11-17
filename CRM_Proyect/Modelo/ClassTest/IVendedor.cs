using System;
using System.Collections.Generic;


namespace CRM_Proyect.Modelo.ClassTest
{
    public interface IVendedor
    {
        int enviarError(String titulo, String descripcion);
        List<ErrorConsulta> obtenerErrores();
        Boolean eliminarError(int idError);
    }
}