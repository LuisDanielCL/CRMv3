/**
 *	Clase Tests_Producto
 *	
 *	Version 1.0
 *	
 *	24/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using NUnit.Framework;
using CRM_Proyect.Modelo;
using System;
using System.Collections.Generic;
using CRM_Tests.Fakes;


namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de manejo de productos en el sistema.
    *
    */
    class Tests_Productos
    {
        private int Exito_De_Insercion = 0;
        private int Dato_No_Numerico = -7;
        private int Nombre_Muy_Largo = -10;
        private int Descripcion_Muy_Larga = -11;
        private int Datos_Vacios = -12;

        [Test]
        public void agregarProducto_AgregarProductoCorrecto_ReturnsExito_De_Insercion()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.resultadoExitoso = 0;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            int  resultado = producto.agregarProducto("Computadora DELL", 
                "Computadora DELL LATITUDE E6410", "300000");
            Assert.AreEqual(resultado, Exito_De_Insercion);


        }


        [Test]
        public void obtenerProductos_ObtenerProductos_ReturnsList()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.resultadoExitoso = 0;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            List<Producto> resultado = producto.obtenerProductos();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void borrarProducto_BorrarProducto_ReturnsTrue()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.debeResponder = true;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            Boolean resultado = producto.borrarProducto(2);
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void obtenerProductosDisponibles_ObtenerProductosDisponibles_ReturnsList()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            List<Producto> resultado = producto.obtenerProductosDisponibles();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void agregarAlCarrito_AgregarAlCarritoDeVentas_ReturnsTrue()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.debeResponder = true;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            Boolean resultado = producto.agregarAlCarrito(3);
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void obtenerProductosCarrito_ObtenerProductosDeCarritoDeVentas_ReturnsList()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            List<Producto> resultado = producto.obtenerProductosCarrito();
            Assert.IsNotNull(resultado);


        }

        [Test]
        public void eliminarDelCarrito_EliminarDelCarritoDeVentas_ReturnsTrue()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.debeResponder = true;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            Boolean resultado = producto.eliminarDelCarrito(3);
            Assert.AreEqual(resultado, true);

        }
    }
}
