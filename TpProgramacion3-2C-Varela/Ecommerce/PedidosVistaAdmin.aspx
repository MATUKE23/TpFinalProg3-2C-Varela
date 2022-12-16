<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PedidosVistaAdmin.aspx.cs" Inherits="Ecommerce.Administrar_Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvDetalleVentasAdmin" runat="server" DataKeyNames="NROCOMPROBANTE" CssClass="table" class="card-text"
        OnSelectedIndexChanged="dgvDetalleVentas_SelectedIndexChanged" OnSelectedIndexChanging="dgvDetalleVentas_SelectedIndexChanging"   
    AllowPaging="false" PageSize="5"  AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField HeaderText="Nro. de Pedido" DataField="NROCOMPROBANTE" />
            <asp:BoundField HeaderText="Nombre del Cliente" DataField="CLIENTE.NOMBRES"/>
            <asp:BoundField HeaderText="Apellido del Cliente" DataField="CLIENTE.APELLIDOS"/>
            <asp:BoundField HeaderText="Provincia" DataField="CLIENTE.DOMICILIO.PROVINCIA"/>
            <asp:BoundField HeaderText="Partido" DataField="CLIENTE.DOMICILIO.PARTIDO"/>
            <asp:BoundField HeaderText="Forma de Envio" DataField="FORMADEENVIO" />
            <asp:CheckBoxField HeaderText="Solicito Factura" DataField="FACTURA.PIDE" />
            <asp:BoundField HeaderText="Forma de Pago" DataField="FORMADEPAGO" />
            <asp:BoundField HeaderText="Fecha de Venta" DataField="FECHAALTA" />
            <asp:BoundField HeaderText="Hora de Venta" DataField="HORAALTA" />
            <asp:BoundField HeaderText="Estado" DataField="ESTADO" />
            <asp:BoundField HeaderText="Total a Cobrar" DataField="TOTAL" />
            <asp:CommandField HeaderText="Ver Detalle de Articulos Vendidos"  ShowSelectButton="true" SelectText="📑" />
            <asp:CommandField HeaderText="Ver Detalle de Domicilio"  ShowSelectButton="true" SelectText="📑" />
        </Columns>
    </asp:GridView>
</asp:Content>
