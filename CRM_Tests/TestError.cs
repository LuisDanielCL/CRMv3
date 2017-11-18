﻿using CRM_Proyect.Modelo;
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

    class TestError
    {
        private string Error_Titulo_Mayor_A_50_Caracteres = "Título debe tener como máximo 50 caracteres";
        private string Error_Titulo_Vacio = "Título no puede estar vacio";
        private string Error_Descripcion_Mayor_A_200_Caracteres = "Descripción debe tener como máximo 200 caracteres";
        private string Error_Descripcion_Vacio = "Descripción no puede estar vacio";
        private int Exito_Insercion = 0;
        private int Error_Insercion = -1;
        [Test]
        public void enviarError_TituloMuyLargo_ReturnsLargo_Mayor_50()
        {
            var instancia = new Controlador();
            var resultado = instancia.enviarError(new String('x', 51), "Descripción");
            Assert.AreEqual(resultado, Error_Titulo_Mayor_A_50_Caracteres);
        }

        [Test]
        public void enviarError_TituloVacio_Returns_Titulo_Vacio()
        {
            var instancia = new Controlador();
            var resultado = instancia.enviarError("", "Descripción");
            Assert.AreEqual(resultado, Error_Titulo_Vacio);
        }

        [Test]
        public void enviarError_DescripcionMuyLargo_ReturnsDescripcion_Mayor_200()
        {
            var instancia = new Controlador();
            var resultado = instancia.enviarError("Título", new String('x', 201));
            Assert.AreEqual(resultado, Error_Descripcion_Mayor_A_200_Caracteres);
        }

        [Test]
        public void enviarError_DescripcionVacio_Returns_Descripcion_Vacio()
        {
            var instancia = new Controlador();
            var resultado = instancia.enviarError("Título", "");
            Assert.AreEqual(resultado, Error_Descripcion_Vacio);
        }


        [Test]
        public void enviarError_envioCorrecto_Return_0()
        {
            FakeError fakeManager = new FakeError();
            ValidadorError instancia = new ValidadorError(fakeManager);
            int resultado = instancia.enviarError("Titulo", "descripcion");
            Assert.AreEqual(resultado, Exito_Insercion );
        }


        [Test]
        public void enviarError_ErrorInsercion_Return_m1()
        {
            FakeError fakeManager = new FakeError();
            fakeManager.enviarExitoRetorno = -1;
            ValidadorError instancia = new ValidadorError(fakeManager);
            int resultado = instancia.enviarError("Titulo", "descripcion");
            Assert.AreEqual(resultado, Error_Insercion);
        }

        [Test]
        public void obtenerErrores_ObtenerErroresCorrecto_ReturnsList()
        {
            FakeBaseDatos fakeBD = new FakeBaseDatos(true, true, true);
            ModeloError modeloError = new ModeloError(fakeBD);
            List<ErrorConsulta> resultado = modeloError.obtenerErrores();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void obtenerErrores_ObtenerErroresFalso_ReturnsNull()
        {
            FakeBaseDatos fakeBD = new FakeBaseDatos(true, true, false);
            ModeloError modeloError = new ModeloError(fakeBD);
            List<ErrorConsulta> resultado = modeloError.obtenerErrores();
            Assert.IsNotNull(resultado);
        }

        [Test]
        public void eliminarError_ErrorEliminar_Return_false()
        {
            FakeError fakeManager = new FakeError();
            fakeManager.eliminarExitoRetorno = false;
            ValidadorError instancia = new ValidadorError(fakeManager);
            bool resultado = instancia.eliminarError(1);
            Assert.AreEqual(resultado, false);
        }

        [Test]
        public void eliminarError_ExitoEliminar_Return_True()
        {
            FakeError fakeManager = new FakeError();
            ValidadorError instancia = new ValidadorError(fakeManager);
            bool resultado = instancia.eliminarError(1);
            Assert.AreEqual(resultado, true);
        }


    }
}
