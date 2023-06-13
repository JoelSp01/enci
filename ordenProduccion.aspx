<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ordenProduccion.aspx.cs" Inherits="parqueo.WebForm5" %>

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
    <form id="formFactura" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesion_Click" />
            </div>
            <h2 class="text-center">
                <asp:Label ID="lblIdProducto" runat="server" Visible="False"></asp:Label>
                Orden de Producción</h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="ordenProduccion.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="reporte.aspx">Reporte</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="kardex.aspx">Kardex</a></li>

            </ul>
        </nav>
        <section>
            <asp:Panel ID="Panel1" runat="server" Style="width: 100%; float: left">
                <div style="margin: 3%; display: inline-block; width: 30%;">
                    <asp:Label ID="lblNumPedido" Style="display: inline-block; text-align: center" runat="server" Text="Label">Pedido N°: </asp:Label>
                    <asp:TextBox ID="txtNumPedido" Style="display: inline-block; text-align: center; width: 20%;" class="form-control" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" Style="display: inline-block; text-align: center; width: 30%;" class="form-control btn btn-secondary border rounded-pill" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    <br />
                    <asp:Label ID="lblErrorIdPedido" runat="server" ForeColor="Red" Text="Ingrese un número de Pedido Existente" Visible="False"></asp:Label>
                </div>
            </asp:Panel>
        </section>
        <section>
            <asp:Panel ID="panelOrden" Style="width: 20%; margin-left: 3%; float: left" runat="server" Visible="true">
                <div style="width: 100%; float: left;">
                    <label>Cliente</label>
                    <asp:TextBox ID="txtCliente" class="form-control" runat="server" Style="width: 100%" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="seleccionarCliente"></asp:TextBox>
                </div>

                <div style="width: 100%; float: left;">
                    <label>Cedula</label>
                    <asp:TextBox ID="txtCedula" class="form-control" runat="server" Style="width: 100%" Enabled="false"></asp:TextBox>
                </div>

                <div style="width: 45%; float: left">
                    <label>Fecha Inicio</label>
                    <asp:TextBox ID="txtFechaI" class="form-control" Style="padding-inline: 8%; width: 100%" type="date" runat="server" Enabled="false"></asp:TextBox>
                </div>

                <div style="margin-left: 10%; width: 45%; float: left">
                    <label>Fecha Fin</label>
                    <asp:TextBox ID="txtFechaF" class="form-control" Style="padding-inline: 8%; width: 100%" type="date" runat="server" Enabled="false" Width="98px"></asp:TextBox>
                </div>

                <%--<div style="width: 100%; float: left;">
                        <label>Producto</label>
                        <asp:TextBox ID="txtNombreProducto" class="form-control" Style="padding-inline: 8%; width:100%" runat="server" Enabled="false"></asp:TextBox>

                    </div>

                    <div style="width: 100%; float: left;">
                        <label>Cantidad</label>
                        <asp:TextBox ID="txtCantidadProducto" class="form-control" Style="padding-inline: 8%; width:100%" runat="server" Enabled="false"></asp:TextBox>

                    </div>--%>

                <div style="width: 100%; float: left;">
                    <label>PVP Produto</label>
                    <asp:TextBox ID="txtPvpProducto" class="form-control" runat="server" Style="width: 100%" Enabled="false"></asp:TextBox>
                    <br /><br /> 
                    <asp:Label ID="lblEspecificaion" runat="server" Text="Especificaciones" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtEspecificaion" Style="width: 100%" class="form-control" runat="server" Visible="False" OnTextChanged="txtEspecificaion_TextChanged"></asp:TextBox>
                    <br /> 
                    <asp:Label ID="lblErrorEspecificacion" runat="server" ForeColor="Red" Text="Complete el campo" Visible="False"></asp:Label>
                    <br />
                     <asp:Button ID="btnGenerarDocumento" Style="display: inline-block; margin-left:5% ; text-align: center; width: 90%;" class="form-control btn btn-secondary border rounded-pill" runat="server" Text="Generar Documento" Visible="False" OnClick="btnGenerarDocumento_Click"/>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" Style="overflow-y: scroll; height: 250px; width: 45%; margin-left: 35%;" runat="server">
                <asp:GridView ID="grdProductoPedido" style="width:100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False" OnSelectedIndexChanging="grdProductoPedido_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id Producto">

                            <ItemTemplate>
                                <asp:Label ID="lblIdProducto" runat="server" Text='<%# Bind("pro_id") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:BoundField DataField="pro_nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="pro_cantidad" HeaderText="Cantidad" />
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
        <asp:Panel ID="Panel3" style="overflow: scroll; height: 250px; width: 60%; margin-left:30%; margin-top:2%" runat="server">

            <asp:GridView ID="grdMat" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Id Material">

                        <ItemTemplate>
                            <asp:Label ID="lblIdMat" runat="server" Text='<%# Bind("mat_id") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:BoundField DataField="mat_detalle" HeaderText="Detalle" />
                    <asp:BoundField DataField="codigoclaMO" HeaderText="Mano de Obra">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigoclaMP" HeaderText="Materia Prima">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigoclaCIF" HeaderText="Costo Indirecto Fabricacion">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigoclaGA" HeaderText="Gastos Adminisrtativos">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigoclaGV" HeaderText="Gastos de Ventas">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigoclaGF" HeaderText="Gastos Financieros">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="mat_cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="mat_costoU" HeaderText="Costo Unitario" />
                    <asp:BoundField DataField="mat_total" HeaderText="Total" />
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
    </form>
</body>
</html>
