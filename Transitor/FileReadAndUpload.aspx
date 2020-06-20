<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileReadAndUpload.aspx.cs" Inherits="Transitor.FileReadAndUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:#DEF2F1;
        }
    </style>

      <style id="cssStyle" type="text/css" media="all">
          .Cntrl1 {
              background-color: #abcdef;
              color: #17252A;
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
            background-color:#3AAFA9;
            font-family:Courier New;
            font-size:large;
            font-style:italic;
            }

        .labelstyle {
            color: #17252A;
            font-size: xx-large;
            font-family: 'Broadway';
            font-style: italic;
        }
        }

        .labelstyle2 {
            color: #17252A;
            font-size: x-large;
            font-family: 'Broadway';
            font-style: italic;
        }

        .btnstyle2 {
            background-color: #17252A;
            border: 1px solid;
            cursor: pointer;
            color: Silver;
            border-radius: 4px;
        }

            .btnstyle2:hover {
                background-color: #2B7A78;
                box-shadow: 0 0 10px;
                color: Menu;
            }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfPhraseID" runat="server" />
            <br />
            <center>
            <asp:Label ID="Label2" runat="server" Text="Welcome to the file upload page!" Class="labelstyle"></asp:Label>
                <br />
                <br />
                <br />
            </center>
            <br />
            <center>
            <asp:Label ID="Label1" runat="server" Text="Please choose a file: "></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="Cntrl1" />
            <br />
            <br />
            <asp:Button ID="btn_Upload" runat="server" Text="Upload File" OnClick="btn_Upload_Click" CssClass="btnstyle2" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ></asp:Label>
            </center>
            <br />
            <br />
            <center>
            <asp:Label ID="LabelMsg1" runat="server" Text="Please make sure that this are all the phrases which you want to get translated!" visible="false" CssClass="labelstyle2"></asp:Label>
                <br />
                <br />
            <asp:Label ID="LabelMsg2" runat="server" Text="If something is not right please check that your file matches our templates." Visible="false" CssClass="labelstyle2"></asp:Label>
            </center>
            <br />
            <center>
            <asp:ListBox ID="ListBoxPhrases" runat="server" Height="211px" Width="215px" visible="false" CssClass="ListBoxstyle"></asp:ListBox>
                <br />
                <br />
                <asp:Button ID="btn_Confirm" runat="server" Text="Confirm" visible="false" OnClick="btn_Confirm_Click" CssClass="btnstyle2"/>
            </center>
        </div>
    </form>
</body>
</html>
