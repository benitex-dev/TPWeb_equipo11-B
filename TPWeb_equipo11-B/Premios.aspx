<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="TPWeb_equipo11_B.Premios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Elegí tu premio</h1>

    <div class="d-flex flex-row justify-content-evenly">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">

                  
                            <img src="<%# Eval("Imagen.URL") %>" class="card-img-top" alt="...">
                   

                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <a href="#" class="btn btn-primary">Éste</a>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

     
        </div>
    </div>

</asp:Content>
