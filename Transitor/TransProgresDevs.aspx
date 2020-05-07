<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransProgresDevs.aspx.cs" Inherits="Transitor.TransProgresDevs" %>

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
    <div id="d1" style="padding:0 16px;">
       <center>

           <asp:DropDownList ID="ddlTransLanguage" runat="server">
           </asp:DropDownList>
           <asp:Button ID="btnTransLanguage" runat="server" Text="Select Language" OnClick="btnTransLanguage_Click" />

       <asp:ListView ID="ListViewPhrasesDev" runat="server" GroupPlaceholderID="groupplaceholder" ItemPlaceholderID="itemplaceholder">
            <LayoutTemplate>
                <table border="1">
                    <tr>
                        <th>Phrase</th>
                        <th>TranslatedPhrase</th>
                    </tr>
                    <tr id="groupplaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>
           <GroupTemplate>
               <tr>
                   <tr id="itemplaceholder" runat="server"></tr>
               </tr>
           </GroupTemplate>
           <ItemTemplate>
               <td><%# Eval("Phrase") %></td>
               <td><%# Eval("TranslatedPhrase") %></td>
           </ItemTemplate>
       </asp:ListView>

           <asp:Label ID="LabelPercentage" runat="server" Text=""></asp:Label>


       </center>
    </div>
    </form>
</body>
</html>
