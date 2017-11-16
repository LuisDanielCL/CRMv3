using CRM_Proyect.Modelo;
using CRM_Proyect.Modelo.ClassTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Tests
{
    class ValidadorError
    {
        private IError manager;

        public ValidadorError(IError mgr)
        {
            manager = mgr;
        }

        public int enviarError(string titulo, string descripcion)
        {
            return manager.enviarError(titulo,descripcion);
        }

        public List<ErrorConsulta> obtenerErrores()
        {
            return manager.obtenerErrores();
        }


        public Boolean eliminarError(int idError)
        {
            return manager.eliminarError(idError);
        }
    }
}
