<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Vista/Home.Master" CodeBehind="RegistrarError.aspx.cs" Inherits="CRM_Proyect.Vista.registrarError" %>


<asp:Content ID="contentRegistrarError" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        
            <form role="form">
              <div class="box-body">
                <div class="form-group">
                  <label for="titulo">Título</label>
                  <input  class="form-control" id="tituloInput" >
                </div>
                <div class="form-group">
                  <label for="descripcion">Descripción</label>
                  <textarea  class="form-control" id="descripcionInput"></textarea>
                </div>  
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <button type="button" onclick='enviarError()' class="btn btn-primary" >Enviar error</button>
              </div>
            </form>
 

    <script src="Scripts/vista.js"></script>
</asp:Content>
