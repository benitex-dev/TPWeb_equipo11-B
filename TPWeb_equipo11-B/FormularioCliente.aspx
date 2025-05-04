<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="TPWeb_equipo11_B.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ingresá tus datos</h1>
    
        <div class="mb-3">
            <label for="dni" class="form-label">DNI</label>
            <asp:TextBox   CssClass="form-control" ID="dni" placeholder="11222333" runat="server"></asp:TextBox>
        </div>
        <div class="d-flex flex-row" style="align-items: center">
            <div class="">
                <label for="nombre" class="form-label">Nombre</label>
                 <asp:TextBox runat="server" placeholder="Jorge" CssClass="form-control" ID="nombre"></asp:TextBox>
                
            </div>
            <div class="m-2">
                <label for="apellido" class="form-label">Apellido</label>
                 <asp:TextBox runat="server" type="text"  placeholder="Benitez" CssClass="form-control"  ID="apellido"></asp:TextBox>
              
            </div>
            <div class="m-2">
                <label for="email" class="form-label">Email</label>
                 <asp:TextBox runat="server" AutoCompleteType="Email" placeholder="email@gmail.com" CssClass="form-control"  ID="email"></asp:TextBox>   
            </div>
        </div>
        <div class="d-flex flex-row" style="align-items: center">
            <div>
                <label for="direccion" class="form-label">Dirección</label>
                 <asp:TextBox runat="server" placeholder="Mi dirección" CssClass="form-control" ID="direccion"></asp:TextBox>
            </div>
            <div class="m-2">
                <label for="ciudad" class="form-label">Ciudad</label>
                 <asp:TextBox runat="server" placeholder="Mi Ciudad"  CssClass="form-control" ID="ciudad"></asp:TextBox>     
            </div>
            <div class="m-2">
                <label for="cp" class="form-label">CP</label>
                 <asp:TextBox runat="server" placeholder="1880" CssClass="form-control" ID="cp"></asp:TextBox>               
            </div>

        </div>
       
        <%--checkbox--%>
        <div class="form-check">
            <input class="form-check-input" type="checkbox" value="" id="checkChecked" checked>
            <label class="form-check-label" for="checkChecked">
                Acepta terminos y condiciones
            </label>
        </div>
        <asp:Button runat="server" Text="Participar!" CssClass="btn btn-primary"/>
        
    
    
    
</asp:Content>
