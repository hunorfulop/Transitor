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

      <style id="cssStyle" type="text/css" media="all">
       .Cntrl1
      {
       background-color:#abcdef;
       color: #4CAF50;
       border: 1px solid #AB00CC;
       font: Verdana 10px;
       padding: 1px 4px;
       font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
      }
    </style>

    <style type="text/css">
        .ListBoxstyle
        {
            color:GhostWhite;
            background-color:#4CAF50;
            font-family:Courier New;
            font-size:large;
            font-style:italic;
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
            <asp:Label ID="Label1" runat="server" Text="Choose a file please: "></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="Cntrl1" />
            <br />
            <br />
            <asp:Button ID="btn_Upload" runat="server" Text="Upload File" OnClick="btn_Upload_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ></asp:Label>
            <br />
            <br />
            <center>
            <asp:Label ID="LabelMsg1" runat="server" Text="Please make sure that this are all the phrases which you want to get translated!" visible="false"></asp:Label>
                <br />
            <asp:Label ID="LabelMsg2" runat="server" Text="If something is not right please check that your file matches our templates." Visible="false"></asp:Label>
            </center>
            <br />
            <center>
            <asp:ListBox ID="ListBoxPhrases" runat="server" Height="211px" Width="215px" visible="false" CssClass="ListBoxstyle"></asp:ListBox>
                <br />
                <br />
                <asp:Button ID="btn_Confirm" runat="server" Text="Confirm" visible="false" OnClick="btn_Confirm_Click"/>
            </center>
        </div>
    </form>
</body>
</html>
