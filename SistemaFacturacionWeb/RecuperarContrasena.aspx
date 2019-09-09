<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContrasena.aspx.cs" Inherits="SistemaFacturacionWeb.RecuperarContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <p style="text-align: center">
        Recuperacion de Contraseña</p>
    <form id="form1" runat="server">
        <p style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="E-mail:  "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p style="text-align: center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <p style="text-align: center">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
        </p>
        <p>
            &nbsp;</p>
        <div>
        </div>
    </form>
</body>
</html>
