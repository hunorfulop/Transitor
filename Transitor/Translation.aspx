<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Translation.aspx.cs" Inherits="Transitor.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">NewProjectDev
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body2" runat="server">

    <br />
    <br />

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
        </style>

    <div>
        <asp:HiddenField ID="hfComentId" runat="server" />
        <br />
    <asp:Label ID="Label1" runat="server" Text="Select Phrase and translation language:"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="DropDownListPhrases" runat="server" style="width: 150px; max-width: 150px" CssClass="dropdownliststyle"></asp:DropDownList>
        <asp:DropDownList ID="DropDownListTransLanguages" runat="server" CssClass="dropdownliststyle">
        </asp:DropDownList>
        <asp:Button ID="btnSelectPhrase" runat="server" Text="Select" OnClick="btnSelectPhrase_Click" class="btnstyle2"/>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Selected Phrase:"></asp:Label>
        </p>
        <p>
            <textarea id="TextareaPhrase" runat="server" cols="50" name="S1" rows="20"></textarea></p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Selected translation Language: "></asp:Label>
            <asp:Label ID="LabelTransLang" runat="server" Text=""></asp:Label>
        </p>

        <p>
            <asp:Label ID="Label3" runat="server" Text="Translate the phrase here:"></asp:Label>
        </p>
        <p>
            <textarea id="TextareaTranslate" runat="server" cols="50" name="S1" rows="10"></textarea>
            &nbsp;<asp:Button ID="btnTranlate" runat="server" Text="Translate" OnClick="btnTranlate_Click" class="btnstyle2"/>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Translated words/Number of words in selected language: "></asp:Label>
            <asp:Label ID="lblSelectedLangTransNumber" runat="server" Text=""></asp:Label>
            /<asp:Label ID="lblSelectedLangPhraseNumber" runat="server" Text=""></asp:Label>
            </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Translated words/Number of words in total: "></asp:Label>
            <asp:Label ID="lblEveryTransNumber" runat="server" Text=""></asp:Label>
            /<asp:Label ID="lblEveryPhraseNumber" runat="server" Text=""></asp:Label>
            </p>
        <p>
            <asp:Button ID="btnFinishTranslation" runat="server" Text="Submit for checking" OnClick="btnFinishTranslation_Click" class="btnstyle2"/>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddComent" runat="server" Text="Add Coment" class="btnstyle2" OnClick="btnAddComent_Click"/>
       </p>
        <p>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </p>
        <div class="cetered">
            <br />
            <asp:Repeater ID="RepeaterComents" runat="server" visible="false">
                <ItemTemplate>
                    <hr />
                    <asp:Label ID="LabelCom1" runat="server" Text='<%#Eval("OwnerID") %>'></asp:Label>
                    <asp:Label ID="LabeCom2" runat="server" Text='<%#Eval("ComentDate") %>'></asp:Label>
                    <br />
                    <div runat="server" innerText = '<%#Eval("Coment") %>'>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <br />
            <textarea id="TextareaComent" runat="server" name="S1" class="auto-style1" visible="false"></textarea>
            <asp:Button ID="btnSendComent" runat="server" Text="Send Coment" class="btnstyle2" OnClick="btnSendComent_Click" Visible="false"/>
        </div>
        </div>

    </asp:Content>