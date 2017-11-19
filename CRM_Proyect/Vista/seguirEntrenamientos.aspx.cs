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
    public partial class seguirEntrenamientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object obtenerEntrenamientosNoLLevados()
        {
            Controlador controlador = Controlador.getInstance();
            List<entrenamientoConsulta> entranamientos = controlador.obtenerEntrenamientosNoLLevados();
            object json = new { data = entranamientos };
            return json;
        }

        [WebMethod]
        public static object obtenerMisEntrenamientos()
        {
            Controlador controlador = Controlador.getInstance();
            List<entrenamientoConsulta> entranamientos = controlador.obtenerMisEntrenamientos();
            object json = new { data = entranamientos };
            return json;
        }


        [WebMethod]
        public static object agregarMiEntrenamiento(int idEntrenamiento)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.agregarMiEntrenamiento(idEntrenamiento))
            {
                return "true";
            }
            return "false";
        }


        [WebMethod]
        public static object eliminarMiEntrenamiento(int idEntrenamiento, int idUsuario)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.eliminarMiEntrenamiento(idEntrenamiento, idUsuario))
            {
                return "true";
            }
            return "false";
        }
    }
}