<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sign in Basic.aspx.cs" Inherits="Ecommerce.Sign_in_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class=" row justify-content-center">
            <div class="card">
                <div class="card-Header text-center">
                      <h3>Registrate</h3>
                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                            <asp:TextBox ID="TextBoxAgregaMail" runat="server" placeholder="Ingrese su E-mail aqui" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                            <asp:TextBox ID="TextBoxPass" runat="server" placeholder="Ingrese su contraseña" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Button ID="ButtonRegistrarse" runat="server" Text="Registrarse" OnClick="ButtonRegistrarse_Click" />


         </div>
            </div>
        </div>
    </div>
</asp:Content>
