<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="ProcesarOrden.aspx.cs" Inherits="CapaPresentacion.Modulo_Compra.ProcesarOrden.ProcesarOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2>PROCESAR ORDENES DE COMPRA</h2>
    </div>
    <hr color="black" />
    <asp:HiddenField runat="server" ID="idGuardado" />
    <asp:Panel ID="pnl" Visible="false" runat="server">
        <button type="button" class="btn btn-outline-primary" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-send"></a>
            ENVIAR
        </button>
    </asp:Panel>
    <asp:GridView ID="grvOrden" SelectedRowStyle-BackColor="YellowGreen" SelectedRowStyle-ForeColor="Black" runat="server" OnSelectedIndexChanged="grvOrden_SelectedIndexChanged" AutoGenerateColumns="False" CssClass="table table-bordered table-dark" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Yellow">
        <Columns>
            <asp:BoundField DataField="Orc_Id" HeaderText="Codigo" SortExpression="Orc_Id"></asp:BoundField>
            <asp:BoundField DataField="Orc_Descripcion" HeaderText="Descripcion" SortExpression="Orc_Descripcion"></asp:BoundField>
            <asp:BoundField DataField="Orc_Categoria" HeaderText="Porducto"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="SELECCIONAR" ButtonType="Button" ShowHeader="True" HeaderText="SELECCIONAR" ControlStyle-CssClass="btn btn-info"></asp:ButtonField>
        </Columns>
    </asp:GridView>


    <%--/////dialogo//--%>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="label">ENVIAR A PROVEEDOR</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:table runat="server" CellPadding="10">
                        <asp:TableRow>
                            <asp:TableCell>
                                Proveedor:
                                <asp:DropDownList runat="server" ID="proveedor" CssClass="form-control" DataSourceID="LinqDataSource1" DataTextField="Prv_Nombre" DataValueField="Prv_Id"></asp:DropDownList>
                                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="CapaDatos.DBADODataContext" TableName="Tbl_Proveedor"></asp:LinqDataSource>
                            </asp:TableCell>
                            <asp:TableCell>
                                Presentacion:
                                <asp:DropDownList runat="server" ID="presentacion" CssClass="form-control">
                                    <asp:ListItem Text="Seleccione.."> </asp:ListItem>
                                    <asp:ListItem Text="ROLLO" Value="ROLLO"> </asp:ListItem>
                                    <asp:ListItem Text="CAJA" Value="CAJA"> </asp:ListItem>
                              </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow >
                            <asp:TableCell>
                                Ancho en centimetros:
                                <asp:TextBox runat="server" ID="ancho" TextMode="Number" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                Largo en centimetros:
                                <asp:TextBox runat="server" ID="largo"  TextMode="Number"  CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:table>
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnEnviar" OnClick="btnEnviar_Click" Text="Enviar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
