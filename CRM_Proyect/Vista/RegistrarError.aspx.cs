using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CRM_Proyect.Modelo;

namespace CRM_Proyect.Vista
{
    public partial class registrarError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string enviarError(string titulo, string descripcion)
        {

            //Controlador controlador = Controlador.getInstance();
            return titulo + ", " + descripcion;
            //return controlador.enviarError(titulo, descripcion);
        }
    }
}