<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperarContraseña.aspx.cs" Inherits="CapaPresentacion.recuperarContraseña" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Gentelella Alela! | </title>

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
          <div class="login_wrapper" >
            <div class="animate form login_form">
          <section class="login_content">
            <form>
              <h1>Recuperar Contraseña</h1>
              <div>
                  <asp:Label id="intentos" runat="server" CssClass="text-capitalize text-danger" ></asp:Label>
                <asp:TextBox runat="server" type="text" ID="txtRecuperarUser" class="form-control" placeholder="User" required="Requiere Usuario" />
              </div>
                <br />
              <div>
                <asp:TextBox runat="server" TextMode="Email" ID="txtRecuperarEmail" class="form-control" placeholder="Email" required="" />
              </div>
              <div>
                  <hr />
                  <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-primary"  OnClick="enviar" ><i class="fa fa-send"></i>&nbsp;ENVIAR</asp:LinkButton>
                
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                  <a href="Login.aspx" class="to_register">LOGIN </a>
                

                <div class="clearfix"></div>
                <br />

              </div>
               
            </form>
          </section>
                 </div>
        </div> 
     </form>
  </body>
</html>


