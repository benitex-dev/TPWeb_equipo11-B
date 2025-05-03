<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="TPWeb_equipo11_B.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ingresá tus datos</h1>
    <form action="/" method="post">
           <div class="mb-3">
       <label for="dni" class="form-label">DNI</label>
       <input type="text" class="form-control" id="dni" placeholder="11222333">
   </div>
   <div class="d-flex flex-row" style="align-items: center">
       <div class="">
           <label for="nombre" class="form-label">Nombre</label>
           <input type="text" class="form-control" id="nombre" placeholder="Jorge">
       </div>
       <div class="m-2">
           <label for="apellido" class="form-label">Apellido</label>
           <input type="text" class="form-control" id="apellido" placeholder="Benitez">
       </div>
       <div class="m-2">
           <label for="email" class="form-label">Email</label>
           <input type="email" class="form-control" id="email" placeholder="email@gmail.com">
       </div>
   </div>
   <div class="d-flex flex-row" style="align-items: center">
       <div class="">
           <label for="direccion" class="form-label">Dirección</label>
           <input type="text" class="form-control" id="cireccion" placeholder="Mi direccion">
       </div>
       <div class="m-2">
           <label for="ciudad" class="form-label">Ciudad</label>
           <input type="text" class="form-control" id="ciudad" placeholder="Mi ciudad">
       </div>
       <div class="m-2">
           <label for="cp" class="form-label">CP</label>
           <input type="email" class="form-control" id="cp" placeholder="CP1234">
       </div>
       
</div>
   <div class="form-check">
   <input class="form-check-input" type="checkbox" value="" id="checkChecked" checked>
   <label class="form-check-label" for="checkChecked">
       Acepta terminos y condiciones
   </label>
      
   </div>
    <button class="btn btn-primary">
    Participar!
</button>
    </form>
    
    
</asp:Content>
