using CRM_Proyect.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Proyect.Vista
{
    public partial class SeguimientoEntrenamientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string crearEntrenamiento(string titulo, string descripcion, string fecha)
        {

            Controlador controlador = Controlador.getInstance();
            return controlador.crearEntrenamiento(titulo, descripcion,fecha);
        }

        
        [WebMethod]
        public static object cargarEntrenamientos()
        {
            Controlador controlador = Controlador.getInstance();
            List<entrenamientoConsulta> entranamientos = controlador.obtenerEntrenamientos();
            object json = new { data = entranamientos };
            return json;
        }

        [WebMethod]
        public static string eliminarEntrenamiento(int idEntrenamiento)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.eliminarEntrenamiento(idEntrenamiento))
            {
                return "true";
            }
            return "false";

        }
    }
}