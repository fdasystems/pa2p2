<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="Carrito.aspx.cs" Inherits="CarritoDeCompras_2012.CS.Carrito" MasterPageFile="~/Maestra.Master" %>
    
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
  
        
    </asp:Content>

