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

    class Test_Recomendaciones
    {       
        [Test]
        public void obtenerRecomendaciones_ObtenerRecomendacionesCorrecto_ReturnsList()
        {
            FakeBaseDatos fakeBD = new FakeBaseDatos(true, true, true);
            ConsultaRecomendacion consultaRecomendacion = new ConsultaRecomendacion(fakeBD);
            ////var ex = Assert.Throws<Exception>(() => consultaRecomendacion.obtenerRecomendaciones());
            ////Assert.That(ex.Message, Is.EqualTo("Ocurrio un problema al obtener las recomendaciones."));
            List<Recomendacion> resultado = consultaRecomendacion.obtenerRecomendaciones();
            Assert.IsNotNull(resultado);
        }

        [Test]
        public void obtenerVendedores_ObtenerVendedoresFalso_ReturnsError()
        {
            FakeBaseDatos fakeBD = new FakeBaseDatos(true, true, false);
            ConsultaRecomendacion consultaRecomendacion = new ConsultaRecomendacion(fakeBD);
            var ex = Assert.Throws<Exception>(() => consultaRecomendacion.obtenerRecomendaciones());
            Assert.That(ex.Message, Is.EqualTo("Ocurrio un problema al obtener las recomendaciones."));
        }
    }
}
