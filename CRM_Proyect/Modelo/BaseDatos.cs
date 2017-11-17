using CRM_Proyect.Modelo.ClassTest;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
    public class BaseDatos : IBaseDatos
    {
        private MySqlConnection conexion;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public BaseDatos()
        {
            conexion = new MySqlConnection(";server=localhost;user id=root;database=crm;password=root");
            command = new MySqlCommand();
            command.Connection = conexion;
        }

        public Boolean Abrir()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean Cerrar()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean cargarQuery(String pQuery)
        {
            try
            {
                command.CommandText = pQuery;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IDataReader getSalida()
        {
            reader = command.ExecuteReader();
            return reader;

        }

        public bool ejecutarQuery()
        {
            try
            {
                command.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
