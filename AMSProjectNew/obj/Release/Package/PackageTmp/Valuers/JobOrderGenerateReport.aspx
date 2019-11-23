<%@ Page Title="" Language="C#" MasterPageFile="~/Valuers/ValuersMaster.Master" AutoEventWireup="true" CodeBehind="JobOrderGenerateReport.aspx.cs" Inherits="AMSProjectNew.Valuers.JobOrderGenerateReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td  style="padding:0px 0px 10px 0px;"></td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="left">
            <table cellpadding="0" cellspacing="10" width="100%">
                <tr>
                    <td colspan="2" class="LeftTitle5"><asp:Label ID="lblJobTitle" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="trMessage" visible="false">
                    <td colspan="2" align="center" style="height:25px; background-color:#FFFBCE;">
                        <b><asp:Label CssClass="Error" ID="lblMessage" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr runat="server" id="trJobDetails" visible="false">
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td valign="top">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Upload Final Reports</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDRightTextRight" align="right" colspan="2"><span class="Error">Fields marked as * are mandatory.</span></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Report Upload: <span class="Error">*</span></td>
                                            <td class="TDRightTextLeft"><asp:FileUpload ID="fuReport" runat="server" /></td>
                                        </tr>
                                        <tr runat="server" id="trAccountUpload">
                                            <td class="TDLeftTextLeft">Account Upload:</td>
                                            <td class="TDRightTextLeft"><asp:FileUpload ID="fuAccount" runat="server" /><asp:Label Visible="false" ID="lblAccountUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" id="trFieldNote">
                                            <td class="TDLeftTextLeft">Field Note Upload:</td>
                                            <td class="TDRightTextLeft"><asp:FileUpload ID="fuNote" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">New Status:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="Label1" runat="server" Text="In Progress - Reviewer"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft"><span class="Error">Note:</span></td>
                                            <td class="TDRightTextLeft"><span class="Error">Please review all reports carefully before you upload. Once reports uploaded, you can not re-upload all reports again.</span></td>
                                        </tr>
                                         <tr>
                                            <td class="TDLeftTextLeft"></td>
                                            <td class="TDRightTextLeft"><asp:Button OnClientClick="return CheckValidation();" ID="btnSubmitReports" runat="server" CssClass="Button" Text="Submit Reports" onclick="btnSubmitReports_Click"></asp:Button></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top:10px;">
                                    <asp:Button ID="btnBack" runat="server" CssClass="Button" Text="Back..." onclick="btnBack_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style=" padding:3px 3px 3px 3px;" valign="top" width="380px">
                        <table cellpadding="0" cellspacing="5" 
                            style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Job Order Status</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">Current Status:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblJobStatus" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Ordered On:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblCreatedOn" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>            
        </td>
    </tr>
</table>
<script type="text/javascript">
    function CheckValidation() {
        var Msg = "";
        if (document.getElementById("<%=fuReport.ClientID%>").value == "")
            Msg += "Report upload is required\n";
        
        if (Msg != "") {
            Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
            alert(Msg);
            return false;
        }
    }
</script>
</asp:Content>
