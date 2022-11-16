<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Modificar Productos.aspx.cs" Inherits="Ecommerce.Modificar_Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Modificar Productos</h2>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">

        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo de Articulo: </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlDescCategoria" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlDescCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="txtDesc" class="form-label">Nombre de Articulo: </label>
                <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtDescAD" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescAD" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="ProductosListaEdit.aspx" cssclass="btn btn-primary">Cancelar</a>
                <asp:Button Text="Inactivar" ID="btnInactivar" OnClick="btnInactivar_Click" CssClass="btn btn-warning" runat="server" />
            </div>
        </div>

        <div class="col-6">

            <div class="mb-3">
                <label for="txtObs" class="form-label">Observaciones: </label>
                <asp:TextBox runat="server" ID="txtObs" CssClass="form-control" />
            </div>



            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Imagen Url</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgArticulo" Width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>



    </div>


</asp:Content>
