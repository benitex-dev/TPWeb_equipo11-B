<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="TPWeb_equipo11_B.Premios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Elegí tu premio</h1>

    <div class="d-flex flex-row justify-content-evenly">

        <asp:Repeater ID="repRepetidor" runat="server" OnItemCommand="repRepetidor_ItemCommand1">
            <ItemTemplate>

                <div class="card" style="width: 18rem;">


                    <div id="carousel<%# Eval("Id") %>" class="carousel slide">
                        <div class="carousel-inner">
                            <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                <ItemTemplate>
                                    <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>' style="width:230px; height: 312px">
                                        <img src='<%# Eval("URL") %>' class="d-block w-100 object-fit-contain h-100" alt="...">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                      
                      
                        <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true" style="background-color: rgb(128, 128, 128)"></span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true" style="background-color: rgb(128, 128, 128)"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>


                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <asp:Button ID="btnPremioEleccion" CommandName="eleccion" CommandArgument='<%# Eval("Id") %>' class="btn btn-primary" runat="server" Text="Este" />
                        <%-- <a href="#" class="btn btn-primary" ID="btnPremio">Este</a>  OnItemCommand="repRepetidor_ItemCommand" --%>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>


</asp:Content>



<%--<img src="<%# Eval("Imagen.URL") %>" class="card-img-top" alt="...">--%>