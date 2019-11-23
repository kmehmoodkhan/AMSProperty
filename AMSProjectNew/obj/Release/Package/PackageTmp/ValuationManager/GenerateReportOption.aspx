<%@ Page Title="" Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" CodeBehind="GenerateReportOption.aspx.cs" Inherits="AMSProjectNew.ValuationManager.GenerateReportOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Select option for final Report</i></td>
    </tr>
    <tr>
        <td align="left">&nbsp;
        </td>
    </tr>
    <tr>
        <td style="background:white; height:400px;">
            <table cellpadding="0" cellspacing="20" width="100%" >
                <tr>
                    <td align="center" class="Title101">
                        Please select option to make final PDF report.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnUpload" runat="server" CssClass="Button2" Text="Upload Report" onclick="btnUpload_Click"></asp:Button>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnGenerate" runat="server" CssClass="Button2" Text="Generate Report" onclick="btnGenerate_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

