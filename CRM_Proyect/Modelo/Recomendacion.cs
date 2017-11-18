﻿/**
 *	Clase Producto
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

namespace CRM_Proyect.Modelo
{
	/**
	*	Clase para crear objetos producto cuando se hace la consulta en la base de datos.
	*/
    public class Recomendacion
    {
        public Recomendacion(String nombre, String descripcion, String precio, String categoria)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.categoria = categoria;
        }

        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String precio { get; set; }
        public String categoria { get; set; }



    }
}