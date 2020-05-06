<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectsDev.aspx.cs" Inherits="Transitor.ProjectsDev" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
         <style>
        body{
            background-color:coral;
        }
    </style>
   <div id="d1" style="padding:0 16px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectFileType" HeaderText="ProjectFileType" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectOriginalLanguage" HeaderText="ProjectOriginalLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="IsSomeoneWorkingOnIt" HeaderText="IsSomeoneWorkingOnIt" ItemStyle-Width="150px" />
            <asp:BoundField DataField="IsItReady" HeaderText="IsItReady" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Progress" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    </div>
    </asp:Content>
