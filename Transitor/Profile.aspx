<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Transitor.Profile" %>

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
        
    <table style="border:5px solid green">

        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
        <asp:TextBox ID="textBoxUserName" runat="server"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Text="Role:"></asp:Label>
        <asp:TextBox ID="textBoxRole" runat="server" CssClass="txtboxstyle"></asp:TextBox>
        </td>
        </tr>
        
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" Height="100" Width="100" />
            </td>
        </tr>
        </table>

    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body2" runat="server">
    <style>
        body{
            background-color:coral;
        }
    </style>

        <table style="border:5px solid green">

        <tr>
        <td>
        <asp:Label ID="Label3" runat="server" Text="UserName:"></asp:Label>
        <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td>
        <asp:Label ID="Label4" runat="server" Text="Role:"></asp:Label>
        <asp:TextBox ID="textBox2" runat="server" CssClass="txtboxstyle"></asp:TextBox>
        </td>
        </tr>
        
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" Height="100" Width="100" />
            </td>
        </tr>
        </table>

    </asp:Content>