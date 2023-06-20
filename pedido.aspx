<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="parqueo.WebForm3" %>

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
    <form id="formPedido" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesion_Click" />
            </div>
            <h2 class="text-center">
                <asp:Label ID="lblIdCLiente" runat="server" Enabled="False" Visible="False"></asp:Label>
                Orden de Pedido<asp:Label ID="lblIdPedidoAc" runat="server" Enabled="False" Visible="False"></asp:Label>
            </h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="ordenProduccion.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="reporte.aspx">Reporte</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="kardex.aspx">Kardex</a></li>

            </ul>
        </nav>
        <div class="m-3">
            <div style="display:inline-block">
                <asp:Button ID="addNuevo" class="btn btn-dark" runat="server" Text="Nuevo" OnClick="addNuevo_Click" />
            </div>
            <div style="float:right; display:inline-block; margin-right:45%">
                <asp:Label ID="lblTitulo" runat="server" Text="Orden de Pedido:" Visible="False"></asp:Label>
                <asp:Label ID="lblIdPedido" runat="server"></asp:Label>
                <asp:Label ID="lblIdUsuario" runat="server"></asp:Label>
                <asp:Label ID="lblIdProducto" runat="server" Visible="False"></asp:Label>
            </div>
        </div>

        <article>


            <section>
                <asp:Panel ID="panelPedido" Style="width: 20%; float: left;" runat="server" Visible="false">
                    <div style="margin-left: 5%; width: 100%; float: left;">
                        <label>Cliente</label>
                        <asp:DropDownList ID="listCliente" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="seleccionarCliente"></asp:DropDownList>
                        <asp:Label runat="server" Style="color: red" Visible="false" ID="lblErrorCliente"><small>Campo necesario</small></asp:Label>

                    </div>

                    <div style="margin-left: 5%; width: 100%; float: left;">

                        <label>Cedula</label>
                        <asp:TextBox ID="txtCedula" class="form-control" runat="server" Style="width: 100%" Enabled="false"></asp:TextBox>
                    </div>

                    <div style="margin-left: 5%; width: 45%; float: left">
                        <label>Fecha Inicio</label>
                        <asp:TextBox ID="txtFechaI" class="form-control" Style="padding-inline: 8%;" type="date" runat="server"></asp:TextBox>
                        <asp:Label ID="lblErrorFechaInicio" runat="server" Style="color: red" Visible="false"><small>Campo necesario</small></asp:Label>
                        <asp:Label ID="lblCompararFechaInicio" runat="server" Style="color: red" Visible="false"><small>inserte Intervalo de Fechas Validas</small></asp:Label>
                    </div>

                    <div style="margin-left: 5%; width: 45%; float: left">
                        <label>Fecha Fin</label>
                        <asp:TextBox ID="txtFechaF" class="form-control" Style="padding-inline: 8%;" type="date" runat="server"></asp:TextBox>
                        <asp:Label runat="server" Style="color: red" Visible="false" ID="lblErrorFechaFin"><small>Campo necesario</small></asp:Label>
                        <asp:Label ID="lblCompararFechaFin" runat="server" Style="color: red" Visible="false"><small>Campo necesario</small></asp:Label>
                    </div>
                    <br />
                    <asp:Button ID="btnProducto" Style="margin-left: 5%; width: 95%" runat="server" Text="Producto" class="form-control btn btn-secondary border rounded-pill" OnClick="btnProducto_Click" />
         
                </asp:Panel>
                <asp:Panel ID="Panel1" Style="overflow-y: scroll; height: 220px; width: 65%; margin-left: 25%;" runat="server">
                    <asp:GridView ID="grdOrdenes" style="width:100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdOrdenes_SelectedIndexChanged" OnSelectedIndexChanging="grdOrdenes_SelectedIndexChanging" DataKeyNames="orp_id" OnRowDeleting="grdOrdenes_RowDeleting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id">

                                <ItemTemplate>
                                    <asp:Label ID="lblOrdenId" runat="server" Text='<%# Bind("orp_id") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:BoundField DataField="cli_id" HeaderText="Id Cliente" Visible="False" />
                            <asp:BoundField DataField="cli_nombre" HeaderText="Cliente" />
                            <asp:BoundField DataField="cli_ruc" HeaderText="Cedula" />
                            <asp:BoundField DataField="orp_fechaIngreso" HeaderText="Fecha Ingreso" />
                            <asp:BoundField DataField="orp_fechaFinal" HeaderText="Fecha Final" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
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

            <section>
                <asp:Panel ID="pnlProducto" Style="width: 20%; display: inline-block; position:absolute " runat="server"  Visible="false"> 
                    <div style="margin-left: 5%; width: 100%; float: left;">
                        <label>Producto</label>
                        <asp:TextBox ID="txtNombreProducto" class="form-control" runat="server"></asp:TextBox>
                        <asp:Label runat="server" Style="color: red" Visible="false" ID="lblErrorProducto"><small>Campo necesario</small></asp:Label>

                    </div>

                    <div style="margin-left: 5%; width: 100%; float: left;">
                        <label>Cantidad</label>
                        <asp:TextBox ID="txtCantidadProducto" class="form-control" runat="server"></asp:TextBox>
                        <asp:Label runat="server" Style="color: red" Visible="false" ID="lblErrorCantidadProducto"><small>Campo necesario</small></asp:Label>

                    </div>

                    <div style="margin-left: 5%; width: 100%; float: left;">
                        <label>PVP</label>
                        <asp:TextBox ID="txtPvpProducto" class="form-control" runat="server"></asp:TextBox>
                        <asp:Label runat="server" Style="color: red" Visible="false" ID="lblErrorPvp"><small>Campo necesario</small></asp:Label>
                    </div>
                    <asp:Button ID="btnAgregarPro" Style="margin-left: 5%; margin-top: 3%" runat="server" Text="+ Añadir" class="form-control btn btn-secondary border rounded-pill" OnClick="btnAgregarPro_Click" />

                </asp:Panel>
                <asp:Panel ID="Panel2" Style="overflow-y: scroll; height: 200px; width: 45%; margin-left: 25%; margin-top: 3%;" runat="server">
                    <asp:GridView ID="grdProductos" style="width:100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdProductos_SelectedIndexChanged" OnSelectedIndexChanging="grdProductos_SelectedIndexChanging" DataKeyNames="pro_id" OnRowDeleting="grdProductos_RowDeleting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id">

                                <ItemTemplate>
                                    <asp:Label ID="lblMaterialId" runat="server" Text='<%# Bind("pro_id") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:BoundField DataField="pro_nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="pro_cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="pro_pvp" HeaderText="Pvp" />
                            <asp:BoundField DataField="pro_estado" HeaderText="Estado" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
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
            <section style="margin-top: 5%">
                <asp:Panel ID="PanelMaterial" Style="width: 20%; display: inline-block; float: left;" Visible="false" runat="server">
                    <div style="margin-left: 5%; display: inline-block; width: 40%; float: left; height: 294px;">
                        <label>Material</label>
                        <asp:DropDownList ID="listMaterial" class="form-control" runat="server" OnSelectedIndexChanged="listMaterial_SelectedIndexChanged"></asp:DropDownList>
                        <asp:Label runat="server" Style="color: red" Visible="false" ID="lblErrorMaterial"><small>Campo necesario</small></asp:Label>
                        <label>Cantidad</label>
                        <asp:TextBox ID="cantMaterial" class="form-control" runat="server"></asp:TextBox><br />
                        <asp:Label runat="server" Style="color: red" Visible="false" ID="lblErrorCantMaterial"><small>Campo necesario</small></asp:Label>
                        <asp:Button ID="btnAgMat" runat="server" class="form-control btn btn-secondary border rounded-pill" Text="Añadir" OnClick="btnAgMat_Click" />
                    </div>

                </asp:Panel>
                <asp:Panel ID="PanelGridMaterial" Style="overflow-y: scroll; height: 200px; width: 35%; margin-left: 25%; margin-top: 5%;" runat="server">
                    <asp:GridView ID="grdMaterial" style="width:100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="OPM_ID" OnRowDeleting="grdMaterial_RowDeleting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id">

                                <ItemTemplate>
                                    <asp:Label ID="lblMaterialId" runat="server" Text='<%# Bind("opm_id") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:BoundField DataField="pro_nombre" HeaderText="Producto" />
                            <asp:BoundField DataField="mat_detalle" HeaderText="Detalle" />
                            <asp:BoundField DataField="opm_cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="mat_costoU" HeaderText="Costo Unitario" />
                            <asp:BoundField DataField="mat_costoT" HeaderText="Costo Total" />
                            <asp:BoundField DataField="mat_total" HeaderText="Total" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
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
        </article>

    </form>
</body>
</html>
