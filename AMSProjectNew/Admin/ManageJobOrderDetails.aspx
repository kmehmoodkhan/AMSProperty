<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageJobOrderDetails.aspx.cs" Inherits="AMSProjectNew.Admin.ManageJobOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <td colspan="3" class="LeftTitle5"><asp:Label ID="lblJobTitle" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="trMessage" visible="false">
                    <td colspan="3" align="center" style="height:25px; background-color:#FFFBCE;">
                        <b><asp:Label CssClass="Error" ID="lblMessage" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="LeftTitle5" align="right">
                        <asp:Button OnClientClick="return confirm('Are you sure to delete this job?');" CssClass="Button" ID="btnDeleteJob" runat="server" Text="Delete Job" onclick="btnDeleteJob_Click" />
                    </td>
                </tr>
                <tr runat="server" id="trJobDetails" visible="false">
                    <td colspan="2" valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr runat="server" id="trReports">
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Uploaded Reports</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Report Upload:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblReportUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Account Upload:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblAccountUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Field Note Upload:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblFieldNoteUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td class="TDLeftTextLeft">Uploaded On:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblUploadedOn" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:49%;" valign="top">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Customer Details</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Name:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblCustomerFullName" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Mobile Phone Number:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblCustomerMobilePhoneNumber" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Phone Number:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblCustomerPhoneNumber" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Additional Phone Number:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblCustomerAdditionalPhoneNumber" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Email Address:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblEmailAddress" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr><td colspan="2">&nbsp;</td></tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Email Address 1:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblEmailAddress1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr><td colspan="2">&nbsp;</td></tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Access Details</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Access Arrangement Via:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblAccessRrangementsVia" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Contact name for Access:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblNameOfPersonToContactForAccess" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Mobile Phone Number:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblMobilePhoneNumber" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Phone Number:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblPhoneNumber" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Additional Phone Number:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblAdditionalPhoneNumber" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:2%;">&nbsp;</td>
                                <td style="width:49%;" valign="top">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Job Summary</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Client:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblBankLender" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Client Address:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblClientAddress" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Reference:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblLoanReference" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Quoted Fee:</td>
                                            <td class="TDRightTextLeft">$ <asp:Label ID="lblQuoteFee" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Prior Job Reference:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblPriorJobReference" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr><td colspan="2">&nbsp;</td></tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Market Value</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Estimated Value:</td>
                                            <td class="TDRightTextLeft">$ <asp:Label ID="lblEstimatedPrice" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Contract Price:</td>
                                            <td class="TDRightTextLeft">$ <asp:Label ID="lblContractPrice" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Contract Date:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblContractDate" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr><td colspan="2">&nbsp;</td></tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Valuation Types</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Valuation Type:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblValuationType" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Service Type:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblServiceType" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Property Type:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblPropertyType" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Purpose:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblPurpose" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Urgency:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblUrgency" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Transaction Type:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblTransactionType" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Additional Notes:</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Note:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblAdditionalNotes" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="padding-top:10px;">
                                    <asp:Button ID="btnBack" runat="server" CssClass="Button" Text="Back..." onclick="btnBack_Click"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="padding-top:10px;">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Job History:</b></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="gvJobHistory" runat="server" AutoGenerateColumns="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table cellpadding="0" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td class="TDRightTextLeft" width="150px">Date</td>
                                                            <td class="TDRightTextLeft">Details</td>
                                                            <td class="TDRightTextLeft" width="150px">Contact Name</td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td class="TDRightTextLeft" width="150px"><%# DataBinder.Eval(Container.DataItem,"CreatedDate") %></td>
                                                            <td class="TDRightTextLeft"><%# DataBinder.Eval(Container.DataItem,"Comment") %></td>
                                                            <td class="TDRightTextLeft" width="150px"><%# DataBinder.Eval(Container.DataItem,"CreatedByName") %></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style=" padding:3px 3px 3px 3px;" valign="top">
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
                        <br />
                        <table cellpadding="0" cellspacing="5" 
                            style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Job Assigned</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">Company:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblValuationCompany" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Valuer:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblValuer" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Reviewer:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblReviewer" runat="server"></asp:Label></td>
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

