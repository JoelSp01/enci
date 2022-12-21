<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCliProv.aspx.cs" Inherits="parqueo.WebForm6" %>

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
    <form id="formCliente" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesion_Click" />
            </div>
            <h2 class="text-center">Registrar Cliente/Proveedor</h2>
        </header>
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="factura.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="reporte.aspx">Reporte de Gastos</a></li>
            </ul>
        </nav>
        <section>
            <div class="text-center">
                <asp:Button ID="cliente" runat="server" class="btn btn-dark rounded-3" Text="Cliente" OnClick="cliente_Click" />
                <asp:Button ID="proveedor" runat="server" class="btn btn-dark rounded-3" Text="Proveedor" OnClick="proveedor_Click" />
            </div>
            <asp:Panel ID="panelCliente" Visible="false" style="width:20%; display:inline-block; float:left; margin-left: 2%;" runat="server">
                <div class="border p-2 rounded-3">
                    <h5><b>Registrar Cliente</b><asp:Label ID="lblIdCliente" runat="server" Visible="False"></asp:Label>
                    </h5>
                    <div>
                        <b><label class="form-label">Nombre</label></b>
                        <asp:TextBox ID="txtCliNombre" runat="server" class="form-control" placeholder="Escriba su nombre"></asp:TextBox>
                        <asp:Label ID="lblErrorNombre" runat="server" Font-Bold="True" ForeColor="Red" Text="Ingrese el nombre" Visible="False"></asp:Label>
                        <br />

                        <b><label class="form-label">C.I</label></b>
                        <asp:TextBox ID="txtCliCedula" runat="server" class="form-control" placeholder="Documento de Identidad"></asp:TextBox>
                        <asp:Label ID="lblErrorRuc" runat="server" Font-Bold="True" ForeColor="Red" Text="Ingrese la cédula o ruc" Visible="False"></asp:Label>
                        <br />

                        <b><label class="form-label">Telefono</label></b>
                        <asp:TextBox ID="txtCliTelefono" runat="server" class="form-control" placeholder="Telefono"></asp:TextBox>
                        <asp:Label ID="lblErorTelefono" runat="server" Font-Bold="True" ForeColor="Red" Text="Ingrese el teléfono" Visible="False"></asp:Label>
                        <br />

                        <b><label class="form-label">Correo Electronico</label></b>
                        <asp:TextBox ID="txtCliCorreo" runat="server" class="form-control" placeholder="e-mail"></asp:TextBox>
                        <asp:Label ID="lblErrorCorreo" runat="server" Font-Bold="True" ForeColor="Red" Text="Ingrese el correo Electrónico" Visible="False"></asp:Label>
                        <br />

                        <asp:Button ID="btnRegistrarCliente" runat="server" Text="Registrar" class="form-control btn btn-secondary border rounded-pill" OnClick="btnRegistrarCliente_Click" /><br />

                    </div>
                </div>

            </asp:Panel>
            <asp:Panel ID="pnlClientes" Visible="false" style="width:63%; display:inline-block; float:left; margin-top:2%; margin-left:4%; overflow-y: scroll; height: 400px;" runat="server">
                <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="grdClientes_SelectedIndexChanging" OnRowDeleting="grdClientes_RowDeleting" DataKeyNames="CLI_ID" CellPadding="4" ForeColor="#333333" GridLines="None" Width="902px" PageSize="5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblClienteId" runat="server" Text='<%# Bind("cli_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="cli_nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="cli_ruc" HeaderText="Ruc/Identificación" />
                        <asp:BoundField DataField="cli_telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="cli_correoelectronico" HeaderText="Correo electrónico" />
                        <asp:BoundField DataField="cli_estado" HeaderText="Estado" />
                        <asp:CommandField ButtonType="Button" ShowSelectButton="true">
                            <HeaderStyle Width="100%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        No existen Registros
                    </EmptyDataTemplate>
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
            <asp:Panel ID="panelProveedor" Visible="false" style="width:20%; display:inline-block; float:left; margin-left: 2%;" runat="server">
                <div class="border p-2 rounded-3">

                    <h5><b>Registrar Proveedor</b><asp:Label ID="lblIdProveedor" runat="server" Visible="False"></asp:Label>
                    </h5>
                    <div>
                        <b>
                            <label class="form-label">Nombre</label></b>
                        <asp:TextBox ID="txtProvNombre" runat="server" class="form-control" placeholder="Escriba su nombre"></asp:TextBox>
                        <asp:Label ID="lblErrorNombreProv" runat="server" Font-Bold="True" ForeColor="Red" Text="Ingrese el nombre" Visible="False"></asp:Label>
                        <br />



                        <b>
                            <label class="form-label">C.I</label></b>
                        <asp:TextBox ID="txtProvRuc" runat="server" class="form-control" placeholder="Documento de Identidad"></asp:TextBox>
                        <asp:Label ID="lblErrorRucProv" runat="server" Font-Bold="True" ForeColor="Red" Text="Ingrese la ruc" Visible="False"></asp:Label>
                        <br />



                        <b>
                            <label class="form-label">Razón Social</label></b>
                        <asp:TextBox ID="txtProvRazonSocial" runat="server" class="form-control" placeholder="Razon Social"></asp:TextBox>
                        <asp:Label ID="lblErrorRazonSocial" runat="server" Font-Bold="True" ForeColor="Red" Text="Ingrese la razón social" Visible="False"></asp:Label>
                        <br />
                        <asp:Button ID="btnRegProveedor" runat="server" Text="Registrar" class="form-control btn btn-secondary border rounded-pill" OnClick="btnRegProveedor_Click" /><br />

                    </div>
                    <br />
                    <br />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlProveedor" Visible="false" style="width:50%; display:inline-block; float:left; margin-top:2%; margin-left:4%; overflow-y: scroll; height: 400px;" runat="server">
            <asp:GridView ID="grdProveedor" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="PROV_ID" ForeColor="#333333" GridLines="None" OnRowDeleting="grdProveedor_RowDeleting" OnSelectedIndexChanging="grdProveedor_SelectedIndexChanging" PageSize="5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>
                            <asp:Label ID="lblProveedorId" runat="server" Text='<%# Bind("prov_id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="prov_nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="prov_ruc" HeaderText="Ruc/Identificación" />
                    <asp:BoundField DataField="prov_razonSocial" HeaderText="Razón Social" />
                    <asp:BoundField DataField="prov_estado" HeaderText="Estado" />
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
        <%--<p>
            &nbsp;
        </p>--%>
    </form>
    <%--<p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>--%>
</body>
</html>
