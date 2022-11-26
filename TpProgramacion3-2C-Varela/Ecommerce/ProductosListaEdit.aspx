<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ProductosListaEdit.aspx.cs" Inherits="Ecommerce.ProductosListaEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Lista de Productos</h1>

       <asp:GridView ID="dgvProductos" runat="server" DataKeyNames="Id" CssClass="table" class="card-text" AutoGenerateColumns="false" 
           OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" OnPageIndexChanging="dgvProductos_PageIndexChanging"             
        AllowPaging="false" PageSize="5"  >
        <%--agrego paginacion y tope de paginas a la lista--%>
        <Columns>
             <asp:BoundField HeaderText="Codigo de articulo" DataField="CODIGO" />
            <asp:BoundField HeaderText="Nombre de articulo" DataField="DESCRIPCION" />
            <asp:BoundField HeaderText="Tipo de Articulo" DataField="CATEG.DESCRIPCION" />
            <asp:BoundField HeaderText="Descripcion Adicional" DataField="DESCRIPCION_AD" />
            <asp:BoundField HeaderText="Observacion" DataField="OBS" />
            <asp:CheckBoxField HeaderText="Estado" DataField="ESTADO" />
            <asp:BoundField HeaderText="PRECIO" DataField="PRECIO" />
            <asp:CommandField HeaderText="Accion"  ShowSelectButton="true" SelectText="😵" />
            <%--agrego Emojo y boton--%>
        </Columns>

    </asp:GridView>
    <a href="Modificar Productos.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
