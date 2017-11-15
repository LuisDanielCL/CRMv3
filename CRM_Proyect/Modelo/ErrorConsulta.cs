using System;

    public class ErrorConsulta
    {
        /**
        * Clase para crear objetos error cuando se hace la consulta en la base de datos.
        */

        public ErrorConsulta(String id, String titulo, String descripcion, String usuario , String accion)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.usuario = usuario;
            this.accion = accion;
        }
        public String id { get; set; }
        public String titulo { get; set; }
        public String descripcion { get; set; }
        public String usuario { get; set; }
        public String accion { get; set; }
    }
