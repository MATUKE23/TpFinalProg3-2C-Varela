<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PedidosVistaCliente.aspx.cs" Inherits="Ecommerce.PedidosCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:GridView ID="dgvProductos" runat="server" DataKeyNames="Id" CssClass="table" class="card-text" 
        
        AllowPaging="false" PageSize="5">
        <%--agrego paginacion y tope de paginas a la lista--%>
        <Columns>
            <asp:BoundField HeaderText="Fecha de Compra" DataField="FECHAVENTA" />
            <asp:BoundField HeaderText="Codigo de articulo" DataField="CODIGO" />
            <asp:BoundField HeaderText="Nombre de articulo" DataField="DESCRIPCION" />
            <asp:BoundField HeaderText="Nombre del cliente" DataField="NOMBRES" />
            <asp:BoundField HeaderText="Cantidad" DataField="CANTIDAD" />
            <asp:BoundField HeaderText="Apellido del cliente" DataField="APELLIDOS" />
            <asp:BoundField HeaderText="Precio del Articulo" DataField="PRECIO" />
            <asp:BoundField HeaderText="Monto" DataField="MONTO" />
            <asp:BoundField HeaderText="Domicilio" DataField="DOMICILIO" />
            <%-- CALLE+ NRO+ ENTRECALLES + DPTO + LOCALIDAD + OBSERVACIONES --%>
            <asp:BoundField HeaderText="Forma de Envio" DataField="FORMADEENVIO" />
            <asp:BoundField HeaderText="Forma de Pago" DataField="FORMADEPAGO" />
            <asp:CheckBoxField HeaderText="Estado" DataField="ESTADO" />


         
        </Columns>

    </asp:GridView>


</asp:Content>
