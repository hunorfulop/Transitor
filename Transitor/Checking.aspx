<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Checking.aspx.cs" Inherits="Transitor.Checking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body2" runat="server">

        <style>
        body{
            background-color:coral;
        }

         .dropdownliststyle
        {
            color: #fff;
            font-size: 15px;
            padding: 5px 10px;
            border-radius: 5px 12px;
            background-color: #4CAF50;
            font-weight: bold;
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

            btnstyle2:hover {
                box-shadow: 0 4px 6px 0 rgba(0,0,0,0.17),0 6px 8px 0 rgba(0,0,0,0.18);
                background-color: #FF9933;
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
          font-size:x-large;
          font-family:'	Arial';
          font-style:italic;
        }
            .auto-style1 {
                width: 430px;
                height: 97px;
            }
    </style>

    <div>
        <center>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Wlecome to the Checking page!" CssClass="labelstyle"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Please select a language:"></asp:Label>
            <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="dropdownliststyle">
            </asp:DropDownList>
            <asp:Button ID="btnSelectLanguage" runat="server" Text="Select" OnClick="btnSelectLanguage_Click" class="btnstyle2"/>
            <br />
            <br />
            </center>
        </div>

        <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#4CAF50"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
        <Columns>
            <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
            <asp:BoundField DataField="TransLanguage" HeaderText="TransLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="TranslatedPhrase" HeaderText="TranslatedPhrase" ItemStyle-Width="150px" />
        </Columns>
    </asp:GridView>
            <br />
            </center>

        <br />
    <center>
        <asp:Label ID="Label2" runat="server" Text="Select the phrase which you want to correct:" Visible="false"></asp:Label>
        <asp:DropDownList ID="ddlPhrases" runat="server" Visible="false" CssClass="dropdownliststyle">
        </asp:DropDownList>
        <asp:Button ID="btnSelectPhrase" runat="server" Text="Select" Visible="false" OnClick="btnSelectPhrase_Click" CssClass="btnstyle2"/>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Correct the phrase here:" Visible="false"></asp:Label>
        <p>
            <textarea id="TextAreaTranslatedPhrase" runat="server" name="S1" Visible="false" class="auto-style1"></textarea>
            </p>
        <p>
            <asp:Button ID="btnCorrect" runat="server" Text="Correct" OnClick="btnCorrect_Click" Visible="false" CssClass="btnstyle2" />
        </p>
        <p>
            <asp:Button ID="btnFinishTrans" runat="server" Text="Finish Translation" Visible="false" OnClick="btnFinishTrans_Click" CssClass="btnstyle2"/>
        </p>
        </center>
        </asp:Content>
