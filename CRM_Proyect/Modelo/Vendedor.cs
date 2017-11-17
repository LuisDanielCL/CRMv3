/**
 *	Clase Usuario
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

public class Vendedor
{
	/**
	* Clase para crear objetos usuario cuando se hace la consulta en la base de datos.
	*/

    public Vendedor(String nombre, String primerApellido, String segundoApellido, String direccion,
                String correo, String telefono)
    {
        this.nombre = nombre;
        this.primerApellido = primerApellido;
        this.segundoApellido = segundoApellido;
        this.direccion = direccion;
        this.correo = correo;
        this.telefono = telefono;
    }
    public String nombre { get; set; }
    public String primerApellido { get; set; }
    public String segundoApellido { get; set; }
    public String direccion { get; set; }
    public String correo { get; set; }
    public String telefono { get; set; }
}


