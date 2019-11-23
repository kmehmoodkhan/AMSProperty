<%@ Page Title="" Language="C#" MasterPageFile="~/Valuers/ValuersMaster.Master" AutoEventWireup="true" CodeBehind="JobOrderDetails.aspx.cs" Inherits="AMSProjectNew.Valuers.JobOrderDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="lblClientName" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblAddress" runat="server" Visible="false"></asp:Label>
<asp:Label Visible="false" ID="lblAccountUploadNew" runat="server"></asp:Label>
<asp:Label Visible="false" ID="lblOneOffClient" runat="server"></asp:Label>
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
                                            <td class="TDLeftTextLeft" colspan="2"><b>Reports Documents</b></td>
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
                                            <td class="TDLeftTextLeft">Upload Account: </td>
                                            <td class="TDRightTextLeft">
                                                <asp:FileUpload ID="fuAccount" runat="server" />&nbsp;
                                                <asp:Button OnClientClick="return CheckUploadAccountValidation();" ID="btnUploadAccount" runat="server" CssClass="Button" Text="Upload" onclick="btnUploadAccount_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Field Note:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblFieldNoteUpload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Upload Field Note:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:FileUpload ID="fuNote" runat="server" />&nbsp;
                                                <asp:Button OnClientClick="return CheckUploadFieldValidation();" ID="btnUploadField" runat="server" CssClass="Button" Text="Upload" onclick="btnUploadField_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td class="TDLeftTextLeft">Uploaded On:</td>
                                            <td class="TDRightTextLeft"><asp:Label ID="lblUploadedOn" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <script type="text/javascript">
                                        function CheckUploadAccountValidation() {
                                            var Msg = "";
                                            if (document.getElementById("<%=fuAccount.ClientID%>").value == "")
                                                Msg += "File selection is required\n";

                                            if (Msg != "") {
                                                Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
                                                alert(Msg);
                                                return false;
                                            }
                                        }
                                        function CheckUploadFieldValidation() {
                                            var Msg = "";
                                            if (document.getElementById("<%=fuNote.ClientID%>").value == "")
                                                Msg += "File selection is required\n";

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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Property Report:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:Label ID="lblPropertyReportDisplay" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Overlays:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:Label ID="lblOverlaysDisplay" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Title:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:Label ID="lblTitleDisplay" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft">Others:</td>
                                            <td class="TDRightTextLeft">
                                                <asp:DataList ID="dlDocuments" runat="server">
                                                    <HeaderTemplate><table cellpadding="0" cellspacing="5"></HeaderTemplate>
                                                    <ItemTemplate>
                                                            <tr>
                                                                <td style="height:25px;"><a href='../Documents/Others/<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'><%# DataBinder.Eval(Container.DataItem, "DocumentName")%></a></td>
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
                                <td class="LeftTitle4">Edit Job Details</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <tr>
                                            <td colspan="2" class="TDLeftTextLeft">Generate request to edit the job details</td>
                                        </tr>
                                        <tr>
                                            <td class="TDLeftTextLeft" width="100px" style="width:100px;"></td>
                                            <td class="TDLeftTextLeft"><asp:Button ID="btnJobEditRequest" runat="server" CssClass="Button" Text="Create Request" Width="120px" onclick="btnJobEditRequest_Click"></asp:Button></td>
                                        </tr>
                                    </table>
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
                                        <tr runat="server" id="trAppointment">
                                            <td class="TDLeftTextLeft"></td>
                                            <td class="TDLeftTextLeft" align="right"><asp:Button OnClientClick="return CheckValidation();" ID="btnAppointmentSetSubmit" runat="server" CssClass="Button" Text="Update Date" Width="120px" onclick="btnAppointmentSetSubmit_Click"></asp:Button></td>
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
                                            <td colspan="2" class="LeftTitle4" align="center"><asp:Button OnClientClick="return CheckValidationInspected();" ID="btnInspected" runat="server" CssClass="Button" Text="Yes, Inspected" Width="120px"  onclick="btnInspected_Click"></asp:Button></td>
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
                                <td class="LeftTitle4">Upload Final Report</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="3" width="100%">
                                        <%--<tr>
                                            <td class="TDLeftTextLeft" align="right" >
                                                If you have completed final PDF report, please click below button to upload your report.
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="LeftTitle4" align="center"><asp:Button ID="btnUploadReport" runat="server" CssClass="Button" Text="Upload Report" onclick="btnUploadReport_Click" Width="120px" ></asp:Button></td>
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
