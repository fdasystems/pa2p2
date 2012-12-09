<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
Inherits="CarritoDeCompras_2012.CS._Default" MasterPageFile="~/Maestra.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentImagen" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/home.jpg" ToolTip="Catalogo" Height="600px" Width="100%" />    
</asp:Content>    


<asp:Content ContentPlaceHolderID="ContentBody" runat="server">

<table>
<tr><td>
<span style="color: #800000">...::::>>>> FDA'S MARKET <<<<::::...</span>
</td></tr>

<tr> <td>
    <span style="font-family: 'Bookman Old Style'; font-weight: bold; font-size: medium; border-left-color: #A0A0A0; border-right-color: #C0C0C0; border-top-color: #A0A0A0; border-bottom-color: #C0C0C0">BIENVENIDO A NUESTRO SITIO DE COMPRAS:</span>
</td></tr>    
<tr> <td>
    Desde Aqui podra realizar todas sus compras con unos simples clics.
</td></tr>        
<tr> <td >    
    <span style="background-color: #9999FF">Visite la seccion CATALOGO para seleccionar los productos que desee.</span>
 </td></tr>       
 <tr> <td style="color: #66CCFF">   
     TIPS: <br />
    *En caso de necesitar adquirir mas de un mismo producto, simplemente 
    haga clic sobre el mismo la cantidad de veces necesarias.

</td></tr>        
<tr> <td>    
   <span style="background-color: #9999FF"> En cualquier momento puede chequear el estado de su compra desde la 
    seccion MI CARRITO. Para confirmar su compra, presione el boton COMPRAR.</span>
</td></tr>        
<tr> <td style="color: #66CCFF">    
    TIPS:<br />
    * Puede consultar el total de su compra con el boton RECALCULAR.<br />
    * Si desea quitar algun item de su carrito, simplemente marque 
        la opcion X y dicho item se eliminara.<br />
    * Luego de eliminar puede actualizar el monto total de su compra
        actual presionando nuevamente el boton RECALCULAR.
</td></tr>                  
 <tr> <td>    
    <span style="background-color: #9999FF"> Finalmente concluir 
     su compra indicando su nombre, apellido, y direccion de correo
     electronico, al completar todos sus datos presione el boton COMPRAR.</span>
</td></tr>    
<tr> <td style="color: #66CCFF">     
     TIPS:<br />
     * Solo se le permitira realizar la compra en caso de que su carrito cuente
         al menos con un item. <br />
     * Se le informara el estado de la transaccion, y luego podra concluir la 
        operacion, con el boton FINALIZAR.
</td></tr>            
<tr> <td style="color: #800000; text-align: center;">        
    ESPERAMOS SEA DE SU AGRADO.
</td></tr>        
<tr> <td style="color: #800000; text-align: right;">    
    ...::::>>>> DESDE YA, MUCHAS GRACIAS POR SU VISITA <<<<::::.....            
</td></tr>        
</table>     

</asp:Content>

