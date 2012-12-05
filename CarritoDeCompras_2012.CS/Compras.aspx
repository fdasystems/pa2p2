<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs"  MasterPageFile="~/Maestra.Master" Inherits="CarritoDeCompras_2012.CS.Compras" %>


    
<asp:Content ID="ContentI" ContentPlaceHolderID="ContentImagen" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/fincompra.jpg" ToolTip="Catalogo" Height="600px" Width="100%" />    
</asp:Content>    
    
    
    
    <asp:Content ID="ContentB" runat="server" ContentPlaceHolderID="ContentBody" >


        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                Nombre:
                </asp:TableCell>
                
                <asp:TableCell>
                    <asp:TextBox ID="nom" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Requerido" Display="Dynamic" ControlToValidate="nom" SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                 </asp:TableCell>
            
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                Apellido:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ape" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Requerido" Display="Dynamic" ControlToValidate="ape" SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                </asp:TableCell>                
                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                Email:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="mail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Requerido" Display="Dynamic" ControlToValidate="mail" SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ErrorMessage="Debe Ingresar Una Direccion De E-Mail Correcta" ControlToValidate="mail" 
                    ValidationExpression="^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$"  ></asp:RegularExpressionValidator>
                
                </asp:TableCell>                
                
            </asp:TableRow>
        </asp:Table>


        <br />
        <asp:Button ID="btnComprar" runat="server" onclick="btnComprar_Click" Text="Comprar" />
    </asp:Content>

