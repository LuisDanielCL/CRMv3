using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Proyect.Vista
{
    public partial class VerErrores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object cargarErrores()
        {
            Controlador controlador = Controlador.getInstance();
            List<ErrorConsulta> errores = controlador.obtenerErrores();
            object json = new { data = errores };
            return json;
        }

        [WebMethod]
        public static string eliminarError(int idError)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.eliminarError(idError))
            {
                return "true";
            }
            return "false";

        }
    }
}