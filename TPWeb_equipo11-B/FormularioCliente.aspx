<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="TPWeb_equipo11_B.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ingresá tus datos</h1>
    

        <div class="mb-3">
            <label for="dni" class="form-label">DNI</label>
            <asp:TextBox AutoPostBack="true"  OnTextChanged="dni_TextChanged"  CssClass="form-control" ID="dni" placeholder="11222333" runat="server"></asp:TextBox>
           
            <asp:Label runat="server" ID="lblCliente" CssClass="form-label"></asp:Label>
        </div>
    <%
        if (verFormulario)
        {
    %>
      <div class="d-flex flex-row" style="align-items: center">
      <div class="">
          <label for="nombre" class="form-label">Nombre</label>
          <asp:TextBox runat="server" placeholder="Mi nombre" CssClass="form-control" ID="nombre"></asp:TextBox>

      </div>
      <div class="m-2">
          <label for="apellido" class="form-label">Apellido</label>
          <asp:TextBox runat="server" type="text" placeholder="Mi apellido" CssClass="form-control" ID="apellido"></asp:TextBox>

      </div>
      <div class="m-2">
          <label for="email" class="form-label">Email</label>
          <asp:TextBox runat="server" AutoCompleteType="Email" placeholder="email@gmail.com" CssClass="form-control" ID="email"></asp:TextBox>
      </div>
  </div>
  <div class="d-flex flex-row" style="align-items: center">
      <div>
          <label for="direccion" class="form-label">Dirección</label>
          <asp:TextBox runat="server" placeholder="Mi dirección" CssClass="form-control" ID="direccion"></asp:TextBox>
      </div>
      <div class="m-2">
          <label for="ciudad" class="form-label">Ciudad</label>
          <asp:TextBox runat="server" placeholder="Mi Ciudad" CssClass="form-control" ID="ciudad"></asp:TextBox>
      </div>
      <div class="m-2">
          <label for="cp" class="form-label">CP</label>
          <asp:TextBox runat="server" placeholder="Mi Cod Postal" CssClass="form-control" ID="cp"></asp:TextBox>
      </div>

  </div>
     
      <%--checkbox--%>
      <div class="form-check">
         
         <asp:CheckBox runat="server" AutoPostBack="true" OnCheckedChanged="checkTerminos_CheckedChanged"  CssClass="form-check-input" type="checkbox" ID="checkTerminos"/>
          <label class="form-check-label" for="checkTerminos">
              Acepta terminos y condiciones
          </label>
          <asp:Label runat="server" ID="lblAceptaTermYCond" visible="false" CssClass="form-check-label --bs-danger-text-emphasis" for="checkTerminos">
            Para continuar debes aceptar los terminos y condiciones.
           </asp:Label>
      </div>
     
      <asp:Button runat="server" Text="Participar!" ID="btnAgregar" OnClick="OnClick" CssClass="btn btn-primary"/>

    <%}%>
  
        
    
    
    
</asp:Content>
