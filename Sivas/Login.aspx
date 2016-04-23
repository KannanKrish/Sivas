<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sivas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="User name : " />
            <asp:TextBox ID="txtUser" runat="server" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password : " />
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
        </div>
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    </form>
</body>
</html>
