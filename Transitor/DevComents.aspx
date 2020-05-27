<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DevComents.aspx.cs" Inherits="Transitor.DevComents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
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
          font-size:x-large;
          font-family:'	Arial';
          font-style:italic;
        }
        .auto-style1 {
            width: 425px;
            height: 73px;
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
    </style>


         <asp:HiddenField ID="hfComentId" runat="server" />
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Welcome to the comment page!" class="labelstyle"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelName" runat="server" Text="" class="labelstyle2"></asp:Label>
        </div>

        <asp:Label ID="LabelNoComent" runat="server" Text="There is no coment on this phrase" Visible="false"></asp:Label>

        <div class="cetered">
            <br />
            <asp:Repeater ID="RepeaterComents" runat="server">
                <ItemTemplate>
                    <hr />
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text='<%#Eval("MsgForDev") %>'></asp:Label>
                    <br />
                    <asp:Label ID="LabelCom1" runat="server" Text='<%#Eval("ComentOwner") %>'></asp:Label>
                    <asp:Label ID="LabeCom2" runat="server" Text='<%#Eval("ComentDate") %>'></asp:Label>
                    <br />
                    <div runat="server" innerText = '<%#Eval("Coment") %>'>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <br />
            <center>
            <textarea id="TextareaComent" runat="server" name="S1" class="auto-style1" ></textarea>
            <asp:Button ID="btnSendComent" runat="server" Text="Send Coment" class="btnstyle2" OnClick="btnSendComent_Click"/>
            </center>
        </div>

    </asp:Content>