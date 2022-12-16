<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="DetalleDomicilioAdmin.aspx.cs" Inherits="Ecommerce.DetalleDomicilioAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
    <h1>Detalle del Domicilio del Cliente</h1>

    
    <asp:GridView ID="dgvDatosDetalleDomicilioAdmin" runat="server" DataKeyNames="IDDOMICILIO" CssClass="table" 
        class="card-text" AutoGenerateColumns="false" AllowPaging="false" PageSize="5"
        >
        <Columns>
            <asp:BoundField HeaderText="Provincia" DataField="PROVINCIA" />
            <asp:BoundField HeaderText="Partido" DataField="PARTIDO" />
            <asp:BoundField HeaderText="Localidad" DataField="LOCALIDAD" />
            <asp:BoundField HeaderText="Codigo Postal" DataField="CODIGO_POSTAL" />
            <asp:BoundField HeaderText="Calle" DataField="CALLE"/>
            <asp:BoundField HeaderText="Numero de Calle" DataField="NUMERO"/>
            <asp:BoundField HeaderText="Entre Calles" DataField="ENTRECALLES"/>
            <asp:BoundField HeaderText="Numero de departamento" DataField="NUMERO_DEPTO"/>
            <asp:BoundField HeaderText="Piso" DataField="PISO"/>

        </Columns>

    </asp:GridView>
    <asp:Button Text="Volver al menu anterior" ID="IraMisPedidos" class="btn btn-primary" OnClick="IraMisPedidos_Click" runat="server" />


</asp:Content>
