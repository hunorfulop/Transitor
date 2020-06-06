﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Transitor.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Home
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <style>
        body{
            background-color:coral;
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

        .btnstyle1 {
            background-color: #FFCC99;
            border: 1px solid yellow;
            cursor: pointer;
            color: Silver;
            border-radius: 4px;
        }

            .btnstyle1:hover {
                background-color: #FF9933;
                box-shadow: 0 0 10px #FF99CC;
                color: Menu;
            }

            .btnstyle1:active {
                background-color: #FF9933;
                box-shadow: 0 4px #666;
                transform: translateY(5px);
            }
    </style>
        
    <br />
    <center>
    <asp:Label ID="LabelTitelDevs" runat="server" Text="Welcome to the profile page:" CssClass="labelstyle"></asp:Label>
    </center>
    <br />
    <br />
        
    <br />
        
    <table style="border:5px solid green" class="auto-style1">

        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
        <asp:TextBox ID="textBoxUserName" runat="server" Height="22px"></asp:TextBox>
        </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Change UserName" OnClick="ButtonDevs_Click" class="btnstyle"/>
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

        <tr>
            <td>
                <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red"/>
            </td>
        </tr>
        </table>

    <br />
    <br />
    <hr />
    <br />
    <asp:Label Text="You can change you'r password here:" ID="Label5" runat="server" class="labelstyle2"/>
    <br />
    <br />
    <asp:Label Text="Old password: " ID="Label6" runat="server" class="labelstyle2"/>
    <asp:TextBox ID="textBoxOldPasswordDevs" runat="server" CssClass="txtboxstyle" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label Text="New password: " ID="Label7" runat="server" class="labelstyle2"/>
    <asp:TextBox ID="textBoxNewPasswordDevs" runat="server" CssClass="txtboxstyle" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label Text="Confirm New password: " ID="Label8" runat="server" class="labelstyle2"/>
    <asp:TextBox ID="textBoxConfirmNewPasswordDevs" runat="server" CssClass="txtboxstyle" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label Text="" ID="lblErrorMessagePassDev" runat="server" ForeColor="Red"/>
    <br />
    <br />
    <asp:Button ID="ChangePasswordDevs" runat="server" Text="Change Password" class="btnstyle" OnClick="ChangePasswordDevs_Click"/>
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body2" runat="server">
    <style>
        body{
            background-color:coral;
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

        .btnstyle1 {
            background-color: #FFCC99;
            border: 1px solid yellow;
            cursor: pointer;
            color: Silver;
            border-radius: 4px;
        }

            .btnstyle1:hover {
                background-color: #FF9933;
                box-shadow: 0 0 10px #FF99CC;
                color: Menu;
            }

            .btnstyle1:active {
                background-color: #FF9933;
                box-shadow: 0 4px #666;
                transform: translateY(5px);
            }
    </style>

    <br />
    <center>
    <asp:Label ID="LabelTitelDevs0" runat="server" Text="Welcome to the profile page:" CssClass="labelstyle"></asp:Label>
    </center>
    <br />
    <br />      
    <br />

        <table style="border:5px solid green">

        <tr>
        <td>
        <asp:Label ID="Label3" runat="server" Text="UserName:"></asp:Label>
        <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
        </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Change UserName" OnClick="ButtonTrans_Click" class="btnstyle"/>
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
            <tr>
            <td>
                <asp:Label Text="" ID="lblErrorMessageTrans" runat="server" ForeColor="Red"/>
            </td>
        </tr>
        </table>
    <br />
    <br />
    <hr />
    <br />
    <asp:Label Text="You can change you'r password here:" ID="Label9" runat="server" class="labelstyle2"/>
    <br />
    <br />
    <asp:Label Text="Old password: " ID="Label10" runat="server" class="labelstyle2"/>
    <asp:TextBox ID="textBoxOldPasswordTrans" runat="server" CssClass="txtboxstyle" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label Text="New password: " ID="Label11" runat="server" class="labelstyle2"/>
    <asp:TextBox ID="textBoxNewPasswordTrans" runat="server" CssClass="txtboxstyle" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label Text="Confirm New password: " ID="Label12" runat="server" class="labelstyle2"/>
    <asp:TextBox ID="textBoxConfirmNewPasswordTrans" runat="server" CssClass="txtboxstyle" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label Text="" ID="lblErrorMessageTransPass" runat="server" ForeColor="Red"/>
    <br />
    <br />
    <asp:Button ID="Button3" runat="server" Text="Change Password" class="btnstyle" OnClick="ChangePasswordTrans_Click"/>

    </asp:Content>