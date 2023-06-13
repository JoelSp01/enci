<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncioSesion.aspx.cs" Inherits="parqueo.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.2/dist/umd/popper.min.js"
        integrity="sha384-q9CRHqZndzlxGLOj+xrdLDJa9ittGte1NksRmgJKeCV9DrM7Kz868XYqsKWPpAmn"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js"
        integrity="sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13"
        crossorigin="anonymous"></script>
    <link rel="stylesheet" href="estilos.css" />
    </head>
<body class="fondo">
    <form id="form1" runat="server">
        <div>
            <header>
                <div class="p-3">
                    <h2>PUCE| Ibarra</h2>
                </div>
            </header>
            <section>
                <div class="container text-center bg-dark text-light w-25 mt-5 p-5 pt-1 rounded-3" id="containerLogIn">
                    <div>
                        <img src="images/cropped-isotipo-PUCE.png" style="width: 100px" />
                    </div>
                    <div>
                        <h3>Iniciar Sesion</h3>
                    </div>
                    <div>
                        <b>
                            <label class="form-label">Usuario</label></b>
                        <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                        <asp:Label ID="lblErrorUsuarioIn" runat="server" ForeColor="Red" Text="Ingrese un usuario válido" Visible="False"></asp:Label>
                        <br />
                        <b>
                            <label class="form-label">Contraseña</label></b>
                        <asp:TextBox ID="txtContrasena" runat="server" type="password" class="form-control" placeholder="Contraseña"></asp:TextBox>
                        <asp:Label ID="lblErrorContraIn" runat="server" ForeColor="Red" Text="Ingrese una contraseña válida" Visible="False"></asp:Label>
                        <br />
                        <asp:Button ID="btnLogIn" runat="server" Text="Iniciar Sesion" class="form-control btn btn-primary border rounded-pill" OnClick="btnLogIn_Click1" /><br />
                        <br />
                        <small>¿No tienes un usuario? <a class="text-white" id="irRegistro">Registrate</a></small>
                    </div>

                </div>
                <div class="container text-center bg-dark text-light w-25 mt-5 p-5 rounded-3" id="containerReg">

                    <h3><b>Registrar</b></h3>
                    <div>
                        <b>
                            <label class="form-label">Nombres y Apellidos</label></b>
                        <asp:TextBox ID="txtRegNombre" runat="server" class="form-control" placeholder="Escriba su nombre"></asp:TextBox>
                        <asp:Label ID="lblErrorNombre" runat="server" ForeColor="Red" Text="Campo Obligatorio" Visible="False"></asp:Label>
                        <br />
                       
                        <b>
                            <label class="form-label">Usuario</label></b>
                        <asp:TextBox ID="txtRegUsuario" runat="server" class="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                        <asp:Label ID="lblErrorUsRe" runat="server" ForeColor="Red" Text="Campo Obligatorio" Visible="False"></asp:Label>
                        <br />
                        <b>
                            <label class="form-label">Contraseña</label></b>
                        <asp:TextBox ID="txtRegContrasena" runat="server" type="password" class="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="lblErrorContraReg" runat="server" ForeColor="Red" Text="Campo Obligatorio" Visible="False"></asp:Label>
                        <br />
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="form-control btn btn-primary border rounded-pill" data-bs-toggle="modal" data-bs-target="#modalReg" OnClick="btnRegistrar_Click" /><br />
                        <br />
                        <small>Ya tengo un usuario <a class="text-white" id="irLogin">Iniciar sesion</a></small>
                    </div>
                </div>

                <%--<div class="modal fade" id="modalReg" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5 text-center">Estado</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <b>REGISTRO EXITOSO</b>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="modalLogin" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5 text-center">Error</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <b>Usuario inexistente</b>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </section>
        </div>
    </form>
</body>

<script>
    $(function () {
        $("#containerReg").hide()

        $("#irRegistro").click(function () {
            $("#containerLogIn").hide()
            $("#containerReg").show()
        });
        $("#irLogin").click(function () {
            $("#containerReg").hide()
            $("#containerLogIn").show()
        });
    });
</script>

</html>
