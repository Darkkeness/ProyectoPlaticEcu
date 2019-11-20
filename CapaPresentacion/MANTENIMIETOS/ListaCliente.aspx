<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="ListaCliente.aspx.cs" Inherits="CapaPresentacion.MANTENIMIETOS.ListaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title x_title text-dark text-xl-center h6"> Lista Usuarios </div>
    <asp:Panel runat="server" ID="pnlBotones" style="float:right" Visible="false" Width="90%" >
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
   <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-danger" OnClick="SubmitBtn_Click1" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="10%">
   <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:Panel>
   <asp:Panel runat="server" style="float:left" Width="100%">
    <asp:GridView HeaderStyle-HorizontalAlign="Center" SelectedRowStyle-BackColor="White" SelectedRowStyle-ForeColor="Black" SelectedRowStyle-Font-Bold="true" OnSelectedIndexChanged="GrvCliente_SelectedIndexChanged" RowStyle-HorizontalAlign="Center" Width="70%" ID="GrvCliente" runat="server" CssClass="table table-dark" DataKeyNames="Cli_Id" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField  DataField="Cli_Id"  HeaderText="Codigo" SortExpression="CliId"></asp:BoundField>
            <asp:BoundField DataField="Cli_Cargo" HeaderText="Cargo" SortExpression="CliCargo"></asp:BoundField>
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
                    <br />
   
                    <br />
                    <asp:TextBox runat="server" ID="txtCargo" CssClass="form-control" placeholder="Cargo"  />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" ID="btnGuardar" Text="Guardar" ></asp:LinkButton>
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
                    
                    <asp:TextBox runat="server" ID="txetCargo" CssClass="form-control" placeholder="Cargo"/>
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

