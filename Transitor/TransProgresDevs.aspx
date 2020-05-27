<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransProgresDevs.aspx.cs" Inherits="Transitor.TransProgresDevs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

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
          font-size:large;
          font-family:'Arial';
          font-style:italic;
        }

    </style>

    <div id="d1" style="padding:0 16px;">
       <center>

           <br />

           <asp:Label ID="Label1" runat="server" Text="Welcome to the Translation progress page!" CssClass="labelstyle"></asp:Label>
           <br />
           <br />

           <asp:Label ID="Label2" runat="server" Text="Please select a language in which you want to see the translations progress:" CssClass="labelstyle2"></asp:Label>
           <br />
           <br />

           <asp:DropDownList ID="ddlTransLanguage" runat="server" CssClass="dropdownliststyle">
           </asp:DropDownList>
           <asp:Button ID="btnTransLanguage" runat="server" Text="Select Language" OnClick="btnTransLanguage_Click" class="btnstyle2"/>

           <br />
           <br />

       <asp:ListView ID="ListViewPhrasesDev" runat="server" GroupPlaceholderID="groupplaceholder" ItemPlaceholderID="itemplaceholder" >
            <LayoutTemplate>
                <table border="1">
                    <tr>
                        <th>Phrase</th>
                        <th>TranslatedPhrase</th>
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
               <td><%# Eval("Phrase") %></td>
               <td><%# Eval("TranslatedPhrase") %></td>
           </ItemTemplate>
       </asp:ListView>

           <br />

           <asp:Label ID="LabelSelectedLanguagePercentage" runat="server" Text=""></asp:Label>
           <br />
           <asp:Label ID="LabelPercentage" runat="server" Text=""></asp:Label>
           <br />
           <br />
           <asp:Label ID="LabelIsItChecked" runat="server" Text=""></asp:Label>


           <br />
           <br />
           <asp:Button ID="btnDownload" runat="server" Text="Download" class="btnstyle2" Visible="false" OnClick="btnDownload_Click"/>


           <br />


           <br />
           <br />
       </center>
    </div>

      </asp:Content>

