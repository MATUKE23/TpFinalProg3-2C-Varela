<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Log In.aspx.cs" Inherits="Ecommerce.Log_In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class=" row justify-content-center">
            <div class="card">
                <div class="card-Header text-center">
                    <h3>Log in</h3>
                </div>
                <div class="card-body">
                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                        </div>
                        <asp:TextBox ID="TextBoxLogIn" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-key"></i></span>
                        </div>
                     
                        <asp:TextBox ID="TextBoxLogInPassword" placeholder="*****"  runat="server" CssClass="form-control"></asp:TextBox>
                    </div> 
                    <div class="form-group row justify-content-center">
                        <asp:Button ID="btnIniciarSesion" CssClass="btn btn-primary" runat="server" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
