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
using System.Data;

namespace CRM_Proyect.Modelo
{
    /**
    *	Clase que contiene los métodos necesarios para realizar consultas a la base de datos relacionadas con los productos.
    *
    */
    public class ConsultaRecomendacion: IConsultaRecomendacion
    {
        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        int idActual;

        IBaseDatos con;
        public ConsultaRecomendacion()
        {
            con = new BaseDatos();
            idActual = Consulta.idUsuarioActual;
        }

        public ConsultaRecomendacion(IBaseDatos pCon)
        {
            con = pCon;
            idActual = 34;
        }

        public List<Recomendacion> obtenerRecomendaciones()
        {
            List<Recomendacion> listaRecomendaciones = new List<Recomendacion>();

            con.Abrir();
            con.cargarQuery("call obtenerRecomendaciones(" + idActual + ")");
          
            // La consulta podría generar errores
            try
            {
                IDataReader reader = con.getSalida();
                while (reader.Read())
                {
                    listaRecomendaciones.Add(new Recomendacion(reader["Nombre"].ToString(), reader["Descripcion"].ToString(), reader["Precio"].ToString(),
                        reader["Categoria"].ToString()));
                }

                reader.Dispose();
                con.Cerrar();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un problema al obtener las recomendaciones.");
            }

            return listaRecomendaciones;
        }
    }
}