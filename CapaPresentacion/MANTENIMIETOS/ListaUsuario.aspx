<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="ListaUsuario.aspx.cs" Inherits="CapaPresentacion.MANTENIMIETOS.ListaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title x_title text-dark text-xl-center h6"> LISTA USUARIOS </div>
    <asp:Panel runat="server" ID="pnlBotones" style="float:right" Visible="false" Width="90%" >
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
   <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-danger"  OnClick="SubmitBtn_Click" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="10%">
   <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:Panel>
   <asp:Panel runat="server" style="float:left" Width="100%">
    <asp:GridView HeaderStyle-HorizontalAlign="Center" SelectedRowStyle-BackColor="White" SelectedRowStyle-ForeColor="Black" SelectedRowStyle-Font-Bold="true" OnSelectedIndexChanged="GrvUsuario_SelectedIndexChanged" RowStyle-HorizontalAlign="Center" Width="70%" ID="GrvUsuario" runat="server" CssClass="table table-dark" DataKeyNames="Usu_Id" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField  DataField="Usu_Id"  HeaderText="Codigo" SortExpression="Usu_Id"></asp:BoundField>
            <asp:BoundField DataField="Usu_Nombre" HeaderText="Nombre" SortExpression="Usu_Nombre"></asp:BoundField>
             <asp:BoundField DataField="Usu_Estado" HeaderText="Estado" SortExpression="Usu_Estado"></asp:BoundField>
           
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
        </Columns>
    </asp:GridView>
       </asp:Panel>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="exampleModalLabel">CREAR USUARIO</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                         <div>
                <asp:TextBox runat="server" TextMode="Number" ID="txtCedula" class="form-control" placeholder="Cedula" required="Requiere Usuario" MaxLength="10" />
              </div>
                <br />
                <asp:TextBox runat="server" type="text" ID="txtNombre" class="form-control" placeholder="Nombre" required="Requiere nombre" />
              </div>
                    <br />
                 <div>
                <asp:TextBox runat="server" type="text" ID="txtApellido" class="form-control" placeholder="Apellido" required="Requiere apellido" />
              </div>
                <br />
                 <div>
                <asp:TextBox runat="server" TextMode="Number" ID="txtTelefono" class="form-control" placeholder="Telefono" required="Requiere Telefono" MaxLength="10" />
              </div>
                <br />
                 <div>
                <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" class="form-control" placeholder="Email" required="Requiere Email" />
              </div>
                <br />
                 <div>
                <asp:TextBox runat="server" TextMode="Password" ID="txtContraseña" class="form-control" placeholder="Contraseña" required="Requiere COntraseña" />
              </div>
                <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="Unnamed_Click" Text="Guardar" ></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


 <%--   ////editar/////--%>
    <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="label">EDITAR USUARIO</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:TextBox runat="server" ID="etxtNombres" CssClass="form-control" placeholder="Nombres" />
                     <br />
                    <asp:HiddenField runat="server" ID="hdId"   />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnEditar_Click" ID="btnEditar" Text="Guardar" ></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
