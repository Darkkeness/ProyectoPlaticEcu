<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambiarContraseña.aspx.cs" Inherits="CapaPresentacion.cambiarContraseña" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Cambiar contraseña | </title>

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

  <body class="login">
      <form runat="server">
    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <form>
              <h1>Cambiar contraseña</h1>
                 <div>
                <asp:TextBox runat="server" TextMode="Password" ID="txtNuevaContraseña" class="form-control" placeholder="Contraseña Nueva" required="Requiere Contraseña" />
              </div>
                <br />
                <div>
                <asp:TextBox runat="server" TextMode="Password" ID="txtRepita" class="form-control" placeholder="Verificar Contraseña" required="Requiere Verificar" />
              </div>
                <br />

              <div>
                  <hr />
                  <asp:LinkButton ID="ingresar" runat="server" CssClass="btn btn-small btn-dark"  OnClick="ingresar_Click" ><i class="fa fa-check"></i> OK ! </asp:LinkButton>
                
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                  <a href="Login.aspx" class="to_register"> Regresar </a>
                

                <div class="clearfix"></div>
                <br />

              </div>
            </form>
          </section>
        </div> 
          </form>
  </body>
</html>

