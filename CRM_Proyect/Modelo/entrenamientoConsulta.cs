using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
    public class entrenamientoConsulta
    {
        /**
* Clase para crear objetos error cuando se hace la consulta en la base de datos.
*/

        public entrenamientoConsulta(String id, String titulo, String descripcion, String fecha, String accion)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.accion = accion;
        }

        public String id { get; set; }
        public String titulo { get; set; }
        public String descripcion { get; set; }
        public String fecha { get; set; }
        public String accion { get; set; }
    }
}