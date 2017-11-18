/**
 *	Interface IConsultaProducto
 *	
 *	Version 1.0
 *	
 *	24/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;


namespace CRM_Proyect.Modelo.ClassTest
{
    /**
    *	Interface que contiene los métodos necesarios para probar el manejo de productos.
    *
    */
    public interface IConsultaRecomendacion
    {
        List<Recomendacion> obtenerRecomendaciones();
    }
}
