<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Ecommerce.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <% foreach (Dominio.Articulo arti in ListaArticulos)
            {%>
        <div class="card m-5" style="width: 18rem;">
            <img src="<%: arti.URLIMAGEN%>" class="card-img-top" alt="No Disponible">
            <div class="card-body">
                <h5 class="card-title"><%: arti.DESCRIPCION%></h5>
             
                <a href="Producto.aspx?id=<%: arti.ID %>" class="btn btn-success">Ver Detalle</a>
            </div>
        </div>
   
    <%}%>


</asp:Content>
