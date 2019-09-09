<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="SistemaFacturacionWeb.AgregarArticulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 349px">
            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" style="top: 12px; left: 162px; position: absolute; height: 22px; width: 136px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Stock  Minimo:"></asp:Label>
            <asp:TextBox ID="TextBox2" type="Number" runat="server" style="top: 49px; left: 162px; position: absolute; height: 22px; width: 135px; right: 474px; bottom: 182px;" MaxLength="2"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Stock Maximo:"></asp:Label>
            <asp:TextBox ID="TextBox3" type="Number" runat="server" style="top: 85px; left: 160px; position: absolute; height: 22px; width: 136px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Codigo:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" style="top: 125px; left: 162px; position: absolute; height: 22px; width: 136px"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Cantidad:" style="top: 171px; left: 10px; position: absolute; height: 19px; width: 58px"></asp:Label>
            <asp:TextBox ID="TextBox6" type="Number" runat="server" style="top: 167px; left: 160px; position: absolute; height: 22px; width: 136px" MaxLength="4"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" style="top: 212px; left: 10px; position: absolute; height: 19px; width: 160px" Text="Fecha de Vencimiento:"></asp:Label>
            <asp:TextBox ID="TextBox7" type="date" value="1/11/1989" runat="server" style="top: 209px; left: 161px; position: absolute; height: 22px; width: 136px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" style="top: 261px; left: 10px; position: absolute; height: 19px; width: 117px" Text="Unidad de Medida:"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" style="top: 262px; left: 164px; position: absolute; height: 32px; width: 138px">
                <asp:ListItem>Unidades</asp:ListItem>
                <asp:ListItem>Metros</asp:ListItem>
                <asp:ListItem>Kilogramos</asp:ListItem>
                <asp:ListItem>CC</asp:ListItem>
                <asp:ListItem>Cajas</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label11" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" class="btn btn-default" runat="server" style="top: 355px; left: 97px; position: absolute; height: 26px; float: right;" Text="Salvar" Width="142px" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
