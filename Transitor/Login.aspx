<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Transitor.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:#3AAFA9;
        }
    </style>

    <style type="text/css">  
        .btnstyle {
            background-color: #17252A; 
            border: 1px solid;
            cursor: pointer; 
            color: Silver;
            border-radius: 4px;
         }

        .btnstyle:hover {
            background-color: #2B7A78;
            box-shadow: 0 0 10px;
            color: Menu;
        }

        .btnstyle:active {
            background-color: #DEF2F1;
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
            border: 2px solid #17252A;
        }

        .labelstyle {
          color:#17252A;
          font-size:xx-large;
          font-family:'Broadway';
          font-style:italic;
        }

        .labelstyle2 {
          color:#17252A;
          font-size:x-large;
          font-family:'Broadway';
          font-style:italic;
        }
    </style> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <center>
            <asp:Label ID="Label3" runat="server" Text="Welcome to Transitor!" CssClass="labelstyle"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Fill the form to log in or if you don't have an account hit the Register button." CssClass="labelstyle2"></asp:Label>
                <br />
                <br />
                <br />
                <br />
            </center>

        <table style="margin: auto; border: 5px solid; border-color: #17252A">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Username:" ForeColor="#FEFFFF"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" class="txtboxstyle"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password:" ForeColor="#FEFFFF"></asp:Label></td>
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
