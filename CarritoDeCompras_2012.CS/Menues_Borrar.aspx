<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menues_Borrar.aspx.cs" Inherits="CarritoDeCompras_2012.CS.Menues_Borrar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1">
            <DataBindings>
                <asp:MenuItemBinding DataMember="SiteMapNode" TextField="Title" />
            </DataBindings>
        </asp:Menu>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    
    </div>
    </form>
</body>
</html>
