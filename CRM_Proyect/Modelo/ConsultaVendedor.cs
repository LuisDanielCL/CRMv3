/**
 *	Clase Consulta
 *	
 *	Version 1.0
 *	
 *	24/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CRM_Proyect.Modelo;

   /**
   *	Clase que contiene los métodos necesarios para el manejo de usuarios y empresas cuando se realiza alguna consulta en la base de datos.
   *
   */
public class ConsultaVendedor

{
    private MySqlConnection conexion;
    String cadenaDeConexion; 
    public static int idUsuarioActual ;
    public  int tipoCuenta;
    private Boolean session = false;
    public ConsultaVendedor() {
        
    }
    public int getIdUsuarioActual()
    {
        return idUsuarioActual;
    }

    public void setIdUsuarioActual(int nuevoId) {
        idUsuarioActual = nuevoId;
    }

    public int getTipoCuenta() {
        return tipoCuenta;
    }

    public Boolean getSession()
    {
        return session;
    }
    public void setSessionFalse()
    {
        session = false;
    }

    private void iniciarConexion() {
        try
        {
            conexion = new MySqlConnection();
            cadenaDeConexion = ";server=localhost;user id=root;database=crm;password=root";
            conexion.ConnectionString = cadenaDeConexion;
            conexion.Open();
            
        }
        catch (MySqlException ex) {
            MessageBox.Show("Conexion sin exito" + ex.Message);
        }
    }
    private void cerrarConexion() {
        conexion.Close();
    }

    public Boolean validarUsuario(string usuario, string contrasena) {
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        string contrasenaDb = null;
        instruccion.CommandText = "call obtenerContrasena('" + usuario + "')";
   
        try {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                contrasenaDb = reader["contraseña"].ToString();
                if (contrasenaDb != null)
                {
                    contrasenaDb = Seguridad.desEncriptar(contrasenaDb);
                    if (contrasenaDb.Equals(contrasena))
                    {
                        tipoCuenta = (int)reader["tipoCuenta"];
                        idUsuarioActual = (int)reader["idusuario"];
                        reader.Dispose();
                        cerrarConexion();
                        session = true;
                        return true;
                    }
                }
            }
            
            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex) {
            MessageBox.Show("Falló la operación " + ex.Message);
        }
        return false;
    }

    public List<Vendedor> obtenerVendedores()
    {
        List<Vendedor> listaVendedores = new List<Vendedor>();

        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call obtenerVendedores(" + idUsuarioActual + ")";

        // La consulta podría generar errores
        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                listaVendedores.Add(new Vendedor(reader["Nombre"].ToString(), reader["Primer_Apellido"].ToString(),
                    reader["Segundo_Apellido"].ToString(), reader["Direccion"].ToString(), reader["correo"].ToString(),
                    reader["Telefono"].ToString()));
            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }

        return listaVendedores;
    }

}
