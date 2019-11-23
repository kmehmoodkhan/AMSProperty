<%@ Page Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" CodeBehind="EmailSent.aspx.cs" 
Inherits="AMSProjectNew.ValuationManager.EmailSent" Title="" %>
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
                <tr>
                    <td align="center" style="height:40px;">
                        <b><asp:Label CssClass="Error" ID="lblMessage" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height:40px;">
                        <asp:Button ID="btnGoJobDetails" runat="server" Text="Go to Job Details" CssClass="Button" onclick="btnGoJobDetails_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height:300px;">
                        &nbsp;
                    </td>
                </tr>
            </table> 
        </td>
    </tr>
</table>
</asp:Content>
