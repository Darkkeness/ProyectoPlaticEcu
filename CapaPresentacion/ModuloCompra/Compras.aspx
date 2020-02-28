<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="CapaPresentacion.ModuloCompra.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2>LISTA DE COMPRAS REALIZADAS</h2>
    </div>
    <hr color="black" />
    Categoria:
                     <asp:DropDownList runat="server" ID="categoria" CssClass="form-control col-4" OnTextChanged="categoria_TextChanged" AutoPostBack="true">
                         <asp:ListItem Text="SELECCIONE..."></asp:ListItem>
                         <asp:ListItem Text="INSUMOS" Value="INSUMOS"></asp:ListItem>
                         <asp:ListItem Text="POLIMEROS" Value="POLIMEROS"></asp:ListItem>
                         <asp:ListItem Text="MAQUINARIA" Value="MAQUINARIA"></asp:ListItem>
                         <asp:ListItem Text="REPUESTO" Value="REPUESTO"></asp:ListItem>
                         <asp:ListItem Text="PALETIZADA" Value="PALETIZADA"></asp:ListItem>
                     </asp:DropDownList>
    <hr />
    <asp:GridView runat="server" ID="grvComprasIns" Visible="false" OnSelectedIndexChanged="grvComprasIns_SelectedIndexChanged" EmptyDataText="NO HAY DATOS" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CssClass="table table-hover table-dark">
        <Columns>
             <asp:BoundField DataField="Com_Id" HeaderText="Codigo" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Insumos.Ins_Nombre" HeaderText="Detalle" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Insumos.Ins_Cantidad" HeaderText="Cantidad" DataFormatString="{0:C}"></asp:BoundField>
            <asp:BoundField DataField="Tbl_Insumos.Ins_Precio_Unitario" HeaderText="Precio" DataFormatString="{0:C}"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="PDF" ShowHeader="True" HeaderText="FACTURA" ControlStyle-CssClass="btn btn-sm btn-round btn-danger"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:GridView runat="server" ID="grvPolimeros" Visible="false" EmptyDataText="NO HAY DATOS" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CssClass="table table-hover table-dark">
        <Columns>
             <asp:BoundField DataField="Com_Id" HeaderText="Codigo" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Polimeros.Pol_Nombre" HeaderText="Detalle" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Polimeros.Pol_Cantidad" HeaderText="Cantidad" DataFormatString="{0:C}"></asp:BoundField>
            <asp:BoundField DataField="Tbl_Polimeros.Pol_Precio_Unitario" HeaderText="Precio" DataFormatString="{0:C}"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="PDF" ShowHeader="True" HeaderText="FACTURA" ControlStyle-CssClass="btn btn-sm btn-round btn-danger"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:GridView runat="server" ID="grvMaquinaria" Visible="false" EmptyDataText="NO HAY DATOS" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CssClass="table table-hover table-dark">
        <Columns>
             <asp:BoundField DataField="Com_Id" HeaderText="Codigo" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Maquinaria.Maq_Nombre" HeaderText="Detalle" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Maquinaria.Maq_Cantidad" HeaderText="Cantidad" DataFormatString="{0:C}"></asp:BoundField>
            <asp:BoundField DataField="Tbl_Maquinaria.Maq_Precio_Unitario" HeaderText="Precio" DataFormatString="{0:C}"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="PDF" ShowHeader="True" HeaderText="FACTURA" ControlStyle-CssClass="btn btn-sm btn-round btn-danger"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:GridView runat="server" ID="grvRepuesto" Visible="false" EmptyDataText="NO HAY DATOS" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CssClass="table table-hover table-dark">
        <Columns>
             <asp:BoundField DataField="Com_Id" HeaderText="Codigo" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Repuesto.Rep_Nombre" HeaderText="Detalle" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Repuesto.Rep_Cantidad" HeaderText="Cantidad" DataFormatString="{0:C}"></asp:BoundField>
            <asp:BoundField DataField="Tbl_Repuesto.Rep_Precio_Unitario" HeaderText="Precio" DataFormatString="{0:C}"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="PDF" ShowHeader="True" HeaderText="FACTURA" ControlStyle-CssClass="btn btn-sm btn-round btn-danger"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:GridView runat="server" ID="grvPaletizado" Visible="false" EmptyDataText="NO HAY DATOS" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CssClass="table table-hover table-dark">
        <Columns>
             <asp:BoundField DataField="Com_Id" HeaderText="Codigo" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Paletizado.Pal_Nombre" HeaderText="Detalle" ></asp:BoundField>
            <asp:BoundField DataField="Tbl_Paletizado.Pal_Cantidad" HeaderText="Cantidad" DataFormatString="{0:C}"></asp:BoundField>
            <asp:BoundField DataField="Tbl_Paletizado.Pal_Precio_Unitario" HeaderText="Precio" DataFormatString="{0:C}"></asp:BoundField>
            <asp:ButtonField CommandName="Select" Text="PDF" ShowHeader="True" HeaderText="FACTURA" ControlStyle-CssClass="btn btn-sm btn-round btn-danger"></asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
