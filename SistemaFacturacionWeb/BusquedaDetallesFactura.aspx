<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusquedaDetallesFactura.aspx.cs" Inherits="SistemaFacturacionWeb.BusquedaDetallesFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            color: #0000FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <span class="auto-style2">Busqueda de Detalles de Factura:</span><br class="auto-style2" />
            <asp:Label ID="Label1" runat="server" style="top: 70px; left: 25px; position: absolute; height: 19px; width: 287px"></asp:Label>
            <span class="auto-style2">Buscar por Numero de Facturacion<br />
            </span>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Height="21px" OnClick="Button1_Click" Text="Button" Width="129px" />
            <br />
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CustomerId" DataSourceID="SqlDataSource2" EmptyDataText="No hay registros de datos para mostrar." ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="749px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id Factura" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                    <asp:BoundField DataField="Factura" HeaderText="Factura" SortExpression="Factura" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Fecha Facturación" SortExpression="OrderDate" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:facturacionConnectionString1 %>" DeleteCommand="DELETE FROM [Ventas] WHERE [CustomerId] = @CustomerId" InsertCommand="INSERT INTO [Ventas] ([CustomerId], [Cliente], [Factura], [OrderDate]) VALUES (@CustomerId, @Cliente, @Factura, @OrderDate)" ProviderName="<%$ ConnectionStrings:facturacionConnectionString1.ProviderName %>" SelectCommand="SELECT [CustomerId], [Cliente], [Factura], [OrderDate], [Id] FROM [Ventas]" UpdateCommand="UPDATE [Ventas] SET [Cliente] = @Cliente, [Factura] = @Factura, [OrderDate] = @OrderDate, [Id] = @Id WHERE [CustomerId] = @CustomerId">
                <DeleteParameters>
                    <asp:Parameter Name="CustomerId" Type="Object" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="CustomerId" Type="Object" />
                    <asp:Parameter Name="Cliente" Type="String" />
                    <asp:Parameter Name="Factura" Type="String" />
                    <asp:Parameter Name="OrderDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Cliente" Type="String" />
                    <asp:Parameter Name="Factura" Type="String" />
                    <asp:Parameter Name="OrderDate" Type="DateTime" />
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="CustomerId" Type="Object" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderId" DataSourceID="SqlDataSource1" EmptyDataText="No hay registros de datos para mostrar." ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Articulo" HeaderText="Articulo" SortExpression="Articulo" />
                    <asp:BoundField DataField="ArticuloCodigo" HeaderText="ArticuloCodigo" SortExpression="ArticuloCodigo" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                    <asp:HyperLinkField DataNavigateUrlFields="OrderId" DataNavigateUrlFormatString="VentasDetalles/Details/{0}" HeaderText="Ver Detalles" Text="Ver" Target="_blank"/>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:facturacionConnectionString1 %>" DeleteCommand="DELETE FROM [VentasDetalles] WHERE [OrderId] = @OrderId" InsertCommand="INSERT INTO [VentasDetalles] ([OrderId], [Articulo], [ArticuloCodigo], [Cantidad], [Precio], [Total], [CustomerId]) VALUES (@OrderId, @Articulo, @ArticuloCodigo, @Cantidad, @Precio, @Total, @CustomerId)" ProviderName="<%$ ConnectionStrings:facturacionConnectionString1.ProviderName %>" SelectCommand="SELECT [OrderId], [Articulo], [ArticuloCodigo], [Cantidad], [Precio], [Total], [CustomerId] FROM [VentasDetalles]" UpdateCommand="UPDATE [VentasDetalles] SET [Articulo] = @Articulo, [ArticuloCodigo] = @ArticuloCodigo, [Cantidad] = @Cantidad, [Precio] = @Precio, [Total] = @Total, [CustomerId] = @CustomerId WHERE [OrderId] = @OrderId">
                <DeleteParameters>
                    <asp:Parameter Name="OrderId" Type="Object" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="OrderId" Type="Object" />
                    <asp:Parameter Name="Articulo" Type="String" />
                    <asp:Parameter Name="ArticuloCodigo" Type="String" />
                    <asp:Parameter Name="Cantidad" Type="Decimal" />
                    <asp:Parameter Name="Precio" Type="Decimal" />
                    <asp:Parameter Name="Total" Type="Decimal" />
                    <asp:Parameter Name="CustomerId" Type="Object" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Articulo" Type="String" />
                    <asp:Parameter Name="ArticuloCodigo" Type="String" />
                    <asp:Parameter Name="Cantidad" Type="Decimal" />
                    <asp:Parameter Name="Precio" Type="Decimal" />
                    <asp:Parameter Name="Total" Type="Decimal" />
                    <asp:Parameter Name="CustomerId" Type="Object" />
                    <asp:Parameter Name="OrderId" Type="Object" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
