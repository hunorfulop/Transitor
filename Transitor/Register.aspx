<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Transitor.Register" %>

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
            color: #17252A;
            font-size: xx-large;
            font-family: 'Broadway';
            font-style: italic;
        }

        .Cntrl1 {
            background-color: #abcdef;
            color: #4CAF50;
            border: 1px solid #AB00CC;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        .dropdownliststyle
        {
            color: #fff;
            font-size: 15px;
            padding: 5px 10px;
            border-radius: 5px 12px;
            background-color: #17252A;
            font-weight: bold;
        }

        .labelstyle2 {
            color: #17252A;
            font-size: x-large;
            font-family: 'Arial';
            font-style: italic;
        }

        .auto-style1 {
            margin-bottom: 0px;
        }

    </style> 
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <br />
            <center>
            <asp:Label ID="Label1" runat="server" Text="Welcome to the Registration page!" CssClass="labelstyle"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </center>
            <asp:Label ID="Label2" runat="server" Text="Please fill out every field, choose you'r role and a profile picture!" CssClass="labelstyle2"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Make sure that you choose a password which is 8 characters long, contains letteres and numbers as well!" CssClass="labelstyle2"></asp:Label>
        </p>
        <hr color="#17252A"/>
        <div>
                <asp:HiddenField ID="hfUserID" runat="server"/>
            <table>

                <tr>
                    <td>
                        <asp:Label Text="UserName:" runat="server" ForeColor="#FEFFFF"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUserName" runat="server" class="txtboxstyle"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Password:" runat="server" ForeColor="#FEFFFF"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="17px" class="txtboxstyle"/>
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Role:" runat="server" ForeColor="#FEFFFF"/>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="dropdownliststyle">
                            <asp:ListItem>Developer</asp:ListItem>
                            <asp:ListItem>Translator</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                </table>

                <br />
                <hr color="#17252A"/>
                <br />

                <table>
                <tr>
                    <td>
                        <asp:Label Text="Preview of you'r profile picture:" ID="LabelMessageImage" runat="server" ForeColor="#FEFFFF"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" Height="100" Width="100" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Height="22px" class="Cntrl1" CssClass="auto-style1" />
                    </td>
                    <td>
                        <asp:Button Text="Upload picture" ID="btnBrowsePicture" runat="server" OnClick="btnBrowsePicture_Click" CssClass="btnstyle" />
                    </td>
                </tr>
                </table>

                <br />
                <hr color="#17252A"/>
                <br />

                <table>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Register" ID="btnRegister" runat="server" OnClick="btnRegister_Click" CssClass="btnstyle" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccesMessage" runat="server" ForeColor="#FEFFFF"/>
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
        <input id="Hidden1" type="hidden"  runat="server"  value=""/>
    </form>
</body>
</html>
