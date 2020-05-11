<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Transitor.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:coral;
        }
    </style>

    <style type="text/css">  
        .btnstyle {
            background-color: #FFCC99; 
            border: 1px solid yellow;
            cursor: pointer; 
            color: Silver;
            border-radius: 4px;
         }

        .btnstyle:hover {
            background-color: #FF9933;
            box-shadow: 0 0 10px #FF99CC;
            color: Menu;
        }

        .btnstyle:active {
            background-color: #FF9933;
            box-shadow: 0 4px #666;
            transform: translateY(5px);
        }

        .txtboxstyle {
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            background: #FFFFFF no-repeat 2px 2px;
            padding: 1px 1px 1px 5px;
            border: 2px solid #FF9933;
        }
    </style> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table style="margin:auto;border:5px solid white">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" class="txtboxstyle"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="txtboxstyle"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" class="btnstyle"/>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" class="btnstyle" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblErrorMessage" runat="server" Text="Inncorect User Credentialls" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
