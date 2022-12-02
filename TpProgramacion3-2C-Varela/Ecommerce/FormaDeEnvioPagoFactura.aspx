<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormaDeEnvioPagoFactura.aspx.cs" Inherits="Ecommerce.FormaDeEnvio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Determinar forma de envio:</h4>
    <div class="row g-3">
        <div class="col-md-6">
            <div class="col">

                <asp:DropDownList runat="server" ID="ddlFormadeEnvio" CssClass="form-control">
                    <asp:ListItem Text="Retiro en el domicilio del vendedor" />
                    <asp:ListItem Text="Envio al domicilio registrado" />
                    <asp:ListItem Text="A coordinar. (Se pone en contacto con el vendedor)." />
                </asp:DropDownList>

                <br />
                <asp:Label ID="SolicitaFactura" runat="server" Text="Label">Solicita factura?</asp:Label>

                <asp:Button Text="SI" ID="txtSI" CssClass="btn btn-primary" runat="server" OnClick="txtSI_Click" />
                <asp:Button Text="NO" ID="NO" CssClass="btn btn-primary" runat="server" />
                <br />
                <br />

                <asp:Label ID="lbCondFiscal" runat="server">Condicion Fiscal:</asp:Label>
                <asp:DropDownList ID="ddlCondFiscal" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Responsable Inscripto" />
                    <asp:ListItem Text="Monotributo" />
                    <asp:ListItem Text="Consumidor Final" />
                    <asp:ListItem Text="Exento" />
                </asp:DropDownList>


                <br />
                <asp:Label ID="lbCUIT" runat="server" Text="lbCondFiscal">Ingrese su numero de C.U.I.T.:</asp:Label>
                <asp:TextBox ID="txtCUIT" runat="server" CssClass="form-control" placeholder="23-11111111-9" OnTextChanged="txtCUIT_TextChanged" AutoPostBack="true" />
                <br />
                
                <asp:Label ID="lbFormaDePago" runat="server">Forma de pago:</asp:Label>
                <asp:DropDownList ID="ddlFormaDePago" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFormaDePago_SelectedIndexChanged" 
                    runat="server">
                    <asp:ListItem Text="Efectivo" />
                    <asp:ListItem Text="Transferencia Bancaria" />
                    <asp:ListItem Text="Deposito Bancaria" />
                    <asp:ListItem Text="Mercado Pago" />
                </asp:DropDownList>

                <br />
                <asp:Button ID="btnHacerPedido" Text="Realizar Pedido" CssClass="btn btn-primary" runat="server" />




            </div>
        </div>
    </div>
</asp:Content>
