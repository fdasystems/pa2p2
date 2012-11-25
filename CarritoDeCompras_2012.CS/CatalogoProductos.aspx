<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="CatalogoProductos.aspx.cs" Inherits="CarritoDeCompras_2012.CS.CatalogoProductos" MasterPageFile="~/Maestra.Master" %>


<asp:Content ContentPlaceHolderID="ContentImagen" runat="server">
    <asp:Image runat="server" ImageUrl="~/compras.jpg" ToolTip="Catalogo" Height="600px" Width="100%" />    
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentBody" runat="server">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" DataSourceID="ObjectDataSource1" 
                onselectedindexchanged="GenerarCookie" onrowcommand="GridView1_RowCommand" Width="100%" Height="500px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="ObtenerCatalogo" 
                TypeName="CarritoDeCompras_2012.CS.ProxyWS.CatalogoWS">
            </asp:ObjectDataSource>
            <asp:Button ID="Button1" runat="server" Text="Aceptar" 
                onclick="Button1_Click" />
            
</asp:Content>