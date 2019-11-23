<%@ Page Title="" Language="C#" MasterPageFile="~/Reviewers/ReviewersMaster.Master" AutoEventWireup="true" CodeBehind="JobOrderEditRequest.aspx.cs" Inherits="AMSProjectNew.Reviewers.JobOrderEditRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="lblAddress" runat="server"></asp:Label>
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td  style="padding:0px 0px 10px 0px;"></td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="left">
            <table cellpadding="0" cellspacing="10" width="100%">
                <tr>
                    <td colspan="3" class="LeftTitleJobNo"><asp:Label ID="lblJobNo" runat="server"></asp:Label></td>
                </tr>
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
                            <tr runat="server" id="trReports">
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Job Edit Request Details</b></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="TDRightTextLeft"><span class="Error">Fields marked as * are mandatory.</span></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Request Title</td>
                                            <td class="TDRightTextLeft"><asp:TextBox  ID="txtRequestTitle" Width="400px" 
                                                    runat="server" CssClass="TextBox"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Request Details:</td>
                                            <td class="TDRightTextLeft"><asp:TextBox  ID="txtRequestDetails" Width="400px" 
                                                    TextMode="MultiLine" runat="server" CssClass="TextBox" Height="200px"></asp:TextBox></td>
                                        </tr>                                       
                                        <tr>
                                            <td class="TDLeftTextLeft">&nbsp;</td>
                                            <td class="TDRightTextLeft">
                                                <span class="Error">Please provide as much as details to edit job request..</span></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft"></td>
                                            <td class="TDRightTextLeft">
                                                <asp:Button ID="btnSubmitRequest" runat="server" CssClass="Button" Text="Submit Request" OnClientClick="return CheckRequestSubmitValidation();" onclick="btnSubmitRequest_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                    <script type="text/javascript" language="javascript">
                                        function CheckRequestSubmitValidation() {
                                            var strMsg = "";
                                            if (document.getElementById("<%=txtRequestTitle.ClientID%>").value == "")
                                                strMsg += "\Request Title\n";
                                            if (document.getElementById("<%=txtRequestDetails.ClientID%>").value == "")
                                                strMsg += "Request Details\n";

                                            if (strMsg != "") {
                                                strMsg = "Please enter following fields:\n" + strMsg;
                                                alert(strMsg);
                                                if (document.getElementById("<%=txtRequestDetails.ClientID%>").value == "") document.getElementById("<%=txtRequestDetails.ClientID%>").focus();
                                                if (document.getElementById("<%=txtRequestTitle.ClientID%>").value == "") document.getElementById("<%=txtRequestTitle.ClientID%>").focus();

                                                return false;
                                            }
                                            else
                                                confirm('Are you sure to submit job edit request?');
                                        }        
                                    </script>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="padding-top:10px;">
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
                                            <td class="TDLeftTextLeft">Ordered By:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Ordered On:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblCreatedOn" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" id="trPaymentStatus">
                                            <td class="TDLeftTextLeft">Payment Status:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblPaymentStatus" runat="server"></asp:Label></td>
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
</asp:Content>
