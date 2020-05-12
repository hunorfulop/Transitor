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
    </style>



   <div id="d1" >
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#4CAF50"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
        <Columns>
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectFileType" HeaderText="ProjectFileType" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectOriginalLanguage" HeaderText="ProjectOriginalLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="IsSomeoneWorkingOnIt" HeaderText="IsSomeoneWorkingOnIt" ItemStyle-Width="150px" />
            <asp:BoundField DataField="IsItReady" HeaderText="IsItReady" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Progress" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" class="btnstyle3"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    </div>
    </asp:Content>
