<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Vista/Home.Master" CodeBehind="registrarEntrenamientos.aspx.cs" Inherits="CRM_Proyect.Vista.SeguimientoEntrenamientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registrar entrenamientos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-3 col-sm-3 col-xs-3">
            <h2 class="text-center">Ver entrenamientos</h2>                
        </div>
        <div class="col-md-4 col-sm-4 col-xs-4">
            <button type="button" id="botonListarPersonas" class="btn btn-success" onclick ="cargarEntrenamientosRegistro()">
                <span class="glyphicon glyphicon-list" aria-hidden="true"></span> Listar
            </button>
        </div>
    </div>
     <br />
        <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Tabla Personas</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table id="tablaEntrenamientos" class="table table-responsive  table-bordered table-hover">
                <thead>
                <tr>
                  <th>ID</th>
                  <th>Título</th>
                  <th>Descripción</th>
                  <th>Fecha</th>
                  <th>Acción</th>
                </tr>
                </thead>
                
                <tfoot>
                <tr>
                  <th>ID</th>
                  <th>Título</th>
                  <th>Descripción</th>
                  <th>Fecha</th>
                  <th>Acción</th>
                </tr>
                </tfoot>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
       </div>


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
    </div>
    


    
</asp:Content>

    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="Scripts/vista.js"></script>
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script>
  $(function () {
      $('#tablaEntrenamientos').DataTable({
        'paging': true,
        'lengthChange': true,
        'searching': true,
        'ordering': true,
        'info': true,
        'autoWidth': true,
        'destroy': true,
        'responsive': true,
    });

  })
</script>

</asp:Content>



