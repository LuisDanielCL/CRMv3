using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace CRM_Proyect.Modelo
{
    public class ModeloError
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

    }
}