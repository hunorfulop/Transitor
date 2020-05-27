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

        .labelstyle {
          color:black;
          font-size:xx-large;
          font-family:'Arial';
          background-color:#4CAF50;
          font-style:italic;
        }

        .labelstyle2 {
          color:black;
          font-size:large;
          font-family:'Arial';
          font-style:italic;
        }

        .btnstyle2 {
            background-color: #4CAF50;
            color: white;
            text-align: center;
            text-decoration: none;
            font-size: 16px;
            cursor: pointer;
            transition-duration: 0.4s;
            border: none;
        }

            .btnstyle2:hover {
                box-shadow: 0 4px 6px 0 rgba(0,0,0,0.17),0 6px 8px 0 rgba(0,0,0,0.18);
                background-color: #FF9933;
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
