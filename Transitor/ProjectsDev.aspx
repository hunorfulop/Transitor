<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectsDev.aspx.cs" Inherits="Transitor.ProjectsDev" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
   <div id="d1" style="padding:0 16px;">
       <center>
       <asp:ListView ID="ListViewProjectsDev" runat="server" GroupPlaceholderID="groupplaceholder" ItemPlaceholderID="itemplaceholder">
            <LayoutTemplate>
                <table border="1">
                    <tr>
                        <th>ProjectName</th>
                        <th>ProjectFileType</th>
                        <th>ProjectOriginalLanguage</th>
                        <th>ProjectTranslationLanguage</th>
                    </tr>
                    <tr id="groupplaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>
           <GroupTemplate>
               <tr>
                   <tr id="itemplaceholder" runat="server"></tr>
               </tr>
           </GroupTemplate>
           <ItemTemplate>
               <td><%# Eval("ProjectName") %></td>
               <td><%# Eval("ProjectFileType") %></td>
               <td><%# Eval("ProjectOriginalLanguage") %></td>
               <td><%# Eval("ProjectTranslationLanguage") %></td>
           </ItemTemplate>
       </asp:ListView>
       </center>
    </div>
    </asp:Content>
