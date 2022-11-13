<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Ecommerce.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row" style="display: flex; flex-direction: row; justify-content:space-between;">
            <%foreach (var arti in ListaArticulos)
                {%>
            <div class="card m-5" style="width: 18rem;">
                <img src="<%=arti.URLIMAGEN%>" class="card-img-top" alt="No Disponible">
                <div class="card-body">
                    <h5 class="card-title"><%=arti.DESCRIPCION%></h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="Producto.aspx?id_producto=<%=arti.ID %>" class="btn btn-success">Ver más</a>
                </div>
            </div>
            <%}%>
        </div>
</asp:Content>
