
<%@ Page Title="" Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SistemaFacturacionWeb.Views.Presupuesto.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nombre del Articulo o Codigo de Referencia:" style="top: 34px; left: 12px; position: absolute; height: 19px; width: 362px"></asp:Label>
        :<asp:TextBox ID="TextBox1" runat="server" style="top: 35px; left: 392px; position: absolute; float: left; height: 22px; width: 283px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="top: 75px; left: 345px; position: absolute; height: 26px; right: 590px;" Text="Buscar" Width="81px" />
    </p>
    <asp:GridView ID="grilla" runat="server" style="top: 116px; left: 20px; position: absolute; height: 74px; width: 661px" OnSelectedIndexChanged="grilla_SelectedIndexChanged">
    </asp:GridView>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Codigo], [PrecioPromedioArticulo], [CantidadArticulo], [FechaVencimiento], [DescripcionArticulo] FROM [articulo]"></asp:SqlDataSource>
    <p>
    </p>
</asp:Content>
