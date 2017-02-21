$(document).ready(function () {

    $('#ServicioEnviarDatos').click(function () {

        var SendObj = {
            "BrowserName": navigator.appName,
            "BrowserVersion": navigator.appVersion,
            "UserAgent": navigator.userAgent
        }
        var stringData = JSON.stringify(SendObj);
        $.ajax({
            type: 'POST',
            url: 'http://shoppingcar.apphb.com/ShoppingServer.svc/BuscarProductoNombre',
            data: "{ }",
            contentType: 'application/javascript; utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.d != null) {
                    alert(data.d);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
            }

        });
    });
});

/*
 * shoppingcarci2@gmail.com
_ShoppingCarCi2

Crear personas
{
  "Nombres": "Joe Harry Mancera",
  "Correo": "joeharrymancera@gmail.com",
  "Clave": "123"
}

CrearProducto
{
  "Nombre": "Arduino Ethernet",
  "Precio": "8,99"
}

Crear pedido
{
  "ClienteId": "2",
  "ProductoId": "1",
  "Cantidad": "3"
}

Borrar producto
{
  "ProductoId": "1",
  "Cantidad": "0"
}

listar detalle
{
  "PedidoId": "1"
}
HacerPedido
{
	"ClienteId": "2"
}


login
{
	"Correo": "joeharrymancera@gmail.com",
	"Clave": "123"
}

BuscarProductoNombre
{
  "Nombre": "Ethernet"
}
 */