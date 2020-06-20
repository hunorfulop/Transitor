<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectsDev.aspx.cs" Inherits="Transitor.ProjectsDev" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
         <style>
        body{
            background-color:#DEF2F1;
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
                 color: #17252A;
                 font-size: x-large;
                 font-family: 'Broadway';
                 font-style: italic;
             }

    </style>



   <div id="d1" >
        <br />

       <center>
           <br />
           <asp:Label ID="Label1" runat="server" Text="Welcome to the Projects page!" CssClass="labelstyle"></asp:Label>
           <br />
           <br />
           <br />
           <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#2B7A78"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#FEFFFF"  RowStyle-ForeColor="#3AAFA9">
        <Columns>
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectFileType" HeaderText="ProjectFileType" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ProjectOriginalLanguage" HeaderText="ProjectOriginalLanguage" ItemStyle-Width="150px" />
            <asp:BoundField DataField="IsSomeoneWorkingOnIt" HeaderText="IsSomeoneWorkingOnIt" ItemStyle-Width="150px" />
            <asp:BoundField DataField="IsItReady" HeaderText="IsItReady" ItemStyle-Width="150px" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Progress" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" class="btnstyle3"/>
                    <asp:Button Text="Delete" runat="server" CommandName="Delete" CommandArgument="<%# Container.DataItemIndex %>" class="btnstyle3"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </center>

       <center>
        <asp:Label ID="LabelEmptyMessage" runat="server" Text="You have no projects! If you want to create one please visit the NewProject menu" Visible="false" ForeColor="#17252A"></asp:Label>
           <br />
           <br />
           <br />
           <br />
       </center>

       <center>
           <table>
               <tr>
                   <td>
                       <center>
                       <asp:Label ID="Label2" runat="server" Text="On this page all of you'r projects are listed." Visible="false" CssClass="labelstyle2"></asp:Label>
                        </center>
                   </td>
               </tr>

               <tr>
                   <td>
                       <center>
                       <asp:Label ID="Label3" runat="server" Text="You can navigate to the Translation progress page from here or you can delete the projects!" Visible="false" CssClass="labelstyle2"></asp:Label>
                       </center>
                   </td>
               </tr>

           </table>
       </center>

    </div>
    </asp:Content>
