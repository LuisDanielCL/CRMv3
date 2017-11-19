﻿//Scripts de la comunicacion de la interfaz al servidor.
// Jonthan Rodríguez

// Evento del boton contactos
function mostrarContactos() {
    $("#botonContactos").on("click", function () {
        tablaContactos();
    });
}

//Actualiza la tabla de contactos
function tablaContactos() {
    var table = $("#tablaContactos").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/Contactos.aspx/obtenerUsuarios",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "primerApellido" },
            { "data": "segundoApellido" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }
        ]
    });
}

//function cargarCategorias() {
//    var box = $("cbcategoria").dropdown({
//        destroy: true,
//        responsive: true,
//        ajax: {
//            method: "POST",
//            url: "Vista/AgregarProducto.aspx/obtenerCategorias",
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            data: function (d) {
//                return JSON.stringify(d);
//            },
//            dataSrc: "d.data"
//        },
//    })
//}

//Actualiza la tabla de contactos
function cargarVendedores() {
    var table = $("#tablaVendedores").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/Vendedores.aspx/obtenerVendedores",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "primerApellido" },
            { "data": "segundoApellido" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            
        ]
    });
}

//Evento del boton empresas
function mostrarEmpresas() {
    $("#botonEmpresa").on("click", function () {
        deplegarTablaEmpresa();
    });
}

//Actualiza la tabla empresas
function deplegarTablaEmpresa() {
    var table = $("#tablaEmpresa").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/InfoEmpresas.aspx/obtenerEmpresas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }

        ]
    });
}

//Evento del boton listar personas
function mostrarPersonas() {
    $("#botonListarPersonas").on("click", function () {
        desplagarTablaPersonas();
    });
}

//Actualiza la tabla de personas
function desplagarTablaPersonas() {
    var table = $("#tablaAgregarPersonas").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/AgregarPersonas.aspx/obtenerPersonas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "primerApellido" },
            { "data": "segundoApellido" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }

        ]
    });
}

// Se comunica con el servidor para agregar a contactos la persona con
// el el id que recibe 
function agregarContacto(id) {
    var data = {user : id}
    $.ajax({

        method: "POST",
        url: "/Vista/AgregarPersonas.aspx/agregarContacto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        desplagarTablaPersonas();
    });
}

//  Se comunica con el servidor para eliminar un contacto persona, 
//  toma como parametro el id de la persona a eliminar  de contactos
function borrarContacto(id) {
    var data = { user: id }
    $.ajax({

        method: "POST",
        url: "/Vista/Contactos.aspx/borrarContacto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaContactos();
    });
}

//Evento del boton listar empresas
function mostrarEmpresasLibre() {
    $("#botonEmpresaLibre").on("click", function () {
        deplegarTablaEmpresaLibre();
    });
}

//Actualiza la tabla de empresas que no estan en mis contactos
function deplegarTablaEmpresaLibre() {
    var table = $("#tablaEmpresaLibre").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/AgregarEmpresa.aspx/mostrarEmpresas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }

        ]
    });
}

// Se comunica con el servisdor para agregar una empresa a contactos
function agregarContactoEmpresa(id) {
    var data = { user: id }
    $.ajax({

        method: "POST",
        url: "/Vista/AgregarEmpresa.aspx/agregarContactoEmpresa",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        deplegarTablaEmpresaLibre();
    });
}

//Elimina el una empresa de contacto
function borrarContactoEmpresa(id) {
    var data = { idEmpresa: id }
    $.ajax({

        method: "POST",
        url: "/Vista/InfoEmpresas.aspx/borrarContactoEmpresa",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        deplegarTablaEmpresa();
    });
}

// Reinicia la sesión
function cerrarSesion() {
    $.ajax({

        method: "POST",
        url: "/Vista/index.aspx/cerrarSession",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
    });
}


//Evento del botón productos
function mostrarProductos() {
    $("#botonProductos").on("click", function () {
        tablaProductos();
    });
}

//Actualiza la tabla productos
function tablaProductos() {
    var table = $("#tablaProductos").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/EliminarProducto.aspx/mostrarProductos",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "precio" },
            { "data": "categoria" },
            { "data": "accion" },
        ]
    });
}

// Elimina un  producto
function eliminarProducto(id) {
    var data = { idProducto: id }
    $.ajax({

        method: "POST",
        url: "/Vista/EliminarProducto.aspx/borrarProducto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaProductos();
    });
}

// Evento del boton listar productos
function mostrarProductosDisponibles() {
    $("#botonProductosDisponibles").on("click", function () {
        tablaProductosDisponibles();
    });
}

//Actualiza la tabla de carrito
function mostrarProductosCarrito() {
    $("#botonProductosCarrito").on("click", function () {
        tablaProductosCarrito();
    });
}

//Muestra los productos que no esta en ventas, ni en propuetas de venta
function tablaProductosDisponibles() {
    var table = $("#tablaProductosDisponibles").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/CrearPropuesta.aspx/mostrarProductosDisponibles",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "precio" },
            { "data": "categoria" },
            { "data": "accion" },
        ]
    });
}

//Muestra los productos seleccionados para crear venta o propuesta de venta.
function tablaProductosCarrito() {
    var table = $("#tablaProductosCarrito").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/CrearPropuesta.aspx/mostrarProductosCarrito",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "precio" },
            { "data": "categoria" },
            { "data": "accion" },
        ]
    });
}

//Agrega un producto a la tabla temporal carrito
function agregarAlCarrito(id) {
    var data = { idProducto: id }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearPropuesta.aspx/agregarAlCarrito",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaProductosDisponibles();
        tablaProductosCarrito();
    });

}

//Elimina un producto de la tabla temporal carrito
function eliminarDelCarrito(id) {
    var data = { idProducto: id }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearPropuesta.aspx/eliminarDelCarrito",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaProductosDisponibles();
        tablaProductosCarrito();
    });
}

//Se comunica con el servidor para crear una propuesta
//Toma los valores del form
function crearPropuesta() {

    $precio = $("#precio").val();
    $descuento = $("#descuento").val();
    $comision = $("#comision").val();
    $idComprador = $("#empresa").val();
    var data = {
        precio: $precio,
        descuento: $descuento,
        comision: $comision,
        idComprador : $idComprador
    }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearPropuesta.aspx/crearPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        alert(info.d);
    });
}

//Se comunica con el servidor para insertar a la base de datos
// un nuevo producto
function agregarProducto() {
    $nombre = $("#nombre").val();
    $descripcion = $("#descripcion").val();
    $precio = $("#precio").val();
    $categoria = $("#categoria").val();
    var data = {
        nombre: $nombre,
        descripcion: $descripcion,
        precio: $precio,
        categoria: $categoria
    }
    $.ajax({

        method: "POST",
        url: "/Vista/AgregarProducto.aspx/insertarProducto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        console.log(info);
        alert(info.d);
    });
}

//Evento del boton ver propuetas de venta
function mostrarPropuestasVenta() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaPropuestaDeVenta();
        actualizarTablaProductoPropuesta();
    });
}

//Actualiza la tabla propuestas de venta
function tablaPropuestaDeVenta() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/VerPropuestas.aspx/obtenerPropuestasDeVenta",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "comision" },
            { "data": "fecha" },
            { "data": "respuesta" },
            { "data": "comprador" }
        ]
    });
}

// Muestra la tabla de productos de una propuesta que se da
// por parámetro
function verProductos(id) {
    actualizarTablaProductoPropuesta();
    var data = { idPropuesta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/VerPropuestas.aspx/verProductosPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        $.each(info.d.data, function (index, value) {
            llenarTablaProductoPropuesta(info.d.data, index, value);
        });
    });
}

//Llena la tabla de productos
function llenarTablaProductoPropuesta(response, index, value)
{
    $('#tablaProductoPropuesta').DataTable({
        "destroy": true,
        "data": response,
        "columns":[
            {"data":"nombre"},
            {"data":"descripcion"},
            {"data":"precio"}
        ]
    });
}

//Permite ver comentarios de una propuesta
function verComentarios(id) {
    actualizarTablaComentariosPropuesta();
    var data = { idPropuesta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/VerPropuestas.aspx/verComentariosPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        $.each(info.d.data, function (index, value) {
            llenarTablaComentariosPropuesta(info.d.data, index, value);
        });
    });
}

function llenarTablaComentariosPropuesta(response, index, value) {
    $('#tablaComentarios').DataTable({
        "destroy": true,
        "data": response,
        "columns": [
            { "data": "nombre" },
            { "data": "apellidoUno" },
            { "data": "apellidoDos" },
            { "data": "comentario" }
        ]
    });
}

// Limpia la tabla en cuestion
function actualizarTablaProductoPropuesta() {
    $("#tablaProductoPropuesta tr>td").remove();
}

// Limpia la tabla en cuestion
function actualizarTablaComentariosPropuesta() {
    $("#tablaComentarios tr>td").remove();
}

function mostrarPropuestasVentaCompras() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaPropuestaDeVentaCompra();
        actualizarTablaProductoPropuestaCompra();
    });
}

function tablaPropuestaDeVentaCompra() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/Compras.aspx/obtenerPropuestasDeVenta",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "accion" }
        ]
    });
}

// Limpia la tabla en cuestion
function actualizarTablaProductoPropuestaCompra() {
    $("#tablaProductoPropuesta tr>td").remove();
}

function comprar(id) {
    var data = { idPropuesta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/Compras.aspx/comprar",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaPropuestaDeVentaCompra();
    });

}

//Evento del boton ver ventas
function mostrarVentas() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaVentas();
        actualizarTablaVentas();
    });
}

//Actualiza la tabla de ventas
function tablaVentas() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/VerVentas.aspx/obtenerVentas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "fecha" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "comision" },
            { "data": "vendedor" },
            { "data": "comprador" }
        ]
    });
}

function actualizarTablaVentas() {
    $("#tablaProductoPropuesta tr>td").remove();
}

// Evento del boton ver propuestasd de venta
function mostrarPropuestasVentaComprasUsuario() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaPropuestaDeVentaCompraUsuario();
        actualizarTablaProductoPropuestaCompraUsuario();
    });
}

function tablaPropuestaDeVentaCompraUsuario() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/ComentarPropuesta.aspx/obtenerPropuestasDeVenta",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "accion" }
        ]
    });
}

function actualizarTablaProductoPropuestaCompraUsuario() {
    $("#tablaProductoPropuesta tr>td").remove();
}

function comentar(id) {
    document.getElementById("botonComentar").disabled = false;
    document.getElementById("botonComentar").value = id;
}

function agregarComentario() {
    $comentario = $('#comentario').val();
    $id = document.getElementById("botonComentar").value;
    var data = {
        idPropuesta: $id,
        comentario : $comentario
    }
    $.ajax({

        method: "POST",
        url: "/Vista/ComentarPropuesta.aspx/comentarPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        document.getElementById("botonComentar").disabled = true;
        $('#comentario').val('');
    });
}

function cambiarRespuesta(id) {
    document.getElementById("botonRespuesta").disabled = false;
    document.getElementById("botonRespuesta").value = id;
}

// Cambia la respuesta de una propuesta de usuario
function actualizarRespuesta() {
    $respuesta = $('#respuesta').val();
    $id = document.getElementById("botonRespuesta").value;
    var data = {
        idPropuesta: $id,
        respuesta: $respuesta
    }
    $.ajax({

        method: "POST",
        url: "/Vista/VerPropuestas.aspx/cambiarRespuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        document.getElementById("botonRespuesta").disabled = true;
        $('#respuesta').val('');
        tablaPropuestaDeVenta();
        alert(info.d);
    });
}

// Crea una nueva venta
// Toma los valores del form
function crearVenta() {
    $precio = $("#precio").val();
    $descuento = $("#descuento").val();
    $comision = $("#comision").val();
    $idComprador = $("#empresa").val();
    
    var data = {
        precio: $precio,
        descuento: $descuento,
        comision: $comision,
        idComprador : $idComprador
    }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearVenta.aspx/crearVenta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        alert(info.d)
        //alert("exito");
    });
}

// Crea un nuevo reporte de error
// Toma los valores del form
function enviarError() {
    $titulo = $("#tituloInput").val();
    $descripcion = $("#descripcionInput").val();
    

    var data = {
        titulo: $titulo,
        descripcion: $descripcion
    }
    $.ajax({

        method: "POST",
        url: "/Vista/RegistrarError.aspx/enviarError",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        alert(info.d)
        document.getElementById("tituloInput").value = "";
        document.getElementById("descripcionInput").value = "";

        //alert("exito");
    });
}

function crearEntrenamiento() {
    $titulo = $("#txtTitulo").val();
    $descripcion = $("#txtDescripcion").val();
    $fecha = $("#datePicker").val();


    var data = {
        titulo: $titulo,
        descripcion: $descripcion,
        fecha: $fecha
    }
    $.ajax({

        method: "POST",
        url: "/Vista/registrarEntrenamientos.aspx/crearEntrenamiento",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        alert(info.d)
        document.getElementById("txtTitulo").value = "";
        document.getElementById("txtDescripcion").value = "";
        document.getElementById("datePicker").value = "";
        cargarEntrenamientosRegistro();
        //alert("exito");
    });
}


//Actualiza la tabla de entrenamientosRegistro
function cargarEntrenamientosRegistro() {
    var table = $("#tablaEntrenamientos").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/registrarEntrenamientos.aspx/cargarEntrenamientos",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "id" },
            { "data": "titulo" },
            { "data": "descripcion" },
            { "data": "fecha" },
            { "data": "accion" }

        ]
    });
}

//Actualiza la tabla de error
function cargarError() {
    var table = $("#tablaVerErrores").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/VerErrores.aspx/cargarErrores",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "id" },
            { "data": "titulo" },
            { "data": "descripcion" },
            { "data": "usuario" },
            { "data": "accion" }

        ]
    });
}

//Actualiza la tabla de error
function cargarSeguirEntrenamientos() {
    var table = $("#tablaSeguirEntrenamientos").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/seguirEntrenamientos.aspx/obtenerEntrenamientosNoLLevados",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "id" },
            { "data": "titulo" },
            { "data": "descripcion" },
            { "data": "fecha" },
            { "data": "accion" }

        ]
    });
}



//Actualiza la tabla de error
function cagargarMisEntrenamientos() {
    var table = $("#tablaMisEntranamientos").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/seguirEntrenamientos.aspx/obtenerMisEntrenamientos",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "id" },
            { "data": "titulo" },
            { "data": "descripcion" },
            { "data": "fecha" },
            { "data": "accion" }

        ]
    });
}



//  Se comunica con el servidor para agregar entrenamiento a misEntrenamientos
function agregarMiEntrenamiento(pidEntrenamiento, pidUsuario) {
    var data = {
        idEntrenamiento: pidEntrenamiento
        }
    $.ajax({

        method: "POST",
        url: "/Vista/seguirEntrenamientos.aspx/agregarMiEntrenamiento",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        cargarSeguirEntrenamientos();
        cagargarMisEntrenamientos();
    });
}

//  Se comunica con el servidor para agregar entrenamiento a misEntrenamientos
function eliminarMiEntrenamiento(pidEntrenamiento,pidUsuario) {
    var data = {
        idEntrenamiento: pidEntrenamiento,
        idUsuario: pidUsuario
        }
    $.ajax({

        method: "POST",
        url: "/Vista/seguirEntrenamientos.aspx/eliminarMiEntrenamiento",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        cargarSeguirEntrenamientos();
        cagargarMisEntrenamientos();
    });
}



//  Se comunica con el servidor para eliminar un error, 
//  toma como parametro el id del error
function eliminarError(id) {
    var data = { idError: id }
    $.ajax({

        method: "POST",
        url: "/Vista/VerErrores.aspx/eliminarError",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        cargarError();
    });
}


//  Se comunica con el servidor para eliminar un entrenamiento, 
//  toma como parametro el id del entrenamiento
function eliminarEntrenamiento(id) {
    var data = { idEntrenamiento: id }
    $.ajax({

        method: "POST",
        url: "/Vista/registrarEntrenamientos.aspx/eliminarEntrenamiento",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        cargarEntrenamientosRegistro();
    });
}

// Despliega los productos de una venta específica
// que recive como parámetro
function verProductosVenta(id) {
    actualizarTablaProductoPropuesta();
    var data = { idVenta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/VerVentas.aspx/verProductosVenta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        $.each(info.d.data, function (index, value) {
            llenarTablaProductoPropuesta(info.d.data, index, value);
        });
    });
}

function tablaRecomendaciones() {
    var table = $("#tablaRecomendaciones").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/Recomendaciones.aspx/cargarRecomendaciones",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "precio" },
            { "data": "categoria" },
        ]
    });
}