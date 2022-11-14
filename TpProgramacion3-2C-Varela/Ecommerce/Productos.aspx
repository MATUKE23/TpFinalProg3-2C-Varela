<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Ecommerce.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-2 g-4">
        <% foreach (Dominio.Articulo arti in ListaArticulos)
            {%>
        <div class="col">
            <div class="card m-5" style="width: 25rem;">
                <img src="<%: arti.URLIMAGEN%>" class="card-img-top" alt="No Disponible">
                <div class="card-body">
                    <h5 class="card-title"><%: arti.DESCRIPCION%></h5>
                    <h4>Precio:</h4>
                    <h5 class="card-title"><%: arti.PRECIO + "$"%> </h5>
                    <a href="Producto.aspx?id=<%:arti.ID %>" class="btn btn-success">Ver Detalle</a>
                </div>
            </div>
        </div>
        <%}%>
    </div>

</asp:Content>
