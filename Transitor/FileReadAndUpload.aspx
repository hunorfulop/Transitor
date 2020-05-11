<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileReadAndUpload.aspx.cs" Inherits="Transitor.FileReadAndUpload" %>

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
            <asp:HiddenField ID="hfPhraseID" runat="server" />
            <br />
            <center>
            <asp:Label ID="Label2" runat="server" Text="Welcome to the file upload page!" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <br />
                <br />
                <br />
            </center>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Choose a file please:"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
            <asp:Button ID="btn_Upload" runat="server" Text="Upload File" OnClick="btn_Upload_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ></asp:Label>
        </div>
    </form>
</body>
</html>
