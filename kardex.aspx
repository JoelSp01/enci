<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kardex.aspx.cs" Inherits="parqueo.kardex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link rel="stylesheet" href="estilos.css" />
</head>
<body class="fondo">
    <form id="form1" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion"/>
            </div>
            <h2 class="text-center">Bienvenidos</h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" aria-current="page" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="ordenProduccion.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="reporte.aspx">Reporte</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="kardex.aspx">Kardex</a></li>
               
            </ul>
        </nav>
        <section class="container text-center mt-5">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Producto"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Proveedor"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Fecha desde"></asp:Label>
                <asp:TextBox ID="TextBox3" Type="date" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Fecha hasta"></asp:Label>
                <asp:TextBox ID="TextBox4" Type="date" runat="server"></asp:TextBox>
            </div>
            <div>
                <img src="images/kardex-5.jpg" />
            </div>
        </section>
    </form>
</body>
</html>
