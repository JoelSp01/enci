<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="impresion.aspx.cs" Inherits="parqueo.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />

</head>
<body>
    <form id="form1" runat="server">
        <article style="margin: 5%">
            <section>
                <div>
                    <asp:ImageButton ID="btnRegresar" style="width:100px" runat="server" ImageUrl="~/images/logo-sac.png" OnClick="btnRegresar_Click" />
                    <label style="margin-right: 25%; margin-left: 20%;">ORDEN DE PRODUCCION</label>
                    <label>No. </label>
                    <asp:Label ID="lblNumOrden" runat="server"></asp:Label>
                </div>
                <div style="margin-top: 5%">
                    <label>Fecha de expedicion de la orden: </label>
                    <asp:Label ID="lblFechaExp" runat="server"></asp:Label>
                </div>
            </section>

            <section style="margin-top: 2%">
                <b>Datos sobre el producto a fabricar:</b><br />
                <div style="display: inline-block; padding-right: 40%; margin-top: 2%; margin-left: 2%">
                    <label>Articulo: </label>
                    <asp:Label ID="lblArticulo" runat="server"></asp:Label><br />
                    <label>Fecha Inicio: </label>
                    <asp:Label ID="lblFechaI" runat="server"></asp:Label><br />
                    <label>Pedido No: </label>
                    <asp:Label ID="lblNumPedido" runat="server"></asp:Label><br />
                </div>
                <div style="display: inline-block">
                    <label>Cantidad: </label>
                    <asp:Label ID="lblCantidad" runat="server"></asp:Label><br />
                    <label>Fecha Fin: </label>
                    <asp:Label ID="lblFechaF" runat="server"></asp:Label><br />
                    <label>Especificaciones: </label>
                    <asp:Label ID="lblEspecificacion" runat="server"></asp:Label><br />
                </div>
            </section>
            <section style="margin-top:3%">
                <asp:GridView ID="grdImprimir" runat="server" AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Solid">
                    <Columns>
                        <asp:BoundField DataField="mat_detalle" HeaderText="Concepto">
                        <ControlStyle BorderStyle="Solid" />
                        <FooterStyle BorderStyle="Solid" />
                        <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigoclaMO" HeaderText="Mano de Obra">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigoclaMP" HeaderText="Materia Prima">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigoclaCIF" HeaderText="Costo Indirecto Fabricacion">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigoclaGA" HeaderText="Gastos Adminisrtativos">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigoclaGV" HeaderText="Gastos de Ventas">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigoclaGF" HeaderText="Gastos Financieros">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mat_total" HeaderText="Total">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mat_cantidad" HeaderText="Unidades">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mat_costoU" HeaderText="Costo Unitario">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BorderStyle="Solid" />
                    <EmptyDataRowStyle BorderStyle="Solid" />
                    <FooterStyle BorderStyle="Solid" />
                    <HeaderStyle BorderStyle="Solid" />
                    <PagerStyle BorderStyle="Solid" />
                    <RowStyle BorderStyle="Solid" />
                    <SelectedRowStyle BorderStyle="Solid" />
                </asp:GridView>
            </section>
            <asp:Label ID="Label1" runat="server" Text="Total:"></asp:Label>
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
            <br />
            <section style="margin-top:3%">
                <div style="display: inline-block; margin-right: 20%">
                    <label>Elaborado por</label><br />
                    <br />
                    <label>_________________</label>
                </div>
                <div style="display: inline-block; margin-right: 20%">
                    <label>Recibido por</label><br />
                    <br />
                    <label>_________________</label>
                </div>
                <div style="display: inline-block">
                    <label>Control contabilidad</label><br />
                    <br />
                    <label>_________________</label>
                </div>
            </section>
        </article>
        <footer>
        </footer>
    </form>
</body>
</html>
