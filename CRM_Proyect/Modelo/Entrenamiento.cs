using CRM_Proyect.Modelo.ClassTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
    public class Entrenamiento
    {
        const int EXITO_DE_INSERCION = 0;
        const int FALLO_DE_INSERCION = -1;

        IBaseDatos con;
        public Entrenamiento()
        {
            con = new BaseDatos();
        }

        public Entrenamiento(IBaseDatos pCon)
        {
            con = pCon;
        }


        public int crearEntrenamiento(String titulo, String descripcion, String fecha)
        {
            con.Abrir();
            con.cargarQuery("call crearEntrenamiento('" + titulo + "', '" + descripcion + " ','" + fecha + "')");
            // La consulta podría generar errores
            if (con.ejecutarQuery())
            {
                con.Cerrar();
                return EXITO_DE_INSERCION;
            }
            con.Cerrar();
            return FALLO_DE_INSERCION;
        }


        public List<entrenamientoConsulta> obtenerEntrenamientos()
        {
            List<entrenamientoConsulta> listaEntrenamientos = new List<entrenamientoConsulta>();

            con.Abrir();
            con.cargarQuery("call obtenerEntrenamientos()");

            // La consulta podría generar errores
            try
            {
                IDataReader reader = con.getSalida();
                while (reader.Read())
                {
                    listaEntrenamientos.Add(new entrenamientoConsulta(reader[0].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString(),
                        "<a href='#' onclick='eliminarEntrenamiento(" + reader[0] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Eliminar</span></a>"));
                }

                reader.Dispose();
                con.Cerrar();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un problema al obtener los entrenamientos.");
            }

            return listaEntrenamientos;
        }

        public Boolean eliminarError(int idError)
        {

            con.Abrir();

            con.cargarQuery("call borrarError(" + idError + ")");

            // La consulta podría generar errores

            if (con.ejecutarQuery())
            {
                con.Cerrar();
                return true;
            }
            con.Cerrar();
            return false;
        }
    }
}