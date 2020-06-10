<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewProjectDev.aspx.cs" Inherits="Transitor.NewProjectDev" %>

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

    <style type="text/css">
        .txtboxstyle {
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            background: #FFFFFF no-repeat 2px 2px;
            padding: 1px 1px 1px 5px;
            border: 2px solid #FF9933;
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

        .checkboxliststyle
        {
            font-family:Bell MT;
            color:#4CAF50;
            font-style:normal;
            font-weight:bold;
            font-size:large;
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

            .btnstyle2:hover {
                box-shadow: 0 4px 6px 0 rgba(0,0,0,0.17),0 6px 8px 0 rgba(0,0,0,0.18);
                background-color: #FF9933;
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
    </style>

   <div>
                <asp:HiddenField ID="hfProjectID" runat="server" />
                <asp:HiddenField ID="hfTranslationLanguageID" runat="server" />

                <br />
                <center>
                <asp:Label ID="Label1" runat="server" Text="Welcome to the project creation page!" CssClass="labelstyle"></asp:Label>
                    <br />
                <asp:Label ID="Label2" runat="server" Text="Set up you'r project and click the upload button to advance!" CssClass="labelstyle2"></asp:Label>
                    <br />
                    <br />
                </center>
                <br />

            <table style="border:5px solid green">

                <tr>
                    <td>

                    </td>
                </tr>

                <tr>
                    <td>

                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Project Name:" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProjectName" runat="server" class="txtboxstyle" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />                       
                    </td>
                </tr>
                 
                <tr>
                    <td>

                    </td>
                </tr>

                <tr>
                    <td>

                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Uploaded file type:" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlUploadedFileType" runat="server" class="dropdownliststyle">
                            <asp:ListItem>.xml</asp:ListItem>
                            <asp:ListItem>.resx</asp:ListItem>
                            <asp:ListItem>.csv</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

               <tr>
                    <td>

                    </td>
                </tr>

               <tr>
                    <td>

                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label Text="Original language:" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlOriginalLanguage" runat="server"  class="dropdownliststyle">
                            <asp:ListItem>English</asp:ListItem>
                            <asp:ListItem>Romanian</asp:ListItem>
                            <asp:ListItem>Hungarian</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>

                    </td>
                </tr>

               <tr>
                    <td>

                    </td>

                    <td>

                    </td>

                    <td>

                    </td>


                </tr>
               </table>

               <table style="                       border: 5px solid green">

                   <tr>
                    <td>
                        <asp:Label Text="Translation language:" runat="server" />
                    </td>
                <br />
                    <td colspan="2">
                        <asp:CheckBoxList ID="CheckBoxLisTransLanguages" runat="server" class="checkboxliststyle">
                            <asp:ListItem Text="English" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Romanian" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Hungarian" Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>

                    <td colspan="2">
                        &nbsp;</td>
                </tr>

                <tr>
                    <td>

                    </td>
                </tr>

                <tr>
                    <td>

                    </td>
                </tr>
                </table>

                <br />

                <table>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Upload" ID="btnRegister" runat="server" OnClick="btnRegister_Click" class="btnstyle2"/>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccesMessage" runat="server" ForeColor="Green"/>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red"/>
                    </td>
                </tr>

            </table>
 
        </div>
    </asp:Content>