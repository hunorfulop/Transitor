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
    </style>


         <asp:HiddenField ID="hfComentId" runat="server" />
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Coment Section" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
        </div>

        <asp:Label ID="LabelNoComent" runat="server" Text="There is no coment on this phrase" Visible="false"></asp:Label>

        <div class="cetered">
            <br />
            <asp:Repeater ID="RepeaterComents" runat="server">
                <ItemTemplate>
                    <hr />
                    <asp:Label ID="LabelCom1" runat="server" Text='<%#Eval("ComentOwner") %>'></asp:Label>
                    <asp:Label ID="LabeCom2" runat="server" Text='<%#Eval("ComentDate") %>'></asp:Label>
                    <br />
                    <div runat="server" innerText = '<%#Eval("Coment") %>'>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <br />
            <textarea id="TextareaComent" runat="server" name="S1" class="auto-style1" ></textarea>
            <asp:Button ID="btnSendComent" runat="server" Text="Send Coment" class="btnstyle2" OnClick="btnSendComent_Click" />
        </div>

    </asp:Content>