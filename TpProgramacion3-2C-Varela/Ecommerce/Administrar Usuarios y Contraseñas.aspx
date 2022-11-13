<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Administrar Usuarios y Contraseñas.aspx.cs" Inherits="Ecommerce.Administrar_Usuarios_y_Contraseñas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br />
    <h2>Buscar Usuario</h2>   <asp:TextBox ID="TextBoxBuscarUsuario" runat="server"></asp:TextBox>
    <h2>Modificar usuario</h2>  <asp:TextBox ID="TextBoxModificarUsuario" runat="server"></asp:TextBox>
    <h2>Modificar Contraseña</h2>  <asp:TextBox ID="TextBoxModificarContraseña" runat="server"></asp:TextBox>
</asp:Content>
