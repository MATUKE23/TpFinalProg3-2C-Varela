<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PedidosVistaAdmin.aspx.cs" Inherits="Ecommerce.Administrar_Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvDetalleVentas" runat="server" DataKeyNames="NROCOMPROBANTE" CssClass="table" class="card-text" 
         AllowPaging="false" PageSize="5"  AutoGenerateColumns="false" >
        <Columns>
    <asp:BoundField HeaderText="Nro de Comprobante" DataField="NROCOMPROBANTE" />
            <asp:BoundField HeaderText="Fecha de Venta" DataField="FECHAALTA" />
            <asp:BoundField HeaderText="Hora de Venta" DataField="HORAALTA" />
            <asp:CheckBoxField HeaderText="Solicito Factura" DataField="FACTURA.PIDE" />
            <asp:BoundField HeaderText="Forma de Envio" DataField="FORMADEENVIO" />
            <asp:BoundField HeaderText="Forma de Pago" DataField="FORMADEPAGO" />
            <asp:BoundField HeaderText="Total a Cobrar" DataField="TOTAL" />
            <asp:BoundField HeaderText="Estado" DataField="ESTADO" />
        </Columns>
    </asp:GridView>
</asp:Content>
