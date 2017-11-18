<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Vista/Home.Master" CodeBehind="registrarEntrenamientos.aspx.cs" Inherits="CRM_Proyect.Vista.SeguimientoEntrenamientos" %>

<asp:Content ID="contentSeguimientoEntrenamientos" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Crear entrenamiento</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form role="form">
              <div class="box-body">
                <div class="form-group">
                  <label for="precio">Título</label>
                  <input  class="form-control" id="txtTitulo" >
                </div>
                <div class="form-group">
                  <label for="descripcion">Descripción</label>
                  <input  class="form-control" id="txtDescripcion">
                </div>  
                <div class="form-group">
                  <label for="descripcion">Fecha</label>
                    <input class="form-control" id="datePicker" type="datetime-local" name="bdaytime">
                </div>  
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                  <button type="button" onclick='crearEntrenamiento()' class="btn btn-primary" >Agregar</button>
              </div>
            </form>
          </div>
        </div>
    <script src="Scripts/vista.js"></script>
    


</asp:Content>


