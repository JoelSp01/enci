<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="parqueo.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link rel="stylesheet" href="estilos.css" />
</head>
<body class="fondo">
    <form id="formReporte" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" />
            </div>
            <h2 class="text-center">Reportes</h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="ordenProduccion.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="reporte.aspx">Reporte</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="kardex.aspx">Kardex</a></li>

            </ul>
        </nav>
        <section class="m-3">
            <asp:Panel ID="PanelReporte" class="border p-2 rounded-3" Style="width: 100%;" runat="server">
                <div style="margin-top: 1%; margin-left: 40%; display: inline-block; width: 20%;">
                    <asp:Button ID="btnExportar" Style="width: 90%;" class="form-control btn btn-secondary border rounded-pill" Visible="false" runat="server" OnClick="btnExportar_Click" Text="Exportar EXCEL" />
                    <div style="margin-top:5% ;width: 45%; display: inline-block">
                        <label>Fecha Desde</label>
                        <asp:TextBox type="date" ID="txtFechaDesde" Style="width: 100%;" class="form-control" runat="server"></asp:TextBox><br />
                    </div>

                    <div style="width: 45%; display: inline-block">
                        <label>Fecha Hasta</label>
                        <asp:TextBox type="date" ID="txtFechaHasta" Style="width: 100%;" class="form-control" runat="server"></asp:TextBox><br />
                    </div>
                    <asp:Button ID="btnReport" Style="width: 90%;" runat="server" Text="Mostrar" class="form-control btn btn-secondary border rounded-pill" OnClick="btnReport_Click" />
                </div>
            </asp:Panel>
        </section>
            <asp:GridView ID="grdReporte" style="margin-left:35%; margin-top:5%; width:30%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="itc_nombre" HeaderText="Descripción" />
                    <asp:BoundField DataField="total" HeaderText="Total" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
    </form>
</body>
</html>
