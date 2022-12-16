<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleCarritoConformado.aspx.cs" Inherits="Ecommerce.DetalleCarritoConformado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Productos Comprados</h1>

    
    <asp:GridView ID="dgvDatosDetalleCarritoConformado" runat="server" DataKeyNames="ARTICULO.CODIGO" CssClass="table" 
        class="card-text" AutoGenerateColumns="false" AllowPaging="false" PageSize="5"
        >
        <Columns>
            <asp:BoundField HeaderText="Codigo de Articulo" DataField="ARTICULO.CODIGO" />
            <asp:BoundField HeaderText="Descripcion de Articulo" DataField="ARTICULO.DESCRIPCION" />
            <asp:BoundField HeaderText="Cantidad" DataField="CANTIDAD" />
            <asp:BoundField HeaderText="Precio Unitario" DataField="ARTICULO.PRECIO" />
            <asp:BoundField HeaderText="Monto" DataField="MONTO"/>
        </Columns>

    </asp:GridView>
    <asp:Button Text="Volver al menu anterior" ID="IraMisPedidos" class="btn btn-primary" OnClick="IraMisPedidos_Click" runat="server" />

</asp:Content>
