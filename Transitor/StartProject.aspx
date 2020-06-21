<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StartProject.aspx.cs" Inherits="Transitor.StartProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body2" runat="server">

    <style>
        body{
            background-color:#DEF2F1;
        }

        .txtboxstyle {
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            background: #FFFFFF no-repeat 2px 2px;
            padding: 1px 1px 1px 5px;
            border: 2px solid #17252A;
        }

        .ListBoxstyle {
            color:GhostWhite;
            background-color:#3AAFA9;
            font-family:Courier New;
            font-size:large;
            font-style:italic;
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

    <div>
        </div>
        <br />
    <center>
    <asp:Label ID="Label6" runat="server" Text="Welcome to the Start project page!" CssClass="labelstyle"></asp:Label>
        <br />
        <br />
    <asp:Label ID="Label7" runat="server" Text="Here further details are avaliable about a project and it can be started." CssClass="labelstyle2"></asp:Label>
    </center>
    <br />
        <br />
        <table style="border:5px solid; border-color: #17252A">

        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Text="Project name:"></asp:Label>
        <asp:TextBox ID="textBoxProjectName" runat="server" CssClass="txtboxstyle"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Text="ProjectOriginalLanguage:"></asp:Label>
        <asp:TextBox ID="textBoxProjectOriginalLanguage" runat="server" CssClass="txtboxstyle"></asp:TextBox>
        </td>
        </tr>
        
        <tr>
            <td>
               <asp:Label ID="Label3" runat="server" Text="ProjectTranslationLanguage:"></asp:Label>
            </td>
        </tr>

        <tr>
        <td>
        <asp:ListBox ID="ListBoxTransLanguage" runat="server" Height="133px" Width="154px" CssClass="ListBoxstyle"></asp:ListBox>
        </td>
        </tr>
        </table>

        <br />

        <table style="border:5px solid; border-color: #17252A">

        <tr>
        <td>
        <asp:Label ID="Label5" runat="server" Text="Upload date:"></asp:Label>
        <asp:TextBox ID="textBoxUploadDate" runat="server" CssClass="txtboxstyle"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td>
        <asp:Label ID="Label4" runat="server" Text="Please select a finish date:"></asp:Label>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </td>
        </tr>

        </table>

         <br />

         <asp:Label ID="lblErrorMessage" runat="server" Text="Select an end data please" ForeColor="Red"></asp:Label>
        <p>
            <asp:Button ID="btnStartProject" runat="server" Text="Start Project" OnClick="btnStartProject_Click" class="btnstyle2"/>
        </p>


    </asp:Content>