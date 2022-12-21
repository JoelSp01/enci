<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="parqueo.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body class="bg bg-image" style="background-image: url('images/blanco.jpg');">
    <form id="formReporte" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" />
            </div>
            <h2 class="text-center">Orden de Producción</h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="factura.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="reporte.aspx">Reporte</a></li>
                
            </ul>
        </nav>
        <section class="m-3">
            <asp:Panel ID="PanelReporte" class="border p-2 rounded-3" style="width:30%; display:inline-block; float:left; margin-left: 2%;" runat="server">
                <div style="margin-left: 5%; display: inline-block; width: 100%; float: left;">
                    <label>Fecha Desde</label>
                    <asp:TextBox type="date" ID="fechaDesde" style="width:100%;" class="form-control" runat="server"></asp:TextBox><br />
                    <label>Fecha Hasta</label>
                    <asp:TextBox type="date" ID="fechaHasta" style="width:100%;" class="form-control" runat="server"></asp:TextBox><br /><br />
                    <asp:Button ID="btnReport" runat="server" Text="Mostrar" class="form-control btn btn-secondary border rounded-pill" />
                </div>
            </asp:Panel>
        </section>
    </form>
</body>
</html>
