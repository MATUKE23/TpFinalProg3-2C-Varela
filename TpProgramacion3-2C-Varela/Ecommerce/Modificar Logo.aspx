<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Modificar Logo.aspx.cs" Inherits="Ecommerce.Modificar_Logo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Modificar Logo</h2>
        <br />
        <br />
        <asp:TextBox ID="TextBoxCargaLogo" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonCargarLogo" runat="server" Text="Cargar Logo" />
    </div>
</asp:Content>
