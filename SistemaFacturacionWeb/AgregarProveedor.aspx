<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Inherits="SistemaFacturacionWeb.AgregarProveedor" %>

<script type="text/javascript">
    function validar(e) {



        tecla = (document.all) ? e.keyCode : e.which;
        if (tecla == 8) return true; //Tecla de retroceso (para poder borrar)
        if (tecla == 44) return true; //Coma ( En este caso para diferenciar los decimales )
        if (tecla == 48) return true;
        if (tecla == 49) return true;
        if (tecla == 50) return true;
        if (tecla == 51) return true;
        if (tecla == 52) return true;
        if (tecla == 53) return true;
        if (tecla == 54) return true;
        if (tecla == 55) return true;
        if (tecla == 56) return true;
        if (tecla == 57) return true;
        patron = /1/; //ver nota
        te = String.fromCharCode(tecla);
        return patron.test(te);

        
    }
</script>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="width: 374px">
    <form id="form1" runat="server">
        <div style="width: 364px">
            <asp:TextBox ID="TextBox1" runat="server" style="top: 42px; left: 125px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <asp:TextBox ID="TextBox2" type="Text" maxlength="13" onKeyPress="return validar(event)" min="999999999" max="9999999999999" runat="server" style="top: 82px; left: 127px; position: absolute; height: 22px; width: 128px" ></asp:TextBox>
            <asp:TextBox ID="TextBox3" type="Text"  onKeyPress="return validar(event)" runat="server" MaxLength="10" style="top: 121px; left: 130px; position: absolute; height: 22px; width: 128px; right: 699px"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" style="top: 160px; left: 129px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" style="top: 203px; left: 128px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server" style="top: 241px; left: 129px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" style="top: 127px; left: 28px; position: absolute; height: 19px; width: 90px" Text="Telefono:"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" style="left: 28px; position: absolute; height: 19px; width: 75px; top: 89px" Text="RUC:"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" style="top: 321px; left: 173px; position: absolute; height: 20px; width: 166px"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" style="top: 49px; left: 28px; position: absolute; height: 19px; width: 111px" Text="Razon Social:"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" style="top: 163px; left: 28px; position: absolute; height: 19px; width: 72px" Text="Direcciòn:"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" style="top: 205px; left: 29px; position: absolute; height: 19px; width: 34px" Text="Detalles:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" style="top: 240px; left: 27px; position: absolute; height: 19px; width: 100px" Text="Nombre del Contacto:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox7" runat="server" style="top: 281px; left: 128px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" style="top: 322px; left: 96px; position: absolute; height: 26px; width: 56px" Text="Guardar" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label8" runat="server" style="top: 286px; left: 25px; position: absolute; height: 19px; width: 87px" Text="Sitio Web:"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {

            $("#TextBox2").focusout(function () {
            console.log("validacion de cedual");
            var cedula = $("#TextBox2").val();

            console.log(cedula);
            validarCedula(cedula);



            });

             $("#TextBox3").keypress(function (event) {
                
                if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
                    event.preventDefault();
                }
                console.log(($("#TextBox3").val()));
                if ($("#TextBox3").val() > 9999999999 || $("#TextBox3").val() < 99999999) {
                   // $("#validTelefono").text("ingrese un numero valido de telefono");
                    console.log("ingrese un numero valido de telefono");
                } else {
                    // $("#validTelefono").text("valido");
                    console.log('numero valido');
                }
                //console.log("validacion de cedual")
                    
         


        });

            $("#TextBox2").keypress(function (event) {
                
                if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
                    event.preventDefault();
                }
                console.log(($("#TextBox2").val()));
                if ($("#TextBox2").val() > 999999999999 || $("#TextBox2").val() < 1000000000000000) {
                   // $("#validTelefono").text("ingrese un numero valido de telefono");
                    console.log("ingrese un numero de RUC Valido");
                } else {
                    // $("#validTelefono").text("valido");
                    console.log('numero valido');
                }
                //console.log("validacion de cedual")
                    
         


        });
    });
    </script>