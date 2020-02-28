<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="ListaProveedor.aspx.cs" Inherits="CapaPresentacion.MANTENIMIETOS.ListaProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title x_title text-dark text-xl-center h6">LISTA PROVEEDORES </div>
    <asp:Panel runat="server" ID="pnlBotones" Style="float: right" Visible="false" Width="90%">
        <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar">
            <a class="fa fa-pencil"></a>
            Editar
        </button>
    </asp:Panel>
    <asp:Panel runat="server" Style="float: left" Width="10%">
        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-plus"></a>
            Registrar
        </button>
    </asp:Panel>
    <asp:Panel runat="server" Style="float: left" Width="100%">
        <asp:GridView HeaderStyle-HorizontalAlign="Center" SelectedRowStyle-BackColor="White" SelectedRowStyle-ForeColor="Black" SelectedRowStyle-Font-Bold="true" OnSelectedIndexChanged="GrvCliente_SelectedIndexChanged" RowStyle-HorizontalAlign="Center" Width="70%" ID="GrvProveedor" runat="server" CssClass="table table-dark" DataKeyNames="Prv_Id" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Prv_Id" HeaderText="Codigo" SortExpression="CliId"></asp:BoundField>
                <asp:BoundField DataField="Prv_Nombre" HeaderText="Razon Social" SortExpression="CliCargo"></asp:BoundField>
                <asp:BoundField DataField="Prv_Direccion" HeaderText="Direccion"></asp:BoundField>
                <asp:BoundField DataField="Prv_Telefono" HeaderText="Telefono"></asp:BoundField>
                <asp:BoundField DataField="Prv_Nacionalidad" HeaderText="Nacionalidad"></asp:BoundField>
                <asp:BoundField DataField="Prv_Ruc" HeaderText="Ruc"></asp:BoundField>
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hdId" />
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">REGISTRAR PROVEEDOR</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Razon Social" />
                    <br />
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Direccion" />
                    <br />
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Telefono" />
                    <br />
                    Pais:
                    <asp:DropDownList runat="server" ID="txtNacionalidad" CssClass="form-control" placeholder="Nacionalidad">
                        <asp:ListItem Text="ECUADOR" Value="ECUADOR"></asp:ListItem>
                        <asp:ListItem Text="ESPAÑA" Value="ESPAÑA"></asp:ListItem>
                        <asp:ListItem Text="BRASIL" Value="BRASIL"></asp:ListItem>
                        <asp:ListItem Text="COLOMBIA" Value="COLOMBIA"></asp:ListItem>
                        <asp:ListItem Text="PERU" Value="PERU"></asp:ListItem>
                        <asp:ListItem Text="ARGENTINA" Value="ARGENTINA"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox runat="server" ID="txtRuc" CssClass="form-control" placeholder="Identificacion Empresa" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" ID="btnGuardar" Text="Guardar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <%--   ////editar/////--%>
    <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="label">EDITAR CLIENTE</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="etxtNombre" CssClass="form-control" placeholder="Razon Social" />
                    <br />
                    <asp:TextBox runat="server" ID="etxtDireccion" CssClass="form-control" placeholder="Direccion" />
                    <br />
                    <asp:TextBox runat="server" ID="etxtTelefono" CssClass="form-control" placeholder="Telefono" />
                    <br />
                    Pais:
                    <asp:DropDownList runat="server" ID="etxtNacionalidad" CssClass="form-control" placeholder="Nacionalidad">
                        <asp:ListItem Text="ECUADOR" Value="ECUADOR"></asp:ListItem>
                        <asp:ListItem Text="ESPAÑA" Value="ESPAÑA"></asp:ListItem>
                        <asp:ListItem Text="BRASIL" Value="BRASIL"></asp:ListItem>
                        <asp:ListItem Text="COLOMBIA" Value="COLOMBIA"></asp:ListItem>
                        <asp:ListItem Text="PERU" Value="PERU"></asp:ListItem>
                        <asp:ListItem Text="ARGENTINA" Value="ARGENTINA"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox runat="server" ID="etxtRuc" CssClass="form-control" placeholder="Identificacion Empresa" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnEditar_Click" ID="btnEditar" Text="Guardar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
