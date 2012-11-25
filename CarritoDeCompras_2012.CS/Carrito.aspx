<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="Carrito.aspx.cs" Inherits="CarritoDeCompras_2012.CS.Carrito" MasterPageFile="~/Maestra.Master" %>
    
    <asp:Content runat="server" ContentPlaceHolderID="ContentBody" >
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </asp:Content>
