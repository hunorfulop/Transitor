<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartProject.aspx.cs" Inherits="Transitor.StartProject" %>

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
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Project name:"></asp:Label>
        <asp:TextBox ID="textBoxProjectName" runat="server"></asp:TextBox>
        <div>
        </div>
        <br />
        <asp:Label ID="Label2" runat="server" Text="ProjectOriginalLanguage:"></asp:Label>
        <asp:TextBox ID="textBoxProjectOriginalLanguage" runat="server"></asp:TextBox>
        <div>
        </div>
        <br />
        <asp:Label ID="Label3" runat="server" Text="ProjectTranslationLanguage:"></asp:Label>
        <asp:TextBox ID="textBoxProjectTranslationLanguage" runat="server"></asp:TextBox>
        <div>
        </div>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Upload date:"></asp:Label>
        <asp:TextBox ID="textBoxUploadDate" runat="server"></asp:TextBox>
        <div>
        </div>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Select a finish date:"></asp:Label>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
         <asp:Label ID="lblErrorMessage" runat="server" Text="Select an end data please" ForeColor="Red"></asp:Label>
        <p>
            <asp:Button ID="btnStartProject" runat="server" Text="Start Project" OnClick="btnStartProject_Click" />
        </p>
    </form>
</body>
</html>
