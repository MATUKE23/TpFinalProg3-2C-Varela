<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Ecommerce.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="imagen col-lg-6">
                <img src="<%=articulo.URLIMAGEN%>" alt="Imagen" width="90%" height="90%" />
            </div>
            <div class="detalle col-lg-6">
                <h3><%=articulo.CODIGO%> - <%=articulo.DESCRIPCION%></h3>
                <p class="precio">$<%=articulo.PRECIO%></p>
                <h4>Stock Disponible</h4>
                <p class="unidades">10 Unidades</p>
                <p class="cantidad">
                    Cantidad:
                <p class="cantidad">
                    
                    <asp:TextBox ID="txtCantidad" runat="server" Width="55px" type="number" min="1" max="99" Text="1"></asp:TextBox>
                </p>
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar al carrito" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnPagar" runat="server" CssClass="btn btn-secondary"  Text="Agregar e ir a pagar" OnClick="btnPagar_Click"/>
            </div>
        </div>

</asp:Content>
