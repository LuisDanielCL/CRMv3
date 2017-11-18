/**
 *	Clase ConsultaProducto
 *	
 *	Version 1.0
 *	
 *	21/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CRM_Proyect.Modelo.ClassTest;

namespace CRM_Proyect.Modelo
{
    /**
    *	Clase que contiene los métodos necesarios para realizar consultas a la base de datos relacionadas con los productos.
    *
    */
    public class ConsultaRecomendacion:IConsultaRecomendacion
    {
        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        private MySqlConnection conexion;
        String cadenaDeConexion;
        public ConsultaRecomendacion()
        {

        }

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


        public List<Recomendacion> obtenerRecomendaciones()
        {
            List<Recomendacion> listaRecomendaciones = new List<Recomendacion>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerRecomendaciones(" + Consulta.idUsuarioActual + ")";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaRecomendaciones.Add(new Recomendacion(reader["Nombre"].ToString(), reader["Descripcion"].ToString(), reader["Precio"].ToString(),
                        reader["Categoria"].ToString()));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaRecomendaciones;
        }
    }
}