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
            width:525px;
            overflow : auto ;
            height: 400px; 
        }

                .btnstyleclose {
            background-color: red;
            color: white;
            text-align: center;
            text-decoration: none;
            font-size: 16px;
            cursor: pointer;
            transition-duration: 0.4s;
            border: none;
         }

            .btnstyleclose:hover {
                box-shadow: 0 4px 6px 0 rgba(0,0,0,0.17),0 6px 8px 0 rgba(0,0,0,0.18);
                background-color: #FF9933;
            }

                  .btnstyle3 {
           display: inline-block;
           cursor: pointer;
           text-align: center;
           outline: 1px;
           color: #fff;
           background-color: #b5dfb7;
           border: none;
           border-radius: 10px;
         }

         .btnstyle3:hover {
            background-color: #4CAF50
         }

        .labelstyle2 {
          color:black;
          font-size:large;
          font-family:'Arial';
          font-style:italic;
        }
    </style>

        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <br />
            <br />
            <asp:Label ID="lblDevs" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <br />
            <br />
            <br />
            <div style="margin-left: auto; margin-right: auto; text-align: right;">
            <asp:Label ID="LabelNotNumber" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="29px" ImageUrl="~/Icons/imbox.png" Width="36px"/>
                <br />
           </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="ResLabel1" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
            <br />
            <asp:Label ID="ResLabel2" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
            <br />
            <asp:Label ID="ResLabel3" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

    <asp:Label ID="ResLabel4" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="ResLabel5" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
        <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ResLabel6" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
         <asp:HyperLink  Target="_blank" runat="server" ID="linkXmlPdf" Text=" Open Xml template PDF"
                 NavigateUrl="~/PdfTemplates/Xml file template.pdf"></asp:HyperLink>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="ResLabel7" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="ResLabel8" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
     <asp:HyperLink  Target="_blank" runat="server" ID="linkResXPdf" Text=" Open ResX template PDF"
                 NavigateUrl="~/PdfTemplates/ResX file template.pdf"></asp:HyperLink>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="margin-left: auto; margin-right: auto; text-align: right;">
            <br />
            <br />
            <asp:Panel ID="Panel" runat="server" CssClass="popup roundedcorner">
                <center>
                <asp:Label ID="Label1" runat="server" Text="New comments on this projects:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Labelhiden1" runat="server" Text="There are no new comments!" visible="false" ForeColor="Red"></asp:Label>
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

                <hr></hr>

                <center>
                <asp:Label ID="Label2" runat="server" Text="All previous projects which contain comments:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Labelhiden2" runat="server" Text="There are no comments!" visible="false" ForeColor="Red"></asp:Label>
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
                <br />
                <br />
                <asp:Button ID="PopupClose" runat="server" Text="Close" OnClick="PopupClose_Click"  class="btnstyleclose"/>
            </asp:Panel>

        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="ImageButton2" PopupControlID="Panel" BackgroundCssClass="background"></ajaxToolkit:ModalPopupExtender>

    </div>
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body2" runat="server">
    <style>
        body {
            background-color: coral;
        }

        .roundedcorner {
            font-size: 11pt;
            margin-left: auto;
            margin-right: auto;
            margin-top: 1px;
            margin-bottom: 1px;
            padding: 3px;
            border-top: 1px solid;
            border-left: 1px solid;
            border-right: 1px solid;
            border-bottom: 1px solid;
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
            width:525px;
            overflow : auto ;
            height: 400px; 
        }

         .btnstyleclose2 {
            background-color: red;
            color: white;
            text-align: center;
            text-decoration: none;
            font-size: 16px;
            cursor: pointer;
            transition-duration: 0.4s;
            border: none;
         }

            .btnstyleclose2:hover {
                box-shadow: 0 4px 6px 0 rgba(0,0,0,0.17),0 6px 8px 0 rgba(0,0,0,0.18);
                background-color: #FF9933;
            }

                  .btnstyle3 {
           display: inline-block;
           cursor: pointer;
           text-align: center;
           outline: 1px;
           color: #fff;
           background-color: #b5dfb7;
           border: none;
           border-radius: 10px;
         }

         .btnstyle3:hover {
            background-color: #4CAF50
         }

        .labelstyle3 {
          color:black;
          font-size:large;
          font-family:'Arial';
          font-style:italic;
        }

    </style>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <br />
            <br />
            <asp:Label ID="lblTrans" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <br />
            <br />
            <br />
            <div style="margin-left: auto; margin-right: auto; text-align: right;">
            <asp:Label ID="LabeNotNumberTrans" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="29px" ImageUrl="~/Icons/imbox.png" Width="36px"/>
            <br />
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="ResLabelTrans1" runat="server" Text="" CssClass="labelstyle3"></asp:Label>
            <br />
            <asp:Label ID="ResLabelTrans2" runat="server" Text="" CssClass="labelstyle3"></asp:Label>
            <br />
            <asp:Label ID="ResLabelTrans3" runat="server" Text="" CssClass="labelstyle3"></asp:Label>
        </div>

    <div style="margin-left: auto; margin-right: auto; text-align: right;">
            <br />
            <asp:Panel ID="Panel1" runat="server" CssClass="popup roundedcorner">
                <center>
                <asp:Label ID="Label4" runat="server" Text="New comments on this projects:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Labelhiden3" runat="server" Text="There are no new comments!" visible="false" ForeColor="Red"></asp:Label>
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

               <hr></hr>

                <center>
                <asp:Label ID="Label5" runat="server" Text="All comments:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Labelhiden4" runat="server" Text="There are no comments!" visible="false" ForeColor="Red"></asp:Label>
                </center>

                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView4_RowCommand" HeaderStyle-BackColor="#4CAF50"
                    HeaderStyle-ForeColor="White" RowStyle-BackColor="#b5dfb7"  RowStyle-ForeColor="#3A3A3A">
                    <Columns>
                        <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="Phrase" HeaderText="Phrase" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="TranslationLanguage" HeaderText="TranslationLanguage" ItemStyle-Width="150px" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btnstyle3"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Close" OnClick="PopupClose2_Click" class="btnstyleclose2"/>
            </asp:Panel>

        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="ImageButton1" PopupControlID="Panel1" BackgroundCssClass="background"></ajaxToolkit:ModalPopupExtender>

    </div>

    </asp:Content>