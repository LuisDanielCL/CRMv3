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
    }
}