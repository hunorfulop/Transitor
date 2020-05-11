<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Transitor.Register" %>

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
                <asp:HiddenField ID="hfUserID" runat="server" />
            <table>

                <tr>
                    <td>
                        <asp:Label Text="UserName:" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUserName" runat="server" class="txtboxstyle"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Password:" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="17px" class="txtboxstyle"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Role:" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlRole" runat="server">
                            <asp:ListItem>Developer</asp:ListItem>
                            <asp:ListItem>Translator</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Register" ID="btnRegister" runat="server" OnClick="btnRegister_Click" CssClass="btnstyle" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccesMessage" runat="server" ForeColor="Green"/>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
