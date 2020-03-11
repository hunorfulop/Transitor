<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileReadAndUpload.aspx.cs" Inherits="Transitor.FileReadAndUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfPhraseID" runat="server" />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btn_Upload" runat="server" Text="Upload File" OnClick="btn_Upload_Click" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
