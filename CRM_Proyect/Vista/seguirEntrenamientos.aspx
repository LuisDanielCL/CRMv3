<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seguirEntrenamientos.aspx.cs" MasterPageFile="~/Vista/Home.Master" Inherits="CRM_Proyect.Vista.seguirEntrenamientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seguir entrenamientos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
        <div class="col-md-3 col-sm-3 col-xs-3">
            <h2 class="text-center">Seguir entrenamientos</h2>                
        </div>
        <div class="col-md-4 col-sm-4 col-xs-4">
            <button type="button" id="btn" class="btn btn-success" onclick ="cargarSeguirEntrenamientos()">
                <span class="glyphicon glyphicon-list" aria-hidden="true"></span> Listar
            </button>
        </div>
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Entrenamientos disponibles</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table id="tablaSeguirEntrenamientos" class="table table-responsive  table-bordered table-hover">
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
        
        <div class="col-md-4 col-sm-4 col-xs-4">
            <button type="button" id="btnMisEntrenamientos" class="btn btn-success" onclick ="cagargarMisEntrenamientos()">
                <span class="glyphicon glyphicon-list" aria-hidden="true"></span> Listar
            </button>
        </div>
       <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Mis Entrenamientos</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table id="tablaMisEntranamientos" class="table table-responsive  table-bordered table-hover">
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

    </div>
    


    
</asp:Content>

    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="Scripts/vista.js"></script>
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script>
          $(function () {
              $('#tablaSeguirEntrenamientos').DataTable({
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
        $(function () {
            $('#tablaMisEntranamientos').DataTable({
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



