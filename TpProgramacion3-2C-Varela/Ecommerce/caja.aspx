<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="caja.aspx.cs" Inherits="Ecommerce.caja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <%if (carrito.Count != 0)
            {%>
        <div class="row">
            <div class="col-md-12">
                <div class="card mt-2">
                    <div class="card-header">
                        <h4>Carrito de compras</h4>
                        <table class="table table-striped">
                            <thead class="thead-dark text-center">
                                <tr>
                                    <th>Codigo</th>
                                    <th>Descripción</th>
                                    <th>Cantidad</th>
                                    <th>monto</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody class="text-center" style="white-space: nowrap">
                                <%int count = 0; foreach (var arti in carrito)
                                    { %>
                                <tr>
                                    <td><%=arti.CODIGO %></td>
                                    <td><%=arti.DESCRIPCION %></td>
                                    <td><%=arti.CANTIDAD %></td>
                                    <td><%=arti.PRECIO * arti.CANTIDAD %></td>
                                    <td>
                                        <a href="caja.aspx?contador=<%=count%>&accion=agregar" title="Agregar una cantidad" class="btn btn-dark"><i class="fa-solid fa-plus"></i></a>
                                        <a href="caja.aspx?contador=<%=count%>&accion=quitar" title="Quitar una cantidad" class="btn btn-dark"><i class="fa-solid fa-minus"></i></a>
                                        <a href="caja.aspx?contador=<%=count%>&accion=quitarTodo" title="Quitar todo" class="btn btn-dark"><i class="fa-solid fa-trash"></i></a>
                                    </td>
                                </tr>
                                <% count++;
                                    } %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="card text-right">
            <div class="card-header">
               <h5>TOTAL: $ <%=total %></h5>  
            </div>
            <div class="card-body">
                <asp:Button ID="Button1" runat="server" ToolTip="Ir a Pagar" Text="Pagar" CssClass="btn btn-success" OnClick="Pagar" />
                <asp:Button ID="Button2" runat="server" ToolTip="Vaciar carrito" Text="Vaciar" CssClass="btn btn-danger" OnClick="VaciarCarrito" />
            </div>
        </div>
        <div class="row justify-content-end mt-2">
            <div class="col-lg-1 mb-2">
                
            <div class="col-lg-1 mb-2">
                
        </div>
        <%}
            else
            { %>
        <h1 class="text-center mt-4">Aun no has añadido artículos al carrito</h1>
        <p class="text-center">Hacé clic <a href="Productos.aspx" class="text-dark">acá</a> para ver los productos.</p>
        <% } %>
    </div>
</asp:Content>
