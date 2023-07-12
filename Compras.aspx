<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="parqueo.WebForm2" %>

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
    <form id="formCompras" runat="server">
        <header>
            <div class="p-3" style="display: inline-block; width: 85%;">
                <h2>PUCE| Ibarra</h2>
            </div>
            <div class="p-3" style="display: inline-block; width: 10%;">
                <asp:Button class="btn btn-secondary rounded-start" ID="cerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesion_Click" />
            </div>
            <h2 class="text-center">
                <asp:Label ID="lblIdMaterial" runat="server" Enabled="False" Visible="False"></asp:Label>
                <asp:Label ID="lblIdProveedor" runat="server" Visible="False"></asp:Label>
                Compras<asp:Label ID="lblIdClasificacion" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblIdIva" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblIdCompra" runat="server" Visible="False"></asp:Label>
            </h2>
        </header>
                    
        <nav>
            <ul class="nav nav-tabs justify-content-center">
                <li class="nav-item"><a class="nav-link text-dark" href="menu.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="registroCliProv.aspx">Registrar</a></li>
                <li class="nav-item"><a class="nav-link active text-dark" href="Compras.aspx">Compras</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="pedido.aspx">Pedidos</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="ordenProduccion.aspx">Ordenes</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="reporte.aspx">Reporte</a></li>
                <li class="nav-item"><a class="nav-link text-dark" href="kardex.aspx">Kardex</a></li>

                
            </ul>
        </nav>
        <section>
            <div class="m-3">
                <asp:Button ID="addNuevo" class="btn btn-dark" runat="server" Text="Nuevo" OnClick="addNuevo_Click" />
            </div>
            
            
                <asp:Panel ID="panelCompra" class="border p-2 rounded-3" style="width:30%; display:inline-block; float:left; margin-left: 2%;" Visible="false" runat="server">
                    <div style="margin-left: 5%; display: inline-block; width: 40%; float: left;">
                        <label class="form-label">Proveedor</label>
                        <asp:DropDownList ID="listProveedor" style="padding-inline: 4%;" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listProveedor_SelectedIndexChanged">
                        </asp:DropDownList> 
                        <asp:Label ID="lblErrorProveedor" runat="server" Text="Elija Proveedor" ForeColor="Red" Visible="False"></asp:Label>
          
                        <label class="form-label" style="margin-top:2%">Material</label>
                        <asp:DropDownList ID="listMaterial" runat="server" style="padding-inline: 4%;" class="form-control"></asp:DropDownList>
                        <asp:Label ID="lblErrorDetalle" runat="server" Text="Ingrese un Detalle" ForeColor="Red" Visible="False"></asp:Label>
                       
                        <label class="form-label" style="margin-top:2%">Cantidad</label>
                        <asp:TextBox ID="txtCantidad" type="text" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="calcularSubTotal"></asp:TextBox>
                        <asp:Label ID="lblErrorCantidad" runat="server" ForeColor="Red" Text="Ingrese  números válidos" Visible="False"></asp:Label>

                        <label class="form-label" style="margin-top:2%">IVA</label> 
                        <asp:DropDownList ID="listIva" runat="server" style="padding-inline: 4%;" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="listIva_SelectedIndexChanged"></asp:DropDownList>                        
                        <asp:Label ID="lblErrorIva" runat="server" ForeColor="Red" Text="Escoja IVA" Visible="False"></asp:Label>
                        
                        <label class="form-label" style="margin-top:2%">Total</label>
                        <asp:TextBox ID="txtTotal"  class="form-control" style="width: 100%" runat="server" Enabled="False"></asp:TextBox>
                        

                        <label class="form-label" style="margin-top:2%">Caracteristica</label>
                        <asp:DropDownList ID="listClasificacion" style="padding-inline: 4%;" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listClasificacion_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="lblErrorCaracteristica" runat="server" ForeColor="Red" Text="Seleccione Característica" Visible="False"></asp:Label><br />

                    </div>
                    <div style=" margin-left: 5%; display: inline-block; width:40%; float: left;">

                        <label class="form-label">RUC</label>
                        <asp:TextBox ID="txtRuc" style="width: 100%" class="form-control" runat="server" Enabled="False"></asp:TextBox><br />
                        
                        <label  style="margin-top:10%">Autorización</label>
                        <asp:TextBox ID="txtAut" type="number" class="form-control" runat="server"></asp:TextBox>
                        <asp:Label ID="lblErrorAutori" runat="server" Text="Ingrese Autorización" ForeColor="Red" Visible="False"></asp:Label>
                         
           
                        <label class="form-label" style="margin-top:6%">C/Unitario</label>
                        <asp:TextBox ID="txtCostoUnidad" type="text" class="form-control" runat="server" OnTextChanged="calcularSubTotal" AutoPostBack="True"></asp:TextBox>
                         <asp:Label ID="lblErrorCostoU" runat="server" ForeColor="Red" Text="Ingrese  números validos" Visible="False"></asp:Label>
                        
                        <label class="form-label" style="margin-top:6%">C/Unitario + IVA</label>
                        <asp:TextBox ID="txtSubtotal" type="text" class="form-control" style="width: 100%" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>

                        <label class="form-label" style="margin-top:10%">Fecha</label>
                        <asp:TextBox ID="txtFechaEntrada" type="date" runat="server" class="form-control"></asp:TextBox><br />
                        <asp:Label ID="lblErrorFecha" runat="server" Text="Label" Visible="False"></asp:Label>
                        <br />
                    </div>
                    <asp:Button ID="btnIngresarMaterial" runat="server" Text="Confirmar" class="form-control btn btn-secondary border rounded-pill" OnClick="btnIngresarMaterial_Click" /><br />
                </asp:Panel>

            <asp:Panel ID="panelGridMat" style="overflow-y: scroll; height: 400px; width: 65%" Visible="false" runat="server">

                <asp:GridView ID="grdMateriales" style="width:100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="COM_ID"  OnRowDeleting="grdMateriales_RowDeleting" OnSelectedIndexChanging="grdMateriales_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">

                            <ItemTemplate>
                                <asp:Label ID="lblMaterialId" runat="server" Text='<%# Bind("com_id") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:BoundField DataField="com_fecha" HeaderText="FechaCompra" />
                        <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
                        <asp:BoundField DataField="ruc" HeaderText="Proveedor RUC" />
                        <asp:BoundField DataField="autorizacion" HeaderText="Autorización" />
                        <asp:BoundField DataField="detalle" HeaderText="Detalle" />
                        <asp:BoundField DataField="clasificacion" HeaderText="Clasificacion" />
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="costo_unitario" HeaderText="Costo U" />
                        <asp:BoundField DataField="costo_unitario_iva" HeaderText="Costo U + Iva" />
                        <asp:BoundField DataField="total" HeaderText="Total" />
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
    </form>
</body>
<script>
</script>
</html>