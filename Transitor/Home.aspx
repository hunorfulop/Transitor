<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Transitor.Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">Home
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <style>
        body{
            background-color:coral;
        }

        .roundedcorner{
            font-size:11pt;
            margin-left:auto;
            margin-right:auto;
            margin-top:1px;
            margin-bottom:1px;
            padding:3px;
            border-top:1px solid;
            border-left:1px solid;
            border-right:1px solid;
            border-bottom:1px solid;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
        }

        .background{
            background-color:black;
            filter:alpha(opacity=90);
            opacity: 0.8;
        }

        .popup{
            background-color: #4CAF50;
            border-width:3px;
            border-style:solid;
            border-color:black;
            padding-top:10px;
            padding-left:10px;
            width:550px;
            overflow : auto ;
            height: 400px; 
        }

    </style>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="lblDevs" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <br />
            <br />
            <br />
        </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="margin-left: auto; margin-right: auto; text-align: right;">
            <asp:Label ID="LabelNotNumber" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="23px" ImageUrl="~/Uploads/bell3.jpg" Width="35px" />

            <asp:Panel ID="Panel" runat="server" CssClass="popup roundedcorner">
                <center>
                <asp:Label ID="Label1" runat="server" Text="New comments on this projects:"></asp:Label>
                    <br />
                </center>
                <br />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#4CAF50"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
                    <Columns>
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="TranslationLanguage" HeaderText="TranslationLanguage" ItemStyle-Width="150px" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btnstyle3" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />


                <center>
                <asp:Label ID="Label2" runat="server" Text="All comments:"></asp:Label>
                    <br />
                </center>

                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand" HeaderStyle-BackColor="#4CAF50"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
                    <Columns>
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="TranslationLanguage" HeaderText="TranslationLanguage" ItemStyle-Width="150px" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btnstyle3" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Button ID="PopupClose" runat="server" Text="Close" OnClick="PopupClose_Click" />
            </asp:Panel>

        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="ImageButton2" PopupControlID="Panel" BackgroundCssClass="background"></ajaxToolkit:ModalPopupExtender>

    </div>

    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body2" runat="server">
    <style>
        body{
            background-color:coral;
        }

         .roundedcorner{
            font-size:11pt;
            margin-left:auto;
            margin-right:auto;
            margin-top:1px;
            margin-bottom:1px;
            padding:3px;
            border-top:1px solid;
            border-left:1px solid;
            border-right:1px solid;
            border-bottom:1px solid;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
        }

        .background{
            background-color:black;
            filter:alpha(opacity=90);
            opacity: 0.8;
        }

        .popup{
            background-color: #4CAF50;
            border-width:3px;
            border-style:solid;
            border-color:black;
            padding-top:10px;
            padding-left:10px;
            width:550px;
            overflow : auto ;
            height: 400px; 
        }

    </style>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="lblTrans" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <br />
        </div>

    <div style="margin-left: auto; margin-right: auto; text-align: right;">
            <asp:Label ID="Label3" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/Uploads/bell3.jpg" Width="35px" />

            <asp:Panel ID="Panel1" runat="server" CssClass="popup roundedcorner">
                <center>
                <asp:Label ID="Label4" runat="server" Text="New comments on this projects:"></asp:Label>
                    <br />
                </center>
                <br />

                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView3_RowCommand" HeaderStyle-BackColor="#4CAF50"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
                    <Columns>
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="TranslationLanguage" HeaderText="TranslationLanguage" ItemStyle-Width="150px" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btnstyle3" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />


                <center>
                <asp:Label ID="Label5" runat="server" Text="All comments:"></asp:Label>
                    <br />
                </center>

                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView4_RowCommand" HeaderStyle-BackColor="#4CAF50"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
                    <Columns>
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="TranslationLanguage" HeaderText="TranslationLanguage" ItemStyle-Width="150px" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btnstyle3" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Button ID="Button1" runat="server" Text="Close" OnClick="PopupClose2_Click" />
            </asp:Panel>

        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="ImageButton1" PopupControlID="Panel1" BackgroundCssClass="background"></ajaxToolkit:ModalPopupExtender>

    </div>

    </asp:Content>