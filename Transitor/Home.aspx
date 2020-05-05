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
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="lblDevs" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <br />
        </div>
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body2" runat="server">
    <style>
        body{
            background-color:coral;
        }
    </style>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="lblTrans" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <br />
        </div>
    </asp:Content>