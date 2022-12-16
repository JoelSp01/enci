<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="factura.aspx.cs" Inherits="parqueo.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body class="bg bg-image" style="background-image: url('images/blanco.jpg');">
    <form id="formFactura" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesion_Click" />
            </div>
            <h2 class="text-center">Orden de Producción</h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="cliente.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Proveedor.aspx">Material</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="factura.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="">Reporte de Gastos</a></li>
                
            </ul>
        </nav>
        <section>
        </section>
    </form>
</body>
</html>
