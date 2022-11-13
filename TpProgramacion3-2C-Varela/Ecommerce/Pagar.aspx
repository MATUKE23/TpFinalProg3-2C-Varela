<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="Ecommerce.Pagar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <asp:GridView ID="dgvArticulos" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Código" DataField="CODIGO" />
                        <asp:BoundField HeaderText="Descripción" DataField="DESCRIPCION" />
                        <asp:BoundField HeaderText="Cantidad" DataField="CANTIDAD" />
                        <asp:BoundField HeaderText="Precio" DataField="PRECIO" />
                    </Columns>

                </asp:GridView>
                <h4>Total: $ <%=total %></h4>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="DbxFormaPago" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="checkbxEnvio" runat="server" Text="¿Enviar a domicilio?"  />

            </div>
            <div>
                <asp:Button ID="BtnEnviarPedido" Text="Enviar Pedido" CssClass="btn btn-success" runat="server" OnClick="EnviarPedido_click"/>
            </div>
        </div>
    </div>

</asp:Content>
