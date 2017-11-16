using CRM_Proyect.Modelo.ClassTest;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace CRM_Proyect.Modelo
{
    public class ModeloError : IError
    {
        private MySqlConnection conexion;
        String cadenaDeConexion;

        const int EXITO_DE_INSERCION = 0;
        const int FALLO_DE_INSERCION = -1;


        private void iniciarConexion()
        {
            try
            {
                conexion = new MySqlConnection();
                cadenaDeConexion = ";server=localhost;user id=root;database=crm;password=root";
                conexion.ConnectionString = cadenaDeConexion;
                conexion.Open();

            }
            catch (MySqlException)
            {
                MessageBox.Show("Conexion sin exito");
            }
        }

        private void cerrarConexion()
        {
            conexion.Close();
        }




        public int enviarError(String titulo, String descripcion)
        {
            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call enviarError('" + titulo + "', '" + descripcion + " '," + Consulta.idUsuarioActual + ")";
            // La consulta podría generar errores
            try
            {
                instruccion.ExecuteReader();
                cerrarConexion();
                return EXITO_DE_INSERCION;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();
            return FALLO_DE_INSERCION;
        }

        public List<ErrorConsulta> obtenerErrores()
        {
            List<ErrorConsulta> listaUsuarios = new List<ErrorConsulta>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerErrores()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaUsuarios.Add(new ErrorConsulta(reader["iderror"].ToString(), reader["titulo"].ToString(),
                        reader["descripcion"].ToString(), reader["Nombre"].ToString(),
                        "<a href='#' onclick='eliminarError(" + reader["idError"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Eliminar</span></a>"));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaUsuarios;
        }

        public Boolean eliminarError(int idError)
        {

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call borrarError(" + idError + ")";

            // La consulta podría generar errores
            try
            {
                if (instruccion.ExecuteNonQuery() == 1)
                {
                    cerrarConexion();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();
            return false;
        }

    }
}