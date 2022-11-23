<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DatosCliente.aspx.cs" Inherits="Ecommerce.DatosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingresar los siguientes datos:</h2>

    <div class="row g-3">
        <div class="col-md-6">
            <div class="col">
                <label for="Nombres" class="form-label">Nombre/s:</label>
                <asp:TextBox runat="server" ID="Nombre" placeholder="Juan Jose" CssClass="form-control" />
                <br />
                <label for="DNI" class="form-label">D.N.I:</label>
                <asp:TextBox runat="server" ID="DNI" placeholder="11.111.111" CssClass="form-control" />
                <br />
                <label for="Telefono1" class="form-label">Telefono1:</label>
                <asp:TextBox runat="server" ID="Telefono1" CssClass="form-control" placeholder="03327-482882" />
                <br />
                <label for="FechaNac" class="form-label">Fecha de Nacimiento:</label>
                <asp:TextBox runat="server" ID="FechaNac" CssClass="form-control" placeholder="10/12/1988" TextMode="Date" />
            </div>
        </div>

        <div class="col-md-6">
            <div class="col">
                <label for="Apellidos" class="form-label">Apellido/s:</label>
                <asp:TextBox runat="server" ID="Apellido" placeholder="Perez" CssClass="form-control" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <label for="Telefono2" class="form-label">Telefono2:</label>
                <asp:TextBox runat="server" ID="Telefono2" CssClass="form-control" placeholder="11-5024-7277" />
            </div>
        </div>
    </div>


   
    <div class="col-md-4">
        <label for="inputState" class="form-label">State</label>
        <select id="inputState" class="form-select">
            <option selected>Choose...</option>
            <option>...</option>
        </select>
    </div>
    <div class="col-md-2">
        <label for="inputZip" class="form-label">Zip</label>
        <input type="text" class="form-control" id="inputZip">
    </div>
    <div class="col-12">
        <div class="form-check">
            <input class="form-check-input" type="checkbox" id="gridCheck">
            <label class="form-check-label" for="gridCheck">
                Check me out
            </label>
        </div>
    </div>
    <div class="col-12">
        <button type="submit" class="btn btn-primary">Sign in</button>
    </div>

</asp:Content>
