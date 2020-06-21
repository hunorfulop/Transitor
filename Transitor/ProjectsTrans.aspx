<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectsTrans.aspx.cs" Inherits="Transitor.ProjectsTrans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body2" runat="server">
         <style>
        body{
            background-color:#DEF2F1;
        }

         .dropdownliststyle
        {
            color: #fff;
            font-size: 15px;
            padding: 5px 10px;
            border-radius: 5px 12px;
            background-color: #17252A;
            font-weight: bold;
        }

             .btnstyle2 {
            background-color: #17252A;
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
                background-color: #2B7A78;
             }

             .btnstyle3 {
              display: inline-block;
              cursor: pointer;
              text-align: center;
              outline: 1px;
              color: #fff;
              background-color: #17252A;
              border: none;
              border-radius: 10px;
             }

                 .btnstyle3:hover {
                  background-color: #2B7A78
                 }

             .labelstyle {
              color: #17252A;
              font-size: xx-large;
              font-family: 'Broadway';
              font-style: italic;
             }

             .labelstyle2 {
                 color: black;
                 font-size: x-large;
                 font-family: '	Arial';
                 font-style: italic;
             }

    </style>
    <div id="d1" style="padding:0 16px;">
        <center>
        <br />

            <asp:Label ID="Label1" runat="server" Text="Welcome to the projects menu!" CssClass="labelstyle"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Please select the project type on which you want to work:" CssClass="labelstyle2"></asp:Label>
            <br />
            <br />

        <asp:DropDownList ID="ddlProjectType" runat="server" CssClass="dropdownliststyle">
            <asp:ListItem>Translation Projects</asp:ListItem>
            <asp:ListItem>Checking Projects</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSelectProjectType" runat="server" Text="Select" OnClick="btnSelectProjectType_Click" class="btnstyle2"/>
         <br />
         <br />
         <asp:Label ID="lblMessage" runat="server" Visible="false" CssClass="labelstyle2"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#2B7A78"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#FEFFFF"  RowStyle-ForeColor="#3AAFA9">
        <Columns>
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectOriginalLanguage" HeaderText="ProjectOriginalLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="EstimatedFinishDate" HeaderText="EstimatedFinishDate" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>"  CssClass="btnstyle3"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand" HeaderStyle-BackColor="#2B7A78"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#FEFFFF"  RowStyle-ForeColor="#3AAFA9">
        <Columns>
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectOriginalLanguage" HeaderText="ProjectOriginalLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="EstimatedFinishDate" HeaderText="EstimatedFinishDate" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" class="btnstyle3"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </center>
    </div>
    </asp:Content>