<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DatosClienteCargados.aspx.cs" Inherits="Ecommerce.DatosClienteCargados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <h2>Tus datos</h2>
       
    <div class="row g-3">
        <div class="col-md-6">
            <div class="col">

                <label for="Nombres" class="form-label">Nombre/s:</label>
                <asp:TextBox runat="server" ID="Nombre" placeholder="Ejemplo: Juan Jose" CssClass="form-control" />
                <br />
                <label for="DNI" class="form-label">D.N.I:</label>
                <asp:TextBox runat="server" ID="DNI" placeholder="Ejemplo:11.111.111" CssClass="form-control" />
                <br />
                <label for="Telefono1" class="form-label">Telefono 1:</label>
                <asp:TextBox runat="server" ID="Telefono1" CssClass="form-control" placeholder="Ejemplo:03327-482882" />
                <br />
                <label for="FechaNac" class="form-label">Fecha de Nacimiento:</label>
                <asp:TextBox runat="server" ID="FechaNac" CssClass="form-control" placeholder="Ejemplo:10/12/1988" TextMode="Datetime" />
                <br />
                <label for="Calle" class="form-label">Calle:</label>
                <asp:TextBox runat="server" ID="Calle" CssClass="form-control" placeholder="Ejemplo:Belgrano" />
                <br />
                <label for="EntreCalles" class="form-label">Entre Calles:</label>
                <asp:TextBox runat="server" ID="EntreCalles" CssClass="form-control" placeholder="Ejemplo:Alvear y Francia" />
                <br />
                <label for="Provincia" class="form-label">Provincia:</label>
                <asp:TextBox ID="Provincia" runat="server" CssClass="form-control" placeholder="Ejemplo:Bs.As." />
                <br />
                <label for="Localidad" class="form-label">Localidad:</label>
                <asp:TextBox ID="Localidad" runat="server" CssClass="form-control" placeholder="Ejemplo:Garin" />
                <br />
                <label for="NroDepto" class="form-label">Numero de Departamento:</label>
                <asp:TextBox runat="server" ID="NroDepto" CssClass="form-control" placeholder="Ejemplo:2" />
                <br />
                <label for="Obs" class="form-label">Observaciones:</label>
                <asp:TextBox runat="server" ID="Obs" CssClass="form-control" placeholder="Ejemplo:Casa color rojo y porton negro." />
            </div>
        </div>

        <div class="col-md-6">
            <div class="col">
                <label for="Apellidos" class="form-label">Apellido/s:</label>
                <asp:TextBox runat="server" ID="Apellido" placeholder="Ejemplo:Perez" CssClass="form-control" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <label for="Telefono2" class="form-label">Telefono 2:</label>
                <asp:TextBox runat="server" ID="Telefono2" CssClass="form-control" placeholder="Ejemplo:11-5024-7277" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <label for="Numero" class="form-label">Numero:</label>
                <asp:TextBox runat="server" ID="Numero" CssClass="form-control" placeholder="Ejemplo:Numero" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <label for="Partido" class="form-label">Partido:</label>
                <asp:TextBox ID="Partido" runat="server" CssClass="form-control" placeholder="Ejemplo:Escobar" />
                <br />
                <label for="CodigoPostal" class="form-label">Codigo Postal:</label>
                <asp:TextBox runat="server" ID="CodigoPostal" CssClass="form-control" placeholder="Ejemplo:1652" />
                <br />
                <label for="Piso" class="form-label">Piso:</label>
                <asp:TextBox runat="server" ID="Piso" CssClass="form-control" placeholder="Ejemplo:Piso" />
            </div>
        </div>
    </div>
    <br />
    <div class="col-12">
        <asp:Button Text="Agregar o Modificar" ID="BtnAddModif" class="btn btn-primary" OnClick="AddModif" runat="server" />
        <%if (validador != 1) { %>
            <label  class="form-label">ingresar todos los datos clave correctamente:</label>
            <%} %>

        <% else if (validador==1)
            {%>



        <asp:Button Text="Hacer Pedido" ID="btneteHacerPedido" class="btn btn-primary" OnClick="btneteHacerPedido_Click" runat="server" />
           <% } %>
    </div>




</asp:Content>
