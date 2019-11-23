<%@ Page Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" CodeBehind="EmailAppointment.aspx.cs" 
Inherits="AMSProjectNew.ValuationManager.EmailAppointment" Title="" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="lblAddress" runat="server" Visible="false"></asp:Label>
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td  style="padding:0px 0px 5px 0px;"></td>
    </tr>
    <tr>
        <td class="LeftTitle" align="left" style="height:20px;"><i>Appointment Email : <asp:Label ID="lblJobId1" runat="server"></asp:Label></i></td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="left">
            <table cellpadding="0" cellspacing="8" width="100%">
                <tr runat="server" id="trMessage" visible="false">
                    <td colspan="3" align="center" style="height:25px; background-color:#FFFBCE;">
                        <b><asp:Label CssClass="Error" ID="lblMessage" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" 
                            CssClass="Button" onclick="btnSendEmail_Click" />&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back..." CssClass="Button" 
                            onclick="btnBack_Click" />
                    </td>
                </tr>
            </table> 
            <table cellpadding="0" cellspacing="3" width="100%">
                <tr>
                    <td width="100px" class="TDLeftTextLeft">To Email:</td>
                    <td><asp:TextBox ID="txtToEmail" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100px" class="TDLeftTextLeft">To Email:</td>
                    <td><asp:TextBox ID="txtToEmail1" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="TDLeftTextLeft">Subject:</td>
                    <td><asp:TextBox ID="txtSubject" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="TDLeftTextLeft">Company:</td>
                    <td><asp:TextBox ID="txtCompany" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="TDLeftTextLeft">From Email:</td>
                    <td><asp:TextBox ID="txtFromEmail" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="TDLeftTextLeft">Reply To:</td>
                    <td><asp:TextBox ID="txtReplyTo" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="TDLeftTextLeft">Email Body:</td>
                    <td><CKEditor:CKEditorControl ID="fckEditor" runat="server" 
                            EnterMode="BR" ToolbarFull="Source|Bold|Italic|Underline|NumberedList|BulletedList|-|Outdent|Indent|Blockquote|
JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|Link|Font|FontSize|
TextColor|BGColor" Width="900px" Height="600px"></CKEditor:CKEditorControl></td>
                </tr>
            </table>            
        </td>
    </tr>
</table>

</asp:Content>
