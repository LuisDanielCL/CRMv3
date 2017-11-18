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
using CRM_Proyect.Modelo.ClassTest;
using System.Data;
using System.Linq;
using System.Web;

/**
*	Clase que contiene los métodos necesarios para el manejo de usuarios y empresas cuando se realiza alguna consulta en la base de datos.
*
*/
public class ConsultaVendedor : IVendedor

{
    const int EXITO_DE_INSERCION = 0;
    const int FALLO_DE_INSERCION = -1;

    IBaseDatos con;
    public ConsultaVendedor()
    {
        con = new BaseDatos();
    }

    public ConsultaVendedor(IBaseDatos pCon)
    {
        con = pCon;
    }

    public List<Vendedor> obtenerVendedores()
    {
        List<Vendedor> listaVendedores = new List<Vendedor>();

        con.Abrir();
        con.cargarQuery("call obtenerVendedores(" + Consulta.idUsuarioActual + ")");

        // La consulta podría generar errores
        try
        {
            IDataReader reader = con.getSalida();

            //MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                listaVendedores.Add(new Vendedor(reader[0].ToString(), reader[1].ToString(),
                    reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                    reader[5].ToString()));
            }

            reader.Dispose();
            con.Cerrar();
            //cerrarConexion();
        }
        catch (Exception)
        {
            throw new Exception("Ocurrio un problema al obtener los vendedores.");
        }

        return listaVendedores;
    }

}
