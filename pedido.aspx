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
                <li class="nav-item"><a class="nav-link text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="factura.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="reporte.aspx">Reporte de Gastos</a></li>
                
            </ul>
        </nav>
        <section>
            <div class="m-3">
                <asp:Button ID="addNuevo" class="btn btn-dark" runat="server" Text="Nuevo" OnClick="addNuevo_Click" />
            </div>
            <asp:Panel ID="panelPedido" style="width: 30%; display: inline-block; float:left;" runat="server" Visible="false">
                <div style="margin-left: 5%; display: inline-block; width: 40%; float: left;">
                    <label>Cliente</label>
                    <asp:DropDownList ID="lstCliente" class="form-control" runat="server"></asp:DropDownList><br />
                    <label>Cedula</label>
                    <asp:TextBox ID="txtCedula" class="form-control" runat="server" style="width: 100%" Enabled="false"></asp:TextBox><br /><br />
                    <label>Cantidad</label>
                    <asp:TextBox ID="txtCantidadPedido" class="form-control" runat="server"></asp:TextBox><br />
                    <label>Producto</label>
                    <asp:TextBox ID="txtProducto" class="form-control" runat="server"></asp:TextBox><br />
                </div>
                <div style=" margin-left: 5%; display: inline-block; width:40%; float: left;">
                    <label>PVP</label>
                    <asp:TextBox ID="txtPvp" class="form-control" runat="server"></asp:TextBox><br />
                    <label>Fecha Inicio</label>
                    <asp:TextBox ID="txtFechaI" class="form-control" style="padding-inline: 8%;" type="date" runat="server"></asp:TextBox><br />
                    <label>Fecha Fin</label>
                    <asp:TextBox ID="txtFechaF" class="form-control" style="padding-inline: 8%;" type="date" runat="server"></asp:TextBox><br />
                </div>
                <div>
                    <asp:Button ID="btnAgregar" runat="server" Text="Confirmar" class="form-control btn btn-secondary border rounded-pill" OnClick="btnAgregar_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="PanelGridPedido" style="overflow-y: scroll; height: 200px; width: 65%" runat="server" Visible="false">
                <asp:GridView ID="GridPedido" runat="server"></asp:GridView>
            </asp:Panel>
        </section>
        <section>
            <asp:Panel ID="PanelMaterial" style="width: 30%; display: inline-block; float:left;" Visible="false" runat="server">
                <div style="margin-left: 5%; display: inline-block; width: 40%; float: left;">
                    <label>Material</label>
                    <asp:DropDownList ID="lstMaterial" class="form-control" runat="server"></asp:DropDownList><br />
                    <asp:Button ID="btnAgMat" runat="server" class="form-control btn btn-secondary border rounded-pill" Text="Añadir" />
                </div>
            </asp:Panel>
            <asp:Panel ID="PanelGridMaterial" runat="server">
                <asp:GridView ID="GridMaterial" runat="server"></asp:GridView>
            </asp:Panel>
        </section>
    </form>
</body>
</html>
