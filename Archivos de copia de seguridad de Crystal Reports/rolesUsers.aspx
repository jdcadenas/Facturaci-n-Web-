<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rolesUsers.aspx.cs" Inherits="SistemaFacturacionWeb.rolesUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar  Usuario" />
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="top: 10px; left: 309px; position: absolute; height: 26px; width: 194px" Text="Asignar Administrador" />
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" style="top: 12px; left: 512px; position: absolute; width: 356px; height: 24px"></asp:TextBox>
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Usuario Roles" Width="139px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="top: 50px; left: 306px; position: absolute; height: 26px; width: 199px" Text="Asignar Facturacion" />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" style="top: 50px; left: 515px; position: absolute; height: 26px; width: 364px" Text="Eliminar roles" />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="top: 103px; left: 10px; position: absolute; height: 133px; width: 874px">
        </asp:GridView>
    </form>
</body>
</html>
