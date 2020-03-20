﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewProjectTrans.aspx.cs" Inherits="Transitor.NewProjectTrans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body2" runat="server">
    <div id="d1" style="padding:0 16px;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectOriginalLanguage" HeaderText="ProjectOriginalLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectTranslationLanguage" HeaderText="ProjectTranslationLanguage" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    </asp:Content>
