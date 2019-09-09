<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuariocambio.aspx.cs" Inherits="SistemaFacturacionWeb.usuariocambio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario"></asp:Label>
            :&nbsp;
            <input id="Text1" type="text" /><br />
            Corres Electronico:&nbsp;&nbsp;&nbsp;
            <input id="Text2" type="text" /><br />
            Usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Text3" type="text" /><br />
            Direccion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="Text4" type="text" /><br />
&nbsp;<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Modificar" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
