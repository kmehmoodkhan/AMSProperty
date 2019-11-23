<%@ Page Title="" Language="C#" MasterPageFile="~/ValuationCompany/ValuationCompanyMaster.Master" AutoEventWireup="true" CodeBehind="JobOrderDetails.aspx.cs" Inherits="AMSProjectNew.ValuationCompany.JobOrderDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<asp:UpdatePanel ID="updJob" runat="server" UpdateMode="Conditional">
<ContentTemplate>--%>
<asp:Label ID="lblStatus" Visible="false" runat="server"></asp:Label>
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
                    <td colspan="3" class="LeftTitleJobNo"><asp:Label ID="lblJobNo" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" class="LeftTitle5">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td><asp:Label ID="lblJobTitle" runat="server"></asp:Label></td>
                                <td align="right">
                                    <asp:Button CssClass="Button" ID="btnEditJob" runat="server" Text="Edit Job" onclick="btnEditJob_Click" />&nbsp;
                                    <asp:Button OnClientClick="return confirm('Are you sure to delete this job?');" CssClass="Button" ID="btnDeleteJob" runat="server" Text="Delete Job" onclick="btnDeleteJob_Click" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server" id="trMessage" visible="false">
                    <td colspan="2" align="center" style="height:25px; background-color:#FFFBCE;">
                        <b><asp:Label CssClass="Error" ID="lblMessage" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr runat="server" id="trJobDetails" visible="false">
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%" runat="server" id="tblJobDetails">
                            <tr runat="server" id="trAccontUpload" visible="false">
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="3" width="100%" runat="server" id="tblAccontUpload" visible="false">
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
                    <td style=" padding:3px 3px 3px 3px;" valign="top" width="300px">
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
                                        <tr runat="server" id="trPaymentStatus">
                                            <td class="TDLeftTextLeft">Payment Status:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblPaymentStatus" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="0" cellspacing="5" style="border:solid Silver 1px; background-color:#E9E9E9; width:100%;">
                            <tr>
                                <td class="LeftTitle4">Job Assigned</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%" runat="server" id="tblVR">
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" >Valuer:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblValuer" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Reviewer:</td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Label ID="lblReviewer" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="3" width="100%" runat="server" id="tblAR">                                        
                                        <tr>
                                            <td class="TDLeftTextLeft" align="center">
                                                <asp:Button ID="btnAccept" runat="server" CssClass="Button" Text="Accept Job" onclick="btnAccept_Click"></asp:Button>&nbsp;
                                                <asp:Button ID="btnReject" runat="server" CssClass="Button" Text="Reject Job" onclick="btnReject_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="3" width="100%" runat="server" id="tblRejected">                                        
                                        <tr>
                                            <td class="TDLeftTextLeft" style="color:Red; font-weight:bold;">Job is Rejected</td>
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
            <td class="PopupHeader">Accept and assign the job to Valuer</td>
        </tr>              
        <tr>
            <td align="center" height="120px">
                <table cellpadding="0" cellspacing="5" width="100%">
                    <tr>
                        <td height="20px"><asp:Label ID="lblPopupError" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td height="20px"><b><asp:Label ID="lblJobTitlePopup" runat="server"></asp:Label></b></td>
                    </tr>
                    <tr><td height="30px" valign="bottom">Select valuer to assign the job.</td></tr>
                    <tr>
                        <td>
                            <asp:GridView width="100%"  GridLines="None" ID="gvValuer" AutoGenerateColumns="false" runat="server" onrowcommand="gvValuer_RowCommand">
                                <HeaderStyle CssClass="JobGridTable" />
                                <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" />
                                <AlternatingRowStyle CssClass="JobGridAlt" />
                                <Columns>
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <input type="radio" Name="Select" id='<%# DataBinder.Eval(Container.DataItem,"UserId") %>' onclick="SetJobId(this);" />
                                            <asp:LinkButton Visible="false" OnClientClick="return confirm('You are about to accept the job and assign to Valuer. \n\nAre you sure to accept this job and assign to selected valuer?');" ID="lbtnSelect" CommandArgument="Assign" CommandName='<%# DataBinder.Eval(Container.DataItem,"Id") %>' runat="server">Accept & Assign</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:HiddenField ID="hdnValuerId" runat="server" />
                            <script type="text/javascript">
                                function SetJobId(ctrl) {
                                    document.getElementById("<%=hdnValuerId.ClientID%>").value = ctrl.id;
                                }
                                function CheckValuerId() {
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
                            <asp:Button OnClientClick="return CheckValuerId();" CssClass="Button" ID="btnAssignValuerSubmit" OnClick="btnAssignValuerSubmit_Click" runat="server" Text="Assign Job" />
                            <asp:Button CssClass="Button" ID="btnCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
<ajaxToolkit:ModalPopupExtender ID="mdlPopUpReject" BehaviorID="mdlPopUpReject" runat="server" CancelControlID="btnCancelReject"
    TargetControlID="LinkButton2" PopupControlID="pnlPopupReject" BackgroundCssClass="modalBackground" />
<asp:Panel ID="pnlPopupReject" runat="server" CssClass="confirm-dialog1" Style="display: none;">
    <table width="500px" cellpadding="0" cellspacing="0" style="background-color: White;border: solid 2px #28578F;">
        <tr>
            <td class="PopupHeader">Reject Job</td>
        </tr>              
        <tr>
            <td align="center" height="120px">
                <table cellpadding="0" cellspacing="5" width="90%">
                    <tr>
                        <td height="20px"><asp:Label ID="lblPopupRejectError" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b><asp:Label ID="lblJobTitlePopupReject" runat="server"></asp:Label></b></td>
                    </tr>
                    <tr>
                        <td style="padding-top:15px;">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height:20px;">Reject for Fee?: </td>
                                    <td>&nbsp;</td>
                                    <td><asp:CheckBox ID="chkFeeReject" runat="server" Text="Yes" /></td>
                                </tr>
                                <tr>
                                    <td style="height:30px;">Enter New Fee: </td>
                                    <td>&nbsp;</td>
                                    <td style="padding-left:5px;"><asp:TextBox CssClass="TextBox" Width="100px" ID="txtNewFee" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>&nbsp;</td>
                                    <td style="padding-left:5px;" class="Error"><i>Please enter new fee if you reject job for fee issue.</i></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30px" valign="bottom">Please enter reason to reject the job:</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtRejectReason" CssClass="TextBox" TextMode="MultiLine" Height="200px" Width="450px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" height="40px">
                            <asp:Button CssClass="Button" ID="btnRejectJobSubmit" runat="server" Text="Reject Job" OnClick="btnRejectJobSubmit_Click" OnClientClick="return CheckRejectValidation();" />
                            <asp:Button CssClass="Button" ID="btnCancelReject" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
                <script type="text/javascript">
                    function CheckRejectValidation() {
                        var Msg = "";
                        if (document.getElementById("<%=chkFeeReject.ClientID%>").checked == true)
                        {
                            if (document.getElementById("<%=txtNewFee.ClientID%>").value == "") 
                                Msg +="Enter new fee to reject the job\n";
                        }
                        if (document.getElementById("<%=txtRejectReason.ClientID%>").value == "")
                            Msg += "Enter reason to reject the job\n";

                        if (Msg != "") {
                            alert('Please resolve following error.\n\n' + Msg);
                            return false;
                        }
                        else
                            return confirm("Are you sure to reject the job?");
                    }
                </script>
            </td>
        </tr>
    </table>
</asp:Panel>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
