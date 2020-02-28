<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" href="images/icono.ico" type="image/ico" />
    <title>LOG IN PLASTIC ECU | </title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
  </head>

  <body class="login" style="background-image: url(/images/fondo.jpg)" >
      <form runat="server">
    <div>
      <a class="hiddenanchor" id="signup"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <form>
              <h1 style="color:white;font-weight:bold;font-size:30px">MODULO COMPRAS</h1>
              <div>
                  <asp:Label id="intentos" runat="server" CssClass="text-capitalize text-danger" ></asp:Label>
                <asp:TextBox runat="server"  type="text" ID="txtUser" class="form-control" placeholder="Username" required="Requiere Usuario" />
              </div>
                <br />
              <div>
                <asp:TextBox runat="server"   type="password" ID="txtPass" class="form-control" placeholder="Password" required="" />
              </div>
              <div>
                  <hr />
                  <asp:Button  runat="server" CssClass="btn btn-success"  OnClick="Unnamed3_Click" Text="INGRESAR"></asp:Button>
                
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                  <a  style="color:white" href="recuperarContraseña.aspx" class="to_register"> Olvido su contraseña? </a>
                  <br />
                  <a  style="color:white" href="crearUsuarioNuevo.aspx" class="title"> CREAR CUENTA </a>
                

                <div class="clearfix"></div>
                <br />

              </div>
            </form>
          </section>
        </div> 
          </form>
  </body>
</html>

