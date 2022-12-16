<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="parqueo.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body class="bg bg-image" style="background-image: url('images/blanco.jpg');">
    <form id="formPedido" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesion_Click"  />
            </div>
            <h2 class="text-center">Orden de Pedido</h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Materiales.aspx">Material</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="factura.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="">Reporte de Gastos</a></li>
                
            </ul>
        </nav>
        <section>
            <div class="m-3">
                <asp:Button ID="addNuevo" class="btn btn-dark" runat="server" Text="Nuevo" />
            </div>
            <asp:Panel ID="panelPedido" style="width: 33%;" runat="server">
                <div class="w-28 m-3" style=" display: inline-block; float: left;">
                    <h5>Cliente</h5>
                    <asp:DropDownList ID="lstCliente" class="form-control" runat="server"></asp:DropDownList><br />
                    <h5>Cedula</h5>
                    <asp:TextBox ID="txtCedula" class="form-control" runat="server" Enabled="false"></asp:TextBox><br /><br />
                    <h5>Cantidad</h5>
                    <asp:TextBox ID="txtCantidadPedido" class="form-control" runat="server"></asp:TextBox><br />
                    <h5>Producto</h5>
                    <asp:TextBox ID="txtProducto" class="form-control" runat="server"></asp:TextBox><br />
                </div>
                <div class="w-40 m-3" style=" display: inline-block; float: right;">
                    <h5>PVP</h5>
                    <asp:TextBox ID="txtPvp" class="form-control" runat="server"></asp:TextBox><br />
                    <h5>Fecha Inicio</h5>
                    <asp:TextBox ID="txtFechaI" class="form-control" style="padding-inline: 8%;" type="date" runat="server"></asp:TextBox><br />
                    <h5>Fecha Fin</h5>
                    <asp:TextBox ID="txtFechaF" class="form-control" style="padding-inline: 8%;" type="date" runat="server"></asp:TextBox><br />
                </div>
            </asp:Panel>
        </section>
    </form>
</body>
</html>
