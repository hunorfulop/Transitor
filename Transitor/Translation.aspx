<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Translation.aspx.cs" Inherits="Transitor.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/> 
    <style>
        body {
          font-family: Arial;
          color: white;
        }

        .split {
          height: 100%;
          width: 50%;
          position: fixed;
          z-index: 1;
          top: 0;
          overflow-x: hidden;
          padding-top: 20px;
        }

        .left {
          left: 0;
          background-color: #111;
        }

        .right {
          right: 0;
          background-color: red;
        }

        .centered {
          position: absolute;
          top: 50%;
          left: 50%;
          transform: translate(-50%, -50%);
          text-align: center;
        }

        .centered img {
          width: 150px;
          border-radius: 50%;
        }
        </style>
</head>
<body>

    <div class="split left">
      <div class="centered">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
      </div>
    </div>

    <div class="split right">
      <div class="centered">
        <asp:TextBox ID="TextBoxPhrase" runat="server"></asp:TextBox>
        <asp:Label ID="LabelTranslatedPhrase" runat="server" Text="Translate the pharese here"></asp:Label>
        <asp:TextBox ID="TextBoxTranslatedPhrase" runat="server"></asp:TextBox>
        <p>
          <asp:Button ID="btnTranslate" runat="server" Text="Translate" />
        </p>
      </div>
    </div>
     
</body>
</html> 
