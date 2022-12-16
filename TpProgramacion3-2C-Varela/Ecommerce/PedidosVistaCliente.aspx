<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PedidosVistaCliente.aspx.cs" Inherits="Ecommerce.PedidosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="dgvDatosCompra" runat="server" DataKeyNames="NROCOMPROBANTE" CssClass="table" class="card-text" AutoGenerateColumns="false"
         AllowPaging="false" PageSize="5" OnSelectedIndexChanged="dgvDatosCompra_SelectedIndexChanged" OnSelectedIndexChanging="dgvDatosCompra_SelectedIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Nro. de Pedido" DataField="NROCOMPROBANTE" />
            <asp:BoundField HeaderText="Fecha de Compra" DataField="FECHAALTA" />
            <asp:BoundField HeaderText="Hora de Compra" DataField="HORAALTA" />
            <asp:CheckBoxField HeaderText="Solicito Factura" DataField="FACTURA.PIDE" />
            <asp:BoundField HeaderText="Forma de Envio" DataField="FORMADEENVIO" />
            <asp:BoundField HeaderText="Forma de Pago" DataField="FORMADEPAGO" />
            <asp:BoundField HeaderText="Total a Pagar" DataField="TOTAL" />
            <asp:BoundField HeaderText="Estado" DataField="ESTADO" />
            <asp:CommandField HeaderText="Ver Detalle de Articulos"  ShowSelectButton="true" SelectText="📑" />
            
        </Columns>

    </asp:GridView>
    

</asp:Content>
