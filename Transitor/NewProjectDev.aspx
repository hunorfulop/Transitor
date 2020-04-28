<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewProjectDev.aspx.cs" Inherits="Transitor.NewProjectDev" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <style>
        body{
            background-color:coral;
        }
    </style>
   <div>
                <asp:HiddenField ID="hfProjectID" runat="server" />
            <table>

                <tr>
                    <td>
                        <asp:Label Text="Project Name" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProjectName" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />                       
                        <asp:TextBox ID="TextBox1" runat="server" Height="23px"></asp:TextBox>
                        
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Uploaded file type" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlUploadedFileType" runat="server">
                            <asp:ListItem>Xml</asp:ListItem>
                            <asp:ListItem>Txt</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label Text="Original language" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlOriginalLanguage" runat="server">
                            <asp:ListItem>English</asp:ListItem>
                            <asp:ListItem>Romanian</asp:ListItem>
                            <asp:ListItem>Hungarian</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                   <tr>
                    <td>
                        <asp:Label Text="Translation language" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTranslationLanguage" runat="server">
                            <asp:ListItem>English</asp:ListItem>
                            <asp:ListItem>Romanian</asp:ListItem>
                            <asp:ListItem>Hungarian</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Upload" ID="btnRegister" runat="server" OnClick="btnRegister_Click" />
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
    </asp:Content>