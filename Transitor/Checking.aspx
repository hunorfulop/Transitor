<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checking.aspx.cs" Inherits="Transitor.Checking" %>

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
            <asp:Label ID="Label1" runat="server" Text="Please select a language"></asp:Label>
            <asp:DropDownList ID="ddlLanguage" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnSelectLanguage" runat="server" Text="Select" OnClick="btnSelectLanguage_Click" />
        </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
            <asp:BoundField DataField="TransLanguage" HeaderText="TransLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="TranslatedPhrase" HeaderText="TranslatedPhrase" ItemStyle-Width="150px" />
        </Columns>
    </asp:GridView>

        <asp:Label ID="Label2" runat="server" Text="Select the phrase which you want to correct:" Visible="false"></asp:Label>
        <asp:DropDownList ID="ddlPhrases" runat="server" Visible="false">
        </asp:DropDownList>
        <asp:Button ID="btnSelectPhrase" runat="server" Text="Select" Visible="false" OnClick="btnSelectPhrase_Click"/>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Correct the phrase here" Visible="false"></asp:Label>
        <p>
            <textarea id="TextAreaTranslatedPhrase" runat="server" cols="20" name="S1" rows="2" Visible="false"></textarea>
            <asp:Button ID="btnCorrect" runat="server" Text="Correct" OnClick="btnCorrect_Click" Visible="false" />
        </p>
        <p>
            <asp:Button ID="btnFinishTrans" runat="server" Text="Finish Translation" Visible="false" OnClick="btnFinishTrans_Click"/>
        </p>

    </form>
</body>
</html>
