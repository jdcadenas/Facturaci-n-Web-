<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarioperfil.aspx.cs" Inherits="SistemaFacturacionWeb.usuarioperfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #3333CC;
        }
        #Text1 {
            top: 56px;
            left: 84px;
            position: absolute;
            float: right;
            height: 16px;
            width: 128px;
            margin-top: 0px;
            margin-bottom: 8px;
        }
        #Text2 {
            top: 96px;
            left: 84px;
            position: absolute;
            height: 15px;
            width: 128px;
        }
        #Text3 {
            top: 129px;
            left: 83px;
            position: absolute;
            height: 15px;
            width: 128px;
        }
        #Text4 {
            top: 161px;
            left: 84px;
            position: absolute;
            height: 15px;
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Editar Perfil de Usuario:<br />
            <br />
            Correo&nbsp; :<br />
            <input id="Text1" type="text" /><br />
            Telefono:<input id="Text2" type="text" /><input id="Text3" type="text" /><br />
            <br />
            Direccion:<br />
            <br />
            Nombre:<input id="Text4" type="text" /><br />
        </div>
    </form>
</body>
</html>
