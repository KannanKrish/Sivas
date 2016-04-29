<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sivas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login to Master Access</title>
    <style type="text/css">
        .background {
            background-color: #e9ebcd;
        }

        .backDiv {
            margin-top: 20px;
            margin-left: auto;
            margin-right: auto;
            width: 350px;
            height: 200px;
            box-shadow: #7d85b5 3px 3px 16px;
            background-color: #808080;
            -ms-transform: translateY(50%);
            -moz-transform: translateY(50%);
            -o-transform: translateY(50%);
            -webkit-transform: translateY(50%);
            transform: translateY(50%);
        }

        #Label1 {
            margin: 5px;
            font-size: 12px;
        }

        #Label2 {
            margin: 5px;
            font-size: 12px;
        }

        #txtUser {
            margin-top: 10px;
        }

        #txtPass {
            margin-top: 10px;
        }

        #btnLogin {
            position: relative;
            left: 40%;
            margin-top: 10px;
        }
    </style>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body class="background">
    <form id="form1" runat="server">
        <div class="backDiv">
            <asp:Label CssClass="label label-default" ID="Label1" runat="server" Text="User name : " />
            <asp:TextBox CssClass="form-control" ID="txtUser" runat="server" />
            <br />
            <asp:Label CssClass="label label-default" ID="Label2" runat="server" Text="Password : " />
            <asp:TextBox CssClass="form-control" ID="txtPass" runat="server" TextMode="Password" />
            <asp:Button CssClass="btn btn-default" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        </div>
    </form>
</body>
</html>
<%--  --%>