<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="OrdenCompra.aspx.cs" Inherits="CapaPresentacion.ModuloCompra.OrdenCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2>ORDEN DE COMPRA</h2>
    </div>
    <hr color="black" />
    <asp:Panel runat="server" Height="50px">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    N° Orden:
        <asp:TextBox runat="server" ID="ordNumero" ReadOnly="true" CssClass="form-control col-10" required="true"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    Fecha Orden:
        <asp:TextBox runat="server" ID="ordFecha" ReadOnly="true" CssClass="form-control col-10"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    Tipo Compra:
                     <asp:DropDownList runat="server" ID="ordTipoCompra" CssClass="form-control col-20">
                         <asp:ListItem Text="SELECCIONE..."></asp:ListItem>
                         <asp:ListItem Text="Nacional" Value="Nacional"></asp:ListItem>
                         <asp:ListItem Text="Internacional" Value="Internacional"></asp:ListItem>
                     </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    Categoria:
                     <asp:DropDownList runat="server" ID="categoria" CssClass="form-control col-20">
                         <asp:ListItem Text="SELECCIONE..."></asp:ListItem>
                         <asp:ListItem Text="INSUMOS" Value="INSUMOS"></asp:ListItem>
                         <asp:ListItem Text="POLIMEROS" Value="POLIMEROS"></asp:ListItem>
                         <asp:ListItem Text="MAQUINARIA" Value="MAQUINARIA"></asp:ListItem>
                         <asp:ListItem Text="REPUESTO" Value="REPUESTO"></asp:ListItem>
                         <asp:ListItem Text="PALETIZADA" Value="PALETIZADA"></asp:ListItem>
                     </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    Direccion Entrega:
                     <asp:TextBox runat="server" ID="ordDireccion" CssClass="form-control col-10" required="true"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    Tipo Pago:
                     <asp:DropDownList runat="server" ID="ordTipo" CssClass="form-control col-20">
                         <asp:ListItem Text="SELECCIONE..."></asp:ListItem>
                         <asp:ListItem Text="EFECTIVO" Value="EFECTIVO"></asp:ListItem>
                         <asp:ListItem Text="TARJETA CREDITO" Value="TARJETA CREDITO"></asp:ListItem>
                         <asp:ListItem Text="TARJETA DEBITO" Value="TARJETA DEBITO"></asp:ListItem>
                     </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    Moneda:
                     <asp:DropDownList runat="server" ID="moneda" CssClass="form-control col-20">
                         <asp:ListItem Text="SELECCIONE..."></asp:ListItem>
                         <asp:ListItem Text="DOLARES" Value="DOLARES"></asp:ListItem>
                         <asp:ListItem Text="PESOS CO" Value="PESOS CO"></asp:ListItem>
                         <asp:ListItem Text="PESOS MX" Value="PESOS MX"></asp:ListItem>
                         <asp:ListItem Text="EUROS" Value="EUROS"></asp:ListItem>
                         <asp:ListItem Text="SOLES" Value="SOLES"></asp:ListItem>
                     </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        DETALLE:
        <hr color="black" />
        <asp:Table ID="Table2" runat="server" CellPadding="20">
            <asp:TableRow>
                <asp:TableCell>
                    Articulo:
                    <asp:TextBox ID="ordProducto" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    Unidad Medida:
                    <asp:DropDownList ID="ordUnidad" runat="server" CssClass="form-control form-control-sm">
                        <asp:ListItem Text="Kilogramo" Value="Kilogramo"></asp:ListItem>
                        <asp:ListItem Text="Hectogramo" Value="Hectogramo"></asp:ListItem>
                        <asp:ListItem Text="Decagramo" Value="Decagramo"></asp:ListItem>
                        <asp:ListItem Text="Gramo" Value="Gramo"></asp:ListItem>
                        <asp:ListItem Text="Decigramo" Value="Decigramo"></asp:ListItem>
                        <asp:ListItem Text="Centigramo" Value="Centigramo"></asp:ListItem>
                        <asp:ListItem Text="Miligramo" Value="Miligramo"></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    Precio:
                    <asp:TextBox runat="server" ID="ordPrecio" TextMode="Number"  CssClass="form-control form-control-sm"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    Cantidad:
                    <asp:TextBox runat="server" ID="ordCantidad" TextMode="Number" CssClass="form-control form-control-sm"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <div style="margin-top: 15px">
                        <asp:LinkButton runat="server" ID="btnAgragra" CssClass="btn btn-success" OnClick="btnAgragra_Click"><i class="fa fa-plus"></i></asp:LinkButton>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <hr color="black" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div style="overflow-y: scroll; height: 150px;">
                    <asp:GridView runat="server" ID="grvDtalle" CssClass="table table-active table-bordered table-dark" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="OdtDescripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="OdtCantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="OdtPrecio" HeaderText="Precio" />
                            <asp:BoundField DataField="OdtTotal" HeaderText="Total" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" CssClass="btn btn-success" Text="GUARDAR" />
    </asp:Panel>
</asp:Content>
