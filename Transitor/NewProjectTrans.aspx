<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewProjectTrans.aspx.cs" Inherits="Transitor.NewProjectTrans" %>

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

            .btnstyle3 {
           display: inline-block;
           cursor: pointer;
           text-align: center;
           outline: 1px;
           color: #fff;
           background-color: #b5dfb7;
           border: none;
           border-radius: 10px;
         }

         .btnstyle3:hover {
            background-color: #4CAF50
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

    </style>
    <div id="d1" style="padding:0 16px;">
        <br />
        <center>
        <asp:Label ID="Label1" runat="server" Text="Welcome to the New project page!" CssClass="labelstyle"></asp:Label>
            <br />
            <br />
            <br />
        <asp:Label ID="Label2" runat="server" Text="Please select which type of project would you like to work on:" CssClass="labelstyle2"></asp:Label>
        </center>
        <br />
        <br />

        <center>
        <asp:DropDownList ID="ddlProjectType" runat="server" CssClass="dropdownliststyle">
            <asp:ListItem>New Project</asp:ListItem>
            <asp:ListItem>Check a Project</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSelectProjectType" runat="server" Text="Select" OnClick="btnSelectProjectType_Click" class="btnstyle2"/>
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Visible="false"  CssClass="labelstyle2"></asp:Label>

            <br />
            <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#4CAF50"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
        <Columns>
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectOriginalLanguage" HeaderText="ProjectOriginalLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="UploadDate" HeaderText="UploadDate" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btnstyle3" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </center>

    </div>
    </asp:Content>
