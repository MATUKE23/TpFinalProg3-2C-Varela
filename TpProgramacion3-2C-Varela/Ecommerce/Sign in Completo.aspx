<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sign in Completo.aspx.cs" Inherits="Ecommerce.Sign_in_Completo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Datos de Contacto</h1>
    <br />
    
    <h2>Provincia:  <asp:DropDownList ID="DropDownProvincias" runat="server"></asp:DropDownList>  </h2> 
        
    <h2>Partido:  <asp:DropDownList ID="DropDownPartido" runat="server"></asp:DropDownList></h2>
     
    <h2>Codigo Postal:<asp:DropDownList ID="DropDownCodigoPostal" runat="server"></asp:DropDownList></h2>

    <h2>Calle:<asp:TextBox ID="TextBoxCalle" runat="server"></asp:TextBox></h2>

    <h2>Numero de calle: <asp:TextBox ID="TextBoxNroCalle" runat="server"></asp:TextBox></h2>

    <h2>Entre calles: <asp:TextBox ID="TextBoxEntreCalles" runat="server"></asp:TextBox></h2>

    <h2>Edificio: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></h2>

    <h2>Departamento: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></h2>

    <h2>Informacion adicional: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></h2>

    <h2>Localidad:<asp:DropDownList ID="DropDownLocalidad" runat="server"></asp:DropDownList> </h2>

    <h2>Nombre/s: <asp:TextBox ID="TextBoxNombres" runat="server"></asp:TextBox></h2>
       
    <h2>Apellido/s: <asp:TextBox ID="TextBoxApellidos" runat="server"></asp:TextBox></h2>

    <h2>DNI: <asp:TextBox ID="TextBoxDNI" runat="server"></asp:TextBox></h2>

    <h2>Telefono de contacto1:<asp:TextBox ID="TextBoxTelContacto1" runat="server"></asp:TextBox></h2>

    <h2>Telefono de contacto2: <asp:TextBox ID="TextBoxTelContacto2" runat="server"></asp:TextBox></h2>

    <h2>Fecha de Nacimiento:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>  </h2>


    <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" />

</asp:Content>
