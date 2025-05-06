<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PromoWeb.aspx.cs" Inherits="TPWeb_equipo11_B.PromoWeb1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Promo Ganá</h1>
    <asp:Label  for="codigoPromo" id="lblPromo" class="form-label" Text="Ingresá el código de tu voucher!" runat="server" />    
    
    <asp:TextBox ID="codigoPromo" CssClass="form-control" placeholder="XXXXXXXXXXX" runat="server"></asp:TextBox>
    <asp:Button ID="btnPromo" OnClick="btnPromo_Click" CssClass="btn btn-primary mt-2" runat="server" Text="Siguiente" />
    <asp:Button ID="btnInicio" OnClick="btnInicio_Click" CssClass="btn btn-primary mt-2" runat="server" Text="Inicio" visible="false"/>
    
</asp:Content>
