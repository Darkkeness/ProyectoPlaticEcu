<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="EnviarOrden.aspx.cs" Inherits="CapaPresentacion.ModuloCompra.EnviarOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div align="center">
    <h2>PEDIDOS ENVIADOS</h2>
        </div>
    <hr color="black"/>
    <div align="left" style="font-family:verdana;font-style:oblique">
        <h6>DISPONIBLES</h6>
    </div>
    <asp:GridView ID="grvDisponible" runat="server" CssClass="table tab-pane table-hover table-sm" OnSelectedIndexChanged="grvDisponible_SelectedIndexChanged" row PageSize="5" RowStyle-Font-Bold="true" RowStyle-BackColor="#BBFE89"  AllowPaging="true" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Orc_Id" HeaderText="Codigo" SortExpression="Orc_Id"></asp:BoundField>
            <asp:BoundField DataField="Orc_Orden" HeaderText="N ORDEN" SortExpression="Orc_Orden"></asp:BoundField>
            <asp:BoundField DataField="Orc_Categoria" HeaderText="Categoria" SortExpression="Orc_Categoria"></asp:BoundField>
            <asp:BoundField DataField="Orc_Entrega" HeaderText="Fecha Entrega" DataFormatString="{0:M}" SortExpression="Orc_Entrega"></asp:BoundField>
             <asp:BoundField DataField="Orc_EstadoPedido" HeaderText="Estado" SortExpression="Orc_EstadoPedido"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="RECIBIR" ButtonType="Button" ShowHeader="True" HeaderText="RECIBIR" ControlStyle-CssClass="btn btn-primary btn-sm btn-round"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="idProcesar" runat="server" />
    <hr color="black"/>
    <div align="left" style="font-family:verdana;font-style:oblique">
        <h6>NO DISPONIBLES</h6>
    </div>
      <asp:Panel ID="pnl" Visible="false" runat="server">
        <button type="button" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-send"></a>
            REENVIAR
        </button>
    </asp:Panel>
     <asp:GridView ID="grvNoDispobles" runat="server" CssClass="table tab-pane table-hover table-sm" OnSelectedIndexChanged="grvNoDispobles_SelectedIndexChanged" SelectedRowStyle-BackColor="#F9FF85" RowStyle-Font-Bold="true" RowStyle-BackColor="#F6B29D" PageSize="5" AllowPaging="true" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Orc_Id" HeaderText="Codigo" SortExpression="Orc_Id"></asp:BoundField>
            <asp:BoundField DataField="Orc_Orden" HeaderText="N ORDEN" SortExpression="Orc_Orden"></asp:BoundField>
            <asp:BoundField DataField="Orc_Categoria" HeaderText="Categoria" SortExpression="Orc_Categoria"></asp:BoundField>
            <asp:BoundField DataField="Orc_Entrega" HeaderText="Fecha Entrega" DataFormatString="{0:M}" SortExpression="Orc_Entrega"></asp:BoundField>
             <asp:BoundField DataField="Orc_EstadoPedido" HeaderText="Estado" SortExpression="Orc_EstadoPedido"></asp:BoundField>
            <asp:ButtonField CommandName="Select"  Text="REENVIAR" ButtonType="Button" ShowHeader="True" HeaderText="REENVIAR" ControlStyle-CssClass="btn btn-dark btn-sm btn-round"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="idGuardado" />
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
