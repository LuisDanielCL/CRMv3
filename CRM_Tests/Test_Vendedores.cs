using CRM_Proyect.Modelo;
using CRM_Tests.Fakes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Tests
{
    [TestFixture]
    /**
    *	Clase para realizar pruebas de manejo de envio y consulta de errores en el sistema.
    *
    */

    class Test_Vendedores
    {
        private string Error_Titulo_Mayor_A_50_Caracteres = "Título debe tener como máximo 50 caracteres";
        private string Error_Titulo_Vacio = "Título no puede estar vacio";
        private string Error_Descripcion_Mayor_A_200_Caracteres = "Descripción debe tener como máximo 200 caracteres";
        private string Error_Descripcion_Vacio = "Descripción no puede estar vacio";
        private int Exito_Insercion = 0;
        private int Error_Insercion = -1;
        

        [Test]
        public void obtenerVendedores_ObtenerVendedoresCorrecto_ReturnsList()
        {
            FakeBaseDatos fakeBD = new FakeBaseDatos(true, true, true);
            ConsultaVendedor consultaVendedor = new ConsultaVendedor(fakeBD);
            List<Vendedor> resultado = consultaVendedor.obtenerVendedores();
            Assert.IsNotNull(resultado);
        }

        [Test]
        public void obtenerVendedores_ObtenerVendedoresFalso_ReturnsNull()
        {
            FakeBaseDatos fakeBD = new FakeBaseDatos(true, true, false);
            ConsultaVendedor consultaVendedor = new ConsultaVendedor(fakeBD);
            List<Vendedor> resultado = consultaVendedor.obtenerVendedores();
            Assert.IsNotNull(resultado);
        }
    }
}
