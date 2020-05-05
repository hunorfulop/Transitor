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
                        <asp:TextBox ID="txtUserName" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Password:" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="22px" />
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
                        <asp:Button Text="Register" ID="btnRegister" runat="server" OnClick="btnRegister_Click" />
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
