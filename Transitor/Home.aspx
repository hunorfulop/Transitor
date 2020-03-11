<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Transitor.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Home
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <style>
        body{
            background-color:coral;
        }
    </style>
        <div>
            <asp:Label ID="lblUserDetails" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnLogout" runat="server" Text="Loggout" OnClick="btnLogout_Click" />
        </div>
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body2" runat="server">
    <style>
        body{
            background-color:coral;
        }
    </style>
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Loggout" OnClick="btnLogout_Click" />
        </div>
    </asp:Content>