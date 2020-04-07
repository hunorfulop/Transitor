<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Translation.aspx.cs" Inherits="Transitor.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
     
    <form id="form1" runat="server">
        <asp:DropDownList ID="DropDownList1" runat="server" style="width: 150px; max-width: 150px"></asp:DropDownList>
        <asp:Button ID="btnSelectPhrase" runat="server" Text="Select Phrase" OnClick="btnSelectPhrase_Click" />
        <p>
            &nbsp;</p>
        <p>
            <textarea id="TextareaPhrase" runat="server" cols="50" name="S1" rows="20"></textarea></p>
        <p>
            &nbsp;</p>
        <p>
            <textarea id="TextareaTranslate" runat="server" cols="50" name="S1" rows="10"></textarea>
            &nbsp;<asp:Button ID="btnTranlate" runat="server" Text="Translate" OnClick="btnTranlate_Click" />
        </p>
    </form>
     
</body>
</html> 
