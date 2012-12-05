<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="Carrito.aspx.cs" Inherits="CarritoDeCompras_2012.CS.Carrito" MasterPageFile="~/Maestra.Master" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentImagen" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/calc.jpg" ToolTip="Catalogo" Height="600px" Width="100%" />    
</asp:Content>    
    
    
    
    <asp:Content runat="server" ContentPlaceHolderID="ContentBody" >
        <asp:GridView ID="GridView1" runat="server"
                onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="X" ShowSelectButton="True" />
        </Columns>
        </asp:GridView>
        
        
        <asp:Button ID="btnRecalcular" runat="server" onclick="btnRecalcular_Click" Text="Recalcular" />
        <br />
        El Total Recalculado Es:
        <asp:Label ID="total" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnComprar" runat="server" onclick="btnComprar_Click" Text="Comprar" />
    </asp:Content>

