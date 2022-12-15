<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConfimacionPedido.aspx.cs" Inherits="Ecommerce.ConfimacionPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Gracias por su compra.
    </h2>
    <br />
    <h2>Su pedido esta en proceso de produccion, le informaremos cuando este disponible para entregar.</h2>

    <asp:Button Text="Ir a mis Pedidos" ID="IraMisPedidos" class="btn btn-primary" OnClick="IraMisPedidos_Click1" runat="server" />

</asp:Content>
