using CRM_Proyect.Modelo.ClassTest;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace CRM_Proyect.Modelo
{
    public class ModeloError : IError
    {

        const int EXITO_DE_INSERCION = 0;
        const int FALLO_DE_INSERCION = -1;

        IBaseDatos con;
        public ModeloError()
        {
            con = new BaseDatos();
        }

        public ModeloError(IBaseDatos pCon)
        {
            con = pCon;       
        }




        public int enviarError(String titulo, String descripcion)
        {
            con.Abrir();
            con.cargarQuery("call enviarError('" + titulo + "', '" + descripcion + " '," + Consulta.idUsuarioActual + ")");
            // La consulta podría generar errores
            if(con.ejecutarQuery())
            { 
                con.Cerrar();
                return EXITO_DE_INSERCION;
            }
            else
            {
                MessageBox.Show("Falló la operación ");
            }
            con.Cerrar();
            return FALLO_DE_INSERCION;
        }

        public List<ErrorConsulta> obtenerErrores()
        {
            List<ErrorConsulta> listaUsuarios = new List<ErrorConsulta>();

            con.Abrir();
            con.cargarQuery("call obtenerErrores()");

            // La consulta podría generar errores
            try
            {
                IDataReader reader = con.getSalida();
                while (reader.Read())
                {
                    listaUsuarios.Add(new ErrorConsulta(reader[0].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString(),
                        "<a href='#' onclick='eliminarError(" + reader[0] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Eliminar</span></a>"));
                }

                reader.Dispose();
                con.Cerrar();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un problema al obtener los errores.");
            }

            return listaUsuarios;
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
            else
            {
                MessageBox.Show("Falló la operación ");
            }
            con.Cerrar();
            return false;
        }

    }
}