using CRM_Proyect.Modelo.ClassTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Tests.Fakes
{
    class FakeError : IError
    {
        
        public int enviarExitoRetorno = 0;
        public bool eliminarExitoRetorno = true;
        public List<ErrorConsulta> listError = new List<ErrorConsulta>();
        public int enviarError(string titulo, string descripcion)
        {
            return enviarExitoRetorno;
        }

        public bool eliminarError(int idError)
        {
            return eliminarExitoRetorno;
        }


        public List<ErrorConsulta> obtenerErrores()
        {
            return listError;
        }
    }
}
