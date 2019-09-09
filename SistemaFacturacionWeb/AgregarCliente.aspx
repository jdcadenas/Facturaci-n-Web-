<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="SistemaFacturacionWeb.AgregarCliente" %>

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
<body>

    <form id="form1" runat="server">
        <div style="width: 324px; height: 350px">





            <asp:TextBox ID="TextBox1" runat="server" style="top: 42px; left: 120px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <asp:TextBox ID="TextBox2" type="text" MaxLength="10" onKeyPress="return validar(event)" runat="server" style="top: 82px; left: 122px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
             <span id="productValidation">Validación Cédula</span>
            <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged" style="top: 121px; left: 125px; position: absolute; height: 22px; width: 128px; right: 704px"></asp:TextBox>
            <asp:TextBox ID="TextBox4" type="date" runat="server" style="top: 160px; left: 124px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <asp:TextBox ID="TextBox5" type="text" MaxLength="10" onKeyPress="return validar(event)" runat="server" style="top: 203px; left: 123px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <span id="validTelefono"></span>         
            <asp:TextBox ID="TextBox6" type="email" runat="server" style="top: 241px; left: 124px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" style="top: 127px; left: 28px; position: absolute; height: 19px; width: 34px" Text="Dirección:"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" style="left: 28px; position: absolute; height: 19px; width: 75px; top: 89px" Text="Cédula:"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" style="top: 283px; position: absolute; height: 22px; width: 164px; left: 10px;"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" style="top: 49px; left: 28px; position: absolute; height: 19px; width: 34px" Text="Nombre:"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" style="top: 156px; left: 28px; position: absolute; height: 19px; width: 72px" Text="Fecha Nacimiento:"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" style="top: 205px; left: 29px; position: absolute; height: 19px; width: 34px" Text="Teléfono:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" style="top: 243px; left: 33px; position: absolute; height: 19px; width: 34px" Text="Email:"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" style="top: 281px; left: 182px; position: absolute; height: 26px; width: 56px" Text="Guardar" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label8" runat="server" style="top: 312px; left: 10px; position: absolute; height: 20px; width: 119px"></asp:Label>
            <br />
            <br />
        </div>
    </form>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {





        function validarCedula(cedula) {
            if (cedula.length == 10) {

                //Obtenemos el digito de la region que sonlos dos primeros digitos
                var digito_region = cedula.substring(0, 2);

                //Pregunto si la region existe ecuador se divide en 24 regiones
                if (digito_region >= 1 && digito_region <= 24) {

                    // Extraigo el ultimo digito
                    var ultimo_digito = cedula.substring(9, 10);

                    //Agrupo todos los pares y los sumo
                    var pares = parseInt(cedula.substring(1, 2)) + parseInt(cedula.substring(3, 4)) + parseInt(cedula.substring(5, 6)) + parseInt(cedula.substring(7, 8));

                    //Agrupo los impares, los multiplico por un factor de 2, si la resultante es > que 9 le restamos el 9 a la resultante
                    var numero1 = cedula.substring(0, 1);
                    var numero1 = (numero1 * 2);
                    if (numero1 > 9) { var numero1 = (numero1 - 9); }

                    var numero3 = cedula.substring(2, 3);
                    var numero3 = (numero3 * 2);
                    if (numero3 > 9) { var numero3 = (numero3 - 9); }

                    var numero5 = cedula.substring(4, 5);
                    var numero5 = (numero5 * 2);
                    if (numero5 > 9) { var numero5 = (numero5 - 9); }

                    var numero7 = cedula.substring(6, 7);
                    var numero7 = (numero7 * 2);
                    if (numero7 > 9) { var numero7 = (numero7 - 9); }

                    var numero9 = cedula.substring(8, 9);
                    var numero9 = (numero9 * 2);
                    if (numero9 > 9) { var numero9 = (numero9 - 9); }

                    var impares = numero1 + numero3 + numero5 + numero7 + numero9;

                    //Suma total
                    var suma_total = (pares + impares);

                    //extraemos el primero digito
                    var primer_digito_suma = String(suma_total).substring(0, 1);

                    //Obtenemos la decena inmediata
                    var decena = (parseInt(primer_digito_suma) + 1) * 10;

                    //Obtenemos la resta de la decena inmediata - la suma_total esto nos da el digito validador
                    var digito_validador = decena - suma_total;

                    //Si el digito validador es = a 10 toma el valor de 0
                    if (digito_validador == 10)
                        var digito_validador = 0;

                    //Validamos que el digito validador sea igual al de la cedula
                    if (digito_validador == ultimo_digito) {
                        console.log('la cedula:' + cedula + ' es correcta');
                        //$("#validacionCedu").text('la cedula:');
                        $("#productValidation").html('la cedula:' + cedula + ' es correcta');
                    } else {
                        console.log('la cedula:' + cedula + ' es incorrecta');
                        $("#productValidation").html('la cedula:' + cedula + ' es incorrecta');
                    }

                } else {
                    // imprimimos en consola si la region no pertenece
                    console.log('Esta cedula no pertenece a ninguna region');
                    $("#productValidation").html('la cedula:' + cedula + ' no pertenece a ninguna region');
                }
            } else {
                //imprimimos en consola si la cedula tiene mas o menos de 10 digitos
                console.log('Esta cedula tiene menos de 10 Digitos');
                $("#productValidation").html('Esta cedula tiene menos de 10 Digitos');
            }
        }


        function validarTelefono(telefono, min , max) {
            
                console.log("validando campo telefono");
            if (parseInt(telefono) < min || isNaN(parseInt(value)))
                return 0;
            else if(parseInt(value) > max)
                return 9999999999;
            else return value;
        }
        $("#TextBox2").focusout(function () {
            console.log("validacion de cedual");
            var cedula = $("#TextBox2").val();

            console.log(cedula);
            validarCedula(cedula);



            });

            $("#TextBox5").keypress(function (event) {
                
                if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
                    event.preventDefault();
                }
                console.log(($("#TextBox5").val()));
                if ($("#TextBox5").val() > 9999999999 || $("#TextBox5").val() < 99999999) {
                   // $("#validTelefono").text("ingrese un numero valido de telefono");
                    console.log("ingrese un numero valido de telefono");
                } else {
                    // $("#validTelefono").text("valido");
                    console.log('numero valido');
                }
                //console.log("validacion de cedual")
                    
         


        });
    });
    </script>
</body>
</html>
