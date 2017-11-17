using System;
using System.Data;

namespace CRM_Proyect.Modelo.ClassTest
{
    public interface IBaseDatos
    {
        Boolean Abrir();
        Boolean Cerrar();
        Boolean cargarQuery(String query);
        IDataReader getSalida();
        Boolean ejecutarQuery();
    }
}