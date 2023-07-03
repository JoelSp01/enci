<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kardex.aspx.cs" Inherits="parqueo.kardex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" />
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
                <li class="nav-item"><a class="nav-link text-dark" href="reporte.aspx">Reporte<asp:Label ID="lblIdProveedor" runat="server"></asp:Label>
                </a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="kardex.aspx">Kardex</a></li>

            </ul>
        </nav>
        <section class="container text-center mt-5">
            <div>
                <div style="width: 30%; display: inline-block">

                    <asp:Label ID="Label2" runat="server" Text="Proveedor"></asp:Label>
                    <asp:DropDownList ID="listProveedor" runat="server" AutoPostBack="True" Style="width: 100%;" class="form-control" OnSelectedIndexChanged="listProveedor_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div style="width: 30%; display: inline-block">

                    <asp:Label ID="Label3" runat="server" Text="Fecha desde"></asp:Label>
                    <asp:TextBox ID="TextBox3" Type="date" runat="server" Style="width: 100%;" class="form-control"></asp:TextBox>
                </div>
                <div style="width: 30%; display: inline-block">

                    <asp:Label ID="Label4" runat="server" Text="Fecha hasta"></asp:Label>
                    <asp:TextBox ID="TextBox4" Type="date" runat="server" Style="width: 100%;" class="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div>
                <label>ENTRADAS</label>
                <label>SALIDAS</label>
                <label>SALDOS</label>
            </div>
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="grdKardex" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">

                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="kdx_fechaC" HeaderText="Fecha Entrada" />
                        <asp:BoundField DataField="detalle" HeaderText="Detalle" />
                        <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
                        <asp:BoundField DataField="material" HeaderText="Material" />
                        <asp:BoundField DataField="cantidad_entrada" HeaderText="Cantidad" />
                        <asp:BoundField DataField="costo_unitario_e" HeaderText="Costo Unitario" />
                        <asp:BoundField DataField="costo_total_e" HeaderText="Costo Total" />
                        <asp:BoundField DataField="fecha_salida" HeaderText="Fecha Salida" />
                        <asp:BoundField DataField="cantidad_salida" HeaderText="Cantidad" />
                        <asp:BoundField DataField="costo_unitario_s" HeaderText="Costo Unitario" />
                        <asp:BoundField DataField="costo_total_s" HeaderText="Costo Total" />
                        <asp:BoundField DataField="cantidad_existente" HeaderText="Cantidad" />
                        <asp:BoundField DataField="costo_unitario_ex" HeaderText="Costo Unitario" />
                        <asp:BoundField DataField="costo_total_ex" HeaderText="Costo Total" />
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
            </asp:Panel>
        </section>
    </form>
</body>
</html>
