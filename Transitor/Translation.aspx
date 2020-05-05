<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Translation.aspx.cs" Inherits="Transitor.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <style>
        body{
            background-color:coral;
        }
    </style>
     
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Phrases:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" style="width: 150px; max-width: 150px"></asp:DropDownList>
        <asp:Button ID="btnSelectPhrase" runat="server" Text="Select Phrase" OnClick="btnSelectPhrase_Click" />
        <br />
        <p>
            <asp:Label ID="Label2" runat="server" Text="Selected Phrase:"></asp:Label>
        </p>
        <p>
            <textarea id="TextareaPhrase" runat="server" cols="50" name="S1" rows="20"></textarea></p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Translate the phrase here:"></asp:Label>
        </p>
        <p>
            <textarea id="TextareaTranslate" runat="server" cols="50" name="S1" rows="10"></textarea>
            &nbsp;<asp:Button ID="btnTranlate" runat="server" Text="Translate" OnClick="btnTranlate_Click" />
        </p>
        <p>
            <asp:Label ID="lblTransNumber" runat="server" Text=""></asp:Label>
            /<asp:Label ID="lblEveryPhraseNumber" runat="server" Text=""></asp:Label>
            </p>
        <p>
            <asp:Button ID="btnFinishTranslation" runat="server" Text="Finish Translation" OnClick="btnFinishTranslation_Click" />
            </p>
        <p>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </p>
    </form>
     
</body>
</html> 
