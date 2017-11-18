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
            var ex = Assert.Throws<Exception>(() => consultaVendedor.obtenerVendedores());
            Assert.That(ex.Message, Is.EqualTo("Ocurrio un problema al obtener los vendedores."));
        }
    }
}
