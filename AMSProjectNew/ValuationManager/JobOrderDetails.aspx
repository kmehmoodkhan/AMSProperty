<%@ Page Title="" Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" CodeBehind="JobOrderDetails.aspx.cs" Inherits="AMSProjectNew.ValuationManager.JobOrderDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:UpdatePanel ID="updJob" runat="server" UpdateMode="Conditional">
<ContentTemplate>--%>
<asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblClientName" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblAddress" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblAccountUploadNew" runat="server" Visible="false"></asp:Label>
<asp:Label Visible="false" ID="lblOneOffClient" runat="server"></asp:Label>
<asp:Label ID="lblValuersEmail" Visible="false" runat="server"></asp:Label>
<asp:Label ID="lblPdfReport" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblFieldNoteUploadNew" runat="server" Visible="false"></asp:Label>
<asp:HiddenField ID="hdnCompanyReAssign" runat="server" />
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td  style="padding:0px 0px 10px 0px;"></td>
    </tr>
    <tr>
        <td align="left">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" width="100px" runat="server" id="tdJobDetails"><asp:LinkButton ID="lbtnJobDetails" runat="server" Text="Job Details" onclick="lbtnJobDetails_Click"></asp:LinkButton></td>
                    <td align="center" width="140px" runat="server" id="tdEditRequest"><asp:LinkButton ID="lbtnEditRequest" runat="server" Text="Job Edit Requests" onclick="lbtnEditRequest_Click"></asp:LinkButton></td>
                    
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="left">
            <table cellpadding="0" cellspacing="10" width="100%">
                <tr>
                    <td colspan="2" class="LeftTitleJobNo"><asp:Label ID="lblJobNo" runat="server"></asp:Label></td>
                    <td align="right"></td>
                </tr>
                <tr>
                    <td colspan="3" class="LeftTitle5">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td><asp:Label ID="lblJobTitle" runat="server"></asp:Label></td>
                                <td align="right">
                                    <asp:Button CssClass="Button" ID="btnEditJob" runat="server" Text="Edit Job" onclick="btnEditJob_Click" />&nbsp;
                                    <asp:Button Visible="false" OnClientClick="return confirm('Are you sure to delete this job?');" CssClass="Button" ID="btnDeleteJob" runat="server" Text="Delete Job" onclick="btnDeleteJob_Click" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server" id="trMessage" visible="false">
                    <td colspan="3" align="center" style="height:25px; background-color:#FFFBCE;">
                        <b><asp:Label CssClass="Error" ID="lblMessage" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr runat="server" id="trJobDetails" visible="false">
                    <td colspan="2" valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%" runat="server" id="tblJobDetails">
                            <tr runat="server" id="trAccontUpload" style="display:none;">
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Upload Account Document</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDRightTextRight" align="right" colspan="2"><span class="Error">Fields marked as * are mandatory.</span></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Upload File: </td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblAccountUploadNewShow" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Select File: </td>
                                            <td class="TDRightTextLeft"></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft"></td>
                                            <td class="TDRightTextLeft"></td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                            <tr runat="server" id="trReports">
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="2"><b>Reports Document</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">PDF Report:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblReportUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Account:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblAccountUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td class="TDLeftTextLeft">Upload Account:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:FileUpload ID="fuAccount" runat="server" />&nbsp;
                                                <asp:Button OnClientClick="return CheckAccountValidation();" ID="btnSubmitReports" runat="server" CssClass="Button" Text="Upload" onclick="btnSubmitReports_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Field Note:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblFieldNoteUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td class="TDLeftTextLeft">Uploaded On:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblUploadedOn" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" id="trPaymentNote" visible="false">
                                            <td class="TDLeftTextLeft"></td>
                                            <td class="TDRightTextLeft">Payment for this job is not completed yet. You cant Accept or Reject this job at this time.</td>
                                        </tr>
                                        <tr runat="server" id="trAccept" visible="false">
                                            <td class="TDLeftTextLeft">Accept:</td>
                                            <td class="TDRightTextLeft">Upon Accepted the job, the final report will sent to client and job status will changed to Completed</td>
                                        </tr>
                                        <tr runat="server" id="trReject" visible="false">
                                            <td class="TDLeftTextLeft">Reject:</td>
                                            <td class="TDRightTextLeft">Upon Rejected the job, notification will sent to Valuer and job status will changed to In Progress Inspected</td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft"></td>
                                            <td class="TDRightTextLeft"><asp:CheckBox ID="chkFinalReportEditEmail" runat="server" /> Click here to edit email before sending final report</td>
                                        </tr>
                                        <tr runat="server" id="trARButtons" visible="false">
                                            <td class="TDLeftTextLeft"></td>
                                            <td class="TDRightTextLeft">
                                                <asp:Button ID="btnAccept" runat="server" CssClass="Button" Text="Accept" onclick="btnAccept_Click" OnClientClick="return confirm('Are you sure to accept the job reports?\n\nThe job status will be changed as Completed and final reports will send to Client.');"></asp:Button>&nbsp;
                                                <asp:Button ID="btnReject" runat="server" CssClass="Button" Text="Reject" onclick="btnReject_Click" OnClientClick="return confirm('Are you sure to reject the job reports?\n\nThe job status will be changed as In Progress - Inspected.');"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                    <script type="text/javascript">
                                        function CheckAccountValidation() {
                                            var Msg = "";
                                            if (document.getElementById("<%=fuAccount.ClientID%>").value == "")
                                                Msg += "Account upload is required\n";

                                            if (Msg != "") {
                                                Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
                                                alert(Msg);
                                                return false;
                                            }
                                        }
                                    </script>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" colspan="3"><b>Documents</b></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">Valuation Instruction:</td>
                                            <td width="200px" class="TDRightTextLeft">
                                                <asp:Label ID="lblValuationInstructionDisplay" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnValuationInstruction" runat="server" />
                                                <asp:FileUpload ID="fuVI" runat="server" />&nbsp;
                                            </td>
                                            <td class="TDRightTextLeft">
                                                <asp:Button Width="180px" ID="btnValuationInstructionUpload" runat="server" CssClass="Button" Text="Upload Valuation Instruction" onclick="btnValuationInstructionUpload_Click"></asp:Button>
                                                <asp:Button Width="180px" ID="btnValuationInstructionDelete" runat="server" CssClass="Button" Text="Delete Valuation Instruction" onclick="btnValuationInstructionDelete_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Property Report:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:Label ID="lblPropertyReportDisplay" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnPropertyReport" runat="server" />
                                                <asp:FileUpload ID="fuPR" runat="server" />&nbsp;
                                            </td>
                                            <td class="TDRightTextLeft">
                                                <asp:Button Width="180px" ID="btnPropertyReportUpload" runat="server" CssClass="Button" Text="Upload Property Report" onclick="btnPropertyReportUpload_Click"></asp:Button>
                                                <asp:Button Width="180px" ID="btnPropertyReportDelete" runat="server" CssClass="Button" Text="Delete Property Report" onclick="btnPropertyReportDelete_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Overlays:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:Label ID="lblOverlaysDisplay" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnOverlays" runat="server" />
                                                <asp:FileUpload ID="fuOL" runat="server" />&nbsp;
                                            </td>
                                            <td class="TDRightTextLeft">
                                                <asp:Button Width="180px" ID="btnOverlaysUpload" runat="server" CssClass="Button" Text="Upload Overlays" onclick="btnOverlaysUpload_Click"></asp:Button>
                                                <asp:Button Width="180px" ID="btnOverlaysDelete" runat="server" CssClass="Button" Text="Delete Overlays" onclick="btnOverlaysDelete_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Title:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:Label ID="lblTitleDisplay" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnTitle" runat="server" />
                                                <asp:FileUpload ID="fuTL" runat="server" />&nbsp;
                                            </td>
                                            <td class="TDRightTextLeft">
                                                <asp:Button Width="180px" ID="btnTitleUpload" runat="server" CssClass="Button" Text="Upload Title" onclick="btnTitleUpload_Click"></asp:Button>
                                                <asp:Button Width="180px" ID="btnTitleDelete" runat="server" CssClass="Button" Text="Delete Title" onclick="btnTitleDelete_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Others:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:FileUpload ID="fuOthers" runat="server" />&nbsp;
                                            </td>
                                            <td class="TDRightTextLeft">
                                                <asp:Button Width="180px" ID="btnUploadOthers" runat="server" CssClass="Button" Text="Upload Others" onclick="btnUploadOthers_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft"></td>
                                            <td colspan="2" class="TDRightTextLeft">
                                                <asp:DataList ID="dlDocuments" runat="server" 
                                                    onitemcommand="dlDocuments_ItemCommand">
                                                    <HeaderTemplate><table cellpadding="0" cellspacing="5"></HeaderTemplate>
                                                    <ItemTemplate>
                                                        
                                                            <tr>
                                                                <td><a href='../Documents/Others/<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'><%# DataBinder.Eval(Container.DataItem, "DocumentName")%></a></td>
                                                                <td><asp:ImageButton ImageUrl="~/Images/btn_delete.gif"  ID="imgbtnDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' CommandName="DEL" runat="server" /></td>
                                                            </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate></table></FooterTemplate>
                                                </asp:DataList>
                                            </td>
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
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">&nbsp;</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblOtherNote" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">&nbsp;</td>
                                            <td class="TDRightTextLeft"><asp:TextBox CssClass="TextBox" TextMode="MultiLine" 
                                                    Height="100px" ID="txtOtherNote" placeholder="Enter note details here:" 
                                                    runat="server" Width="501px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="150px">&nbsp;</td>
                                            <td class="TDRightTextLeft"><asp:Button ID="btnSubmitOtherNote" runat="server" 
                                                    Text="Add Note" CssClass="Button" onclick="btnSubmitOtherNote_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DataList ID="dlEmailHistory" runat="server" width="100%">
                                        <HeaderTemplate><table cellpadding="0" cellspacing="3" width="100%">
                                        <tr><td class="TDLeftTextLeft" colspan="3"><b>Email History:</b></td></tr>
                                        <tr>
                                            <td class="TDRightTextLeft"><b>Title</b></td>
                                            <td class="TDRightTextLeft"><b>Date & Time</b></td>
                                            <td class="TDRightTextLeft"><b>View</b></td>
                                        </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <tr>
                                                    <td class="TDRightTextLeft"><%# DataBinder.Eval(Container.DataItem,"EmailType") %></td>
                                                    <td class="TDRightTextLeft"><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "SendOn")).ToString("MMM,dd yyyy hh:mm tt")%></td>
                                                    <td class="TDRightTextLeft"><a target="_blank" href='../EmailHistoryFiles/<%# DataBinder.Eval(Container.DataItem,"EmailFile") %>'>Click to view file</a></td>
                                                </tr>
                                        </ItemTemplate>
                                        <FooterTemplate></table></FooterTemplate>
                                    </asp:DataList>
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
                        <table cellpadding="0" cellspacing="0" width="100%" runat="server" id="tblEditRequest">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEditRequestMessage" CssClass="Error" Font-Bold="true" runat="server"></asp:Label>
                                    <asp:GridView ID="gvEditRequest" Width="100%" runat="server" AutoGenerateColumns="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table cellpadding="0" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td class="TDRightTextLeft" width="100px">Date</td>
                                                            <td class="TDRightTextLeft">Request Details</td>
                                                            <td class="TDRightTextLeft" width="150px">Requested By</td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td valign="top" class="TDRightTextLeft" width="100px"><%# DataBinder.Eval(Container.DataItem, "CreatedOn")%></td>
                                                            <td valign="top" class="TDRightTextLeft"><b><%# DataBinder.Eval(Container.DataItem, "RequestTitle")%></b><br /><br /><%# DataBinder.Eval(Container.DataItem, "RequestDetails")%></td>
                                                            <td valign="top" class="TDRightTextLeft" width="150px"><%# DataBinder.Eval(Container.DataItem, "CreatedByName")%><br />(<%# DataBinder.Eval(Container.DataItem, "CreatedByType")%>)</td>
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
                                        <tr runat="server" id="trPaymentStatusButton">
                                            <td align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Button OnClientClick="return confirm('Are you sure to update payment status as Completed?');" ID="btnPaymentCompleted" runat="server" CssClass="Button" Text="Payment Completed?" Width="175px" onclick="btnPaymentCompleted_Click"></asp:Button></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="0" cellspacing="5" 
                            style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Create Valuation Report</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Label ID="lblGenerateReport" runat="server"></asp:Label></td>
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
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblValuationCompany" runat="server"></asp:Label>
                                                <asp:Label ID="lblValuationCompanyId" runat="server" Visible="false"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" id="trAssignCompany">
                                            <td  align="center" colspan="2" style="padding:10px 0px 5px 0px;">
                                                <asp:Button ID="btnAssignCompany" runat="server" CssClass="Button" Text="Assign Job to Valuation Company" onclick="btnAssignCompany_Click"></asp:Button>
                                                <asp:Button ID="btnReAssignCompany" runat="server" CssClass="Button" Text="Change Company" onclick="btnReAssignCompany_Click" Width="175px"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Valuer:<asp:HiddenField ID="hdnValuerReassign" runat="server" /></td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblValuer" runat="server"></asp:Label></td>
                                        </tr>
                                         <tr runat="server" id="trAssignValuer">
                                            <td  align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Button ID="btnAssignValuer" runat="server" CssClass="Button" Text="Assign Job to Valuer" onclick="btnAssignValuer_Click" Width="175px"></asp:Button>
                                                <asp:Button ID="btnChangeValuer" runat="server" CssClass="Button" 
                                                    Text="Change Valuer" onclick="btnChangeValuer_Click" Width="175px"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Reviewer:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblReviewer" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="0" cellspacing="5" style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;" runat="server" id="tblFeeUpdate">
                            <tr>
                                <td class="LeftTitle4">Update Fee</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">Company Fee:</td>
                                            <td class="TDLeftTextLeft" align="right">$ <asp:Label ID="lblCompanyFee" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">New Fee:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:TextBox ID="txtNewFee"  CssClass="TextBox" Width="100px" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td  align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Button OnClientClick="return CheckFeeValidation();" ID="btnUpdateFee" runat="server" CssClass="Button" Text="Update Fee" onclick="btnUpdateFee_Click" Width="175px"></asp:Button></td>
                                        </tr>
                                    </table>
                                    <script type="text/javascript">
                                        function CheckFeeValidation() {
                                            var Msg = "";

                                            if (document.getElementById("<%=txtNewFee.ClientID%>").value == "")
                                                Msg += "Enter new fee\n";

                                            if (Msg != "") {
                                                alert('Please resolve following error.\n\n' + Msg);
                                                document.getElementById("<%=txtNewFee.ClientID%>").focus();
                                                return false;
                                            }
                                        }
                                    </script>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="0" cellspacing="5" style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Have you set appointment yet?</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">Date:</td>
                                            <td class="TDLeftTextLeft" align="right">
                                                <asp:TextBox  Width="70px" ID="txtAppointmentDate" runat="server" CssClass="TextBox"></asp:TextBox>
                                                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" /><br />
                                                <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="calendarButtonExtender" runat="server" TargetControlID="txtAppointmentDate" PopupButtonID="Image1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">Time:</td>
                                            <td class="TDLeftTextLeft" align="right">
                                                <asp:DropDownList ID="ddlAppointmentTime" runat="server" CssClass="DDL">
                                                <asp:ListItem Text="Select Time" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="06:00 AM" Value="06:00 AM"></asp:ListItem>
                                                <asp:ListItem Text="06:30 AM" Value="06:30 AM"></asp:ListItem>
                                                <asp:ListItem Text="07:00 AM" Value="07:00 AM"></asp:ListItem>
                                                <asp:ListItem Text="07:30 AM" Value="07:30 AM"></asp:ListItem>
                                                <asp:ListItem Text="08:00 AM" Value="08:00 AM"></asp:ListItem>
                                                <asp:ListItem Text="08:30 AM" Value="08:30 AM"></asp:ListItem>
                                                <asp:ListItem Text="09:00 AM" Value="09:00 AM"></asp:ListItem>
                                                <asp:ListItem Text="09:30 AM" Value="09:30 AM"></asp:ListItem>
                                                <asp:ListItem Text="10:00 AM" Value="10:00 AM"></asp:ListItem>
                                                <asp:ListItem Text="10:30 AM" Value="10:30 AM"></asp:ListItem>
                                                <asp:ListItem Text="11:00 AM" Value="11:00 AM"></asp:ListItem>
                                                <asp:ListItem Text="11:30 AM" Value="11:30 AM"></asp:ListItem>
                                                <asp:ListItem Text="12:00 PM" Value="12:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="12:30 PM" Value="12:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="01:00 PM" Value="01:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="01:30 PM" Value="01:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="02:00 PM" Value="02:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="02:30 PM" Value="02:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="03:00 PM" Value="03:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="03:30 PM" Value="03:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="04:00 PM" Value="04:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="04:30 PM" Value="04:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="05:00 PM" Value="05:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="05:30 PM" Value="05:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="06:00 PM" Value="06:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="06:30 PM" Value="06:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="07:00 PM" Value="07:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="07:30 PM" Value="07:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="08:00 PM" Value="08:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="08:30 PM" Value="08:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="09:00 PM" Value="09:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="09:30 PM" Value="09:30 PM"></asp:ListItem>
                                                <asp:ListItem Text="10:00 PM" Value="10:00 PM"></asp:ListItem>
                                                <asp:ListItem Text="10:30 PM" Value="10:30 PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">Send Email?:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:CheckBox ID="chkAppointmentEmail" runat="server" />&nbsp; Yes, edit & send email.</td>
                                        </tr>
                                        <tr runat="server" id="trAppointment">
                                            <td  align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Button OnClientClick="return CheckValidation();" ID="btnAppointmentSetSubmit" runat="server" CssClass="Button" Text="Set Appointment" Width="175px" onclick="btnAppointmentSetSubmit_Click"></asp:Button></td>
                                        </tr>
                                    </table>
                                    <script type="text/javascript">
                                        function CheckValidation() {
                                            if (document.getElementById("<%=txtAppointmentDate.ClientID%>").value == "" || document.getElementById("<%=ddlAppointmentTime.ClientID%>").value == "0") {
                                                alert('Please select date & time.');
                                                return false;
                                            }
                                        }
                                    </script>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="0" cellspacing="5" 
                            style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Client Questionaire</td>
                            </tr>
                            <tr>
                                <td  align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Button CssClass="Button" ID="btnEmailToClient" runat="server" Width="175px" Text="Send Email to Client" onclick="btnEmailToClient_Click" /></td>
                            </tr>
                        </table>
                        <br />
                        <table runat="server" id="tblInspected" cellpadding="0" cellspacing="5" style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Have you inspected the property?</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr style="display:none;">
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;">Inspected On:</td>
                                            <td class="TDLeftTextLeft" align="right">
                                                <asp:TextBox Width="70px" ID="txtInspectedDate" runat="server" CssClass="TextBox" Text="12/12/2015"></asp:TextBox>
                                                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" /><br />
                                                <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtInspectedDate" PopupButtonID="ImageButton1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Button OnClientClick="return CheckValidationInspected();" ID="btnInspected" runat="server" CssClass="Button" Text="Send Account to Client" Width="175px"  onclick="btnInspected_Click"></asp:Button></td>
                                        </tr>
                                    </table>
                                    <script type="text/javascript">
                                        function CheckValidationInspected() {
                                            if (document.getElementById("<%=txtInspectedDate.ClientID%>").value == "") {
                                                //alert('Please select date.');
                                                return true;
                                            }
                                        }
                                    </script>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table runat="server" id="tblFinalReport" cellpadding="0" cellspacing="5" style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Final Report</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        
                                        <tr>
                                            <td align="center" colspan="2" style="padding:10px 0px 5px 0px;"><asp:Button ID="btnUploadReport" runat="server" CssClass="Button" Text="Valuation Report" onclick="btnUploadReport_Click" Width="175px" ></asp:Button></td>
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
<asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
<ajaxToolkit:ModalPopupExtender ID="mdlPopUp" BehaviorID="mdlPopUp" runat="server" CancelControlID="btnCancel"
    TargetControlID="LinkButton1" PopupControlID="pnlPopup" BackgroundCssClass="modalBackground" />
<asp:Panel ID="pnlPopup" runat="server" CssClass="confirm-dialog1" Style="display: none;">
    <table width="500px" cellpadding="0" cellspacing="0" style="background-color: White;border: solid 2px #28578F;">
        <tr>
            <td class="PopupHeader">Select company to assign the job.</td>
        </tr>              
        <tr>
            <td align="center" height="120px">
                <table cellpadding="0" cellspacing="5" width="100%">
                    <tr>
                        <td height="20px">
                            <asp:Label ID="lblPopupError" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td></td></tr>
                    <tr>
                        <td>
                            <asp:GridView width="100%"  GridLines="None" ID="gvValuationCompany" AutoGenerateColumns="false" runat="server" onrowcommand="gvValuationCompany_RowCommand">
                                <HeaderStyle CssClass="JobGridTable" />
                                <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" />
                                <AlternatingRowStyle CssClass="JobGridAlt" />
                                <Columns>
                                    <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                                    <asp:BoundField DataField="Postcode" HeaderText="Postcode" />
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <input type="radio" Name="Select1" id='<%# DataBinder.Eval(Container.DataItem,"UserId") %>' onclick="SetJobId(this);" />
                                            <asp:LinkButton Visible="false" OnClientClick="return confirm('Are you sure to assign job to selected company?');" ID="lbtnSelect" CommandArgument="Assign" CommandName='<%# DataBinder.Eval(Container.DataItem,"Id") %>' runat="server">Select</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:HiddenField ID="hdnCompanyId" runat="server" />
                            <script type="text/javascript">
                                function SetJobId(ctrl) {
                                    document.getElementById("<%=hdnCompanyId.ClientID%>").value = ctrl.id;
                                }
                                function CheckCompanyId() {
                                    if (document.getElementById("<%=hdnCompanyId.ClientID%>").value == "0") {
                                        alert('Please select company to assign the Job.');
                                        return false;
                                    }
                                    else
                                        return confirm("Are you sure to accept & assign the job to selected company?");
                                }
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" height="40px">
                            <asp:Button OnClientClick="return CheckCompanyId();" CssClass="Button" ID="btnAcceptAndAssignSubmit" OnClick="btnAcceptAndAssignSubmit_Click" runat="server" Text="Assign Job" />
                            <asp:Button CssClass="Button" ID="btnCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
   
<asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
<ajaxToolkit:ModalPopupExtender ID="mdlPopupValuer" BehaviorID="mdlPopupValuer" runat="server" CancelControlID="btnAssignValuerCancel"
    TargetControlID="LinkButton2" PopupControlID="pnlValuer" BackgroundCssClass="modalBackground" />
<asp:Panel ID="pnlValuer" runat="server" CssClass="confirm-dialog1" Style="display: none;">
    <table width="500px" cellpadding="0" cellspacing="0" style="background-color: White;border: solid 2px #28578F;">
        <tr>
            <td class="PopupHeader">Assign the job to Valuer</td>
        </tr>              
        <tr>
            <td align="center" height="120px">
                <table cellpadding="0" cellspacing="5" width="100%">
                    <tr>
                        <td height="20px"><asp:Label ID="lblValuerPopupError" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td height="20px"><b><asp:Label ID="lblJobTitlePopup" runat="server"></asp:Label></b></td>
                    </tr>
                    <tr><td height="30px" valign="bottom">Select valuer to assign the job.</td></tr>
                    <tr>
                        <td>
                            <asp:GridView width="100%"  GridLines="None" ID="gvValuer" AutoGenerateColumns="false" runat="server" >
                                <HeaderStyle CssClass="JobGridTable" />
                                <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" />
                                <AlternatingRowStyle CssClass="JobGridAlt" />
                                <Columns>
                                    <asp:BoundField DataField="Username" HeaderText="Username" />
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <input type="radio" Name="Select" id='<%# DataBinder.Eval(Container.DataItem,"UserId") %>' onclick="SetJobId1(this);" />
                                            <asp:LinkButton Visible="false" OnClientClick="return confirm('You are about to accept the job and assign to Valuer. \n\nAre you sure to accept this job and assign to selected valuer?');" ID="lbtnSelect" CommandArgument="Assign" CommandName='<%# DataBinder.Eval(Container.DataItem,"Id") %>' runat="server">Accept & Assign</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblValuationCompany0" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnValuerId" runat="server" />
                            <script type="text/javascript">
                                function SetJobId1(ctrl) {
                                    document.getElementById("<%=hdnValuerId.ClientID%>").value = ctrl.id;
                                }
                                function CheckValuerId1() {
                                    if (document.getElementById("<%=hdnValuerId.ClientID%>").value == "0") {
                                        alert('Please select valuer to assign the Job.');
                                        return false;
                                    }
                                    else
                                        return confirm("Are you sure to assign the job to selected valuer?");
                                }
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" height="40px">
                            <asp:Button OnClientClick="return CheckValuerId1();" CssClass="Button" ID="btnAssignValuerSubmit" OnClick="btnAssignValuerSubmit_Click" runat="server" Text="Assign Job" />
                            <asp:Button CssClass="Button" ID="btnAssignValuerCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>