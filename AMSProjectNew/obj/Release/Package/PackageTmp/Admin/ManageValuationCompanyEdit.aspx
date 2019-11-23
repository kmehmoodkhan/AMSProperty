<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageValuationCompanyEdit.aspx.cs" Inherits="AMSProjectNew.Admin.ManageValuationCompanyEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Manage Valuation Company</i></td>
    </tr>
    <tr>
        <td align="left">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" width="140px" runat="server" id="tdProfileDetails"><asp:LinkButton ID="lbtnProfileDetails" runat="server" Text="Profile Details" onclick="lbtnProfileDetails_Click"></asp:LinkButton></td>
                    <td align="center" width="140px" runat="server" id="tdAccountDetails"><asp:LinkButton ID="lbtnAccountDetails" runat="server" Text="Bank Details" onclick="lbtnAccountDetails_Click"></asp:LinkButton></td>
                    <td align="center" width="140px" runat="server" id="tdLogoDetails"><asp:LinkButton ID="lbtnLogoDetails" runat="server" Text="Logo Details" onclick="lbtnLogoDetails_Click"></asp:LinkButton></td>
                    <td align="center" width="140px" runat="server" id="tdHF"><asp:LinkButton ID="lbtnHFDetails" runat="server" Text="Header & Footer" onclick="lbtnHFDetails_Click"></asp:LinkButton></td>
                    <td align="center" width="140px" runat="server" id="tdOtherDetails"><asp:LinkButton ID="lbtnOtherDetails" runat="server" Text="Other Details" onclick="lbtnOtherDetails_Click"></asp:LinkButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center" style="height:50px; background-color:#FFFBCE;">
            <table cellpadding="0" cellspacing="5" width="100%">
                <tr><td>Add/Edit details for Valuation Company</td></tr>
                <tr><td class="Error">Fields marked as * are mandatory fields.</td></tr>
                <tr><td><asp:Label CssClass="Error" ID="lblError" runat="server"></asp:Label></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="center">
            <table cellpadding="0" cellspacing="2" width="950px" runat="server" id="tblProfileDetails">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;" valign="bottom">
                        Add / Edit Valuation Company
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="280px">
                        Current Status:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:RadioButtonList Font-Bold="true" ID="rdStatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="New" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Active" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Unverified" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Inactive" Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="280px">
                        Allow Job Create:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:RadioButtonList Font-Bold="true" ID="rdAllowJobCreate" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="No" Value="False" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Login Details:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="20px">Username:</td>
                                <td>&nbsp;Password:</td>
                                <td class="Error">Both are required fields.</td>
                            </tr>
                            <tr>
                                <td height="30px"><asp:TextBox ID="txtUsername" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                <td>&nbsp;<asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnCheckAvailabilty" runat="server" CssClass="Button"  OnClientClick="return CheckAvailabilityValidation();" Text="Check Availabilty" onclick="btnCheckAvailabilty_Click"></asp:Button>&nbsp;
                                    <asp:Label CssClass="Error" ID="lblCheckAvailabilty" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>                
                <tr>
                    <td class="TDLeft">
                        Company Name:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="495px" ID="txtCompanyName" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="TDLeft">
                        Website URL:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="495px" ID="txtUrl" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Professional Indemnity Insurance Policy:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td><asp:Label CssClass="Error" ID="lblPdfFileShow" runat="server"></asp:Label></td>
                                <td>&nbsp;</td>
                                <td><asp:Label CssClass="Error" ID="lblPdfFileName" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Insurance Start Date:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="70px" ID="txtStartDate" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                            AlternateText="Click to show calendar" /><br />
                        <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="calendarButtonExtender" runat="server"
                            TargetControlID="txtStartDate" PopupButtonID="ImageButton1" />
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Insurance Expiry Date:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="70px" ID="txtEndDate" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Images/Calendar_scheduleHS.png"
                            AlternateText="Click to show calendar" /><br />
                        <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="CalendarExtender1" runat="server"
                            TargetControlID="txtEndDate" PopupButtonID="ImageButton2" />
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Email Address:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="495px" ID="txtEmailAddress" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        First Name:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="TDLeft">
                        Last Name:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Address:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="495px" ID="txtAddress" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Suburb:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtSuburb" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Postcode:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtPostcode" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        State:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="DDL">
                            <asp:ListItem Value="ACT" Text="ACT" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="NSW" Text="NSW"></asp:ListItem>
                            <asp:ListItem Value="NT" Text="NT"></asp:ListItem>
                            <asp:ListItem Value="QLD" Text="QLD"></asp:ListItem>
                            <asp:ListItem Value="SA" Text="SA"></asp:ListItem>
                            <asp:ListItem Value="TAS" Text="TAS"></asp:ListItem>
                            <asp:ListItem Value="VIC" Text="VIC"></asp:ListItem>
                            <asp:ListItem Value="WA" Text="WA"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Phone 1:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtPhone1" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp(Ex: (08) 8358 6254)
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Phone 2:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtPhone2" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp(Ex: (08) 8358 6254)
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Fax:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtFax" runat="server" CssClass="TextBox"></asp:TextBox>&nbsp(Ex: (08) 8358 6254)
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Other Details:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox TextMode="MultiLine" Height="40px" Width="495px" ID="txtOtherDetails" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr runat="server" id="trStatistics" visible="false">
                    <td class="TDLeft">
                        Statistics:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr>
                                <td>Created On:</td>
                                <td>Modified On:</td>
                                <td>Last Logged On:</td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblCreatedOn" runat="server"></asp:Label></td>
                                <td><asp:Label ID="lblModifiedOn" runat="server"></asp:Label></td>
                                <td><asp:Label ID="lblLastLoggedOn" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td class="TDLeft">
                        Send Email?:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rdSendEmail" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Not Send" Value="Not Send" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Account In active" Value="Account In active"></asp:ListItem>
                                        <asp:ListItem Text="Details Updated" Value="Details Updated"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button OnClientClick="return CheckValidation();" ID="btnSubmit" runat="server" CssClass="Button" Text="Submit" onclick="btnSubmit_Click"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="Button" Text="Cancel" onclick="btnCancel_Click"></asp:Button>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>  
            <table cellpadding="0" cellspacing="2" width="900px" runat="server" id="tblAccountDetails">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;">
                        <b>Bank Details</b>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Bank Name:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="495px" ID="txtBankName" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Bank A/C Number:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="200px" ID="txtACNumber" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        BSB Number:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="200px" ID="txtBSB" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        ABN Number:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox Width="200px" ID="txtABN" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button OnClientClick="return CheckAccountValidation();" ID="btnAccountSubmit" runat="server" CssClass="Button" Text="Submit" onclick="btnAccountSubmit_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="2" width="900px" runat="server" id="tblLogoDetails">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;">
                        <b>Logo Details</b>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Old Logo:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:Label ID="lblCompanyLogo" runat="server" Visible="false"></asp:Label>
                        <asp:Image ID="imgLogo" runat="server" Height="100px" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Upload Logo Image:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:FileUpload ID="fuLogo" runat="server" />
                         &nbsp;<span class="ErrorBold">png/jpeg file will allow only.</span>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button OnClientClick="return CheckLogoValidation();" ID="btnImageUpload" runat="server" CssClass="Button" Text="Upload" onclick="btnImageUpload_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>     
            <table cellpadding="0" cellspacing="2" width="900px" runat="server" id="tblHF">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;">
                        <b>Header & Footer Images</b>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Old Header Image:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:Label ID="lblOldHeaderImage" runat="server" Visible="false"></asp:Label>
                        <asp:Image ID="imgOldHeaderImage" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Upload New Header Image:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:FileUpload ID="fuHeaderImage" runat="server" />
                         &nbsp;<span class="ErrorBold">png/jpeg file will allow only.</span>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button OnClientClick="return CheckHeaderValidation();" ID="btnHeaderUpload" runat="server" CssClass="Button" Text="Upload" onclick="btnHeaderUpload_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Old Footer Image:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:Label ID="lblOldFooterImage" runat="server" Visible="false"></asp:Label>
                        <asp:Image ID="imgOldFooterImage" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Upload New Footer Image:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:FileUpload ID="fuFooterImage" runat="server" />
                         &nbsp;<span class="ErrorBold">png/jpeg file will allow only.</span>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button OnClientClick="return CheckFooterValidation();" ID="btnFooterUpload" runat="server" CssClass="Button" Text="Upload" onclick="btnFooterUpload_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="left">
            <table cellpadding="0" cellspacing="2" runat="server" id="tblOtherDetails">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;">
                        <b>Other Details</b>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Terms & Condition:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                       <asp:TextBox Width="800px" Height="400px" TextMode="MultiLine" ID="txtTermsandCondition" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                       Certification & Qualification:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox Width="800px" Height="400px" TextMode="MultiLine" ID="txtCertificationQualification" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                      Certification(Family Law):
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox Width="800px" Height="400px" TextMode="MultiLine" ID="txtFamilyLawCertification" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnSubmitOtherDetails" runat="server" CssClass="Button" Text="Upload" onclick="btnSubmitOtherDetails_Click"></asp:Button>
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
    if (document.getElementById("<%=txtUsername.ClientID%>").value == "")
        Msg += "Username is required\n";
    if (document.getElementById("<%=txtPassword.ClientID%>").value == "")
        Msg += "Password is required\n";    
    if (document.getElementById("<%=txtCompanyName.ClientID%>").value == "")
        Msg += "Company name is required\n";
    if (document.getElementById("<%=txtUrl.ClientID%>").value == "")
        Msg += "Website url is required\n";
    if (document.getElementById("<%=txtStartDate.ClientID%>").value == "")
        Msg += "Insurane start date is required\n";
    if (document.getElementById("<%=txtEndDate.ClientID%>").value == "")
        Msg += "Insurane end date is required\n";
    if (document.getElementById("<%=txtEmailAddress.ClientID%>").value == "")
        Msg += "Email address is required\n";
    if (document.getElementById("<%=txtFirstName.ClientID%>").value == "")
        Msg += "First name is required\n";
    if (document.getElementById("<%=txtLastName.ClientID%>").value == "")
        Msg += "Last name is required\n";
    if (document.getElementById("<%=txtAddress.ClientID%>").value == "")
        Msg += "Address is required\n";
    if (document.getElementById("<%=txtSuburb.ClientID%>").value == "")
        Msg += "Suburb is required\n";
    if (document.getElementById("<%=txtPostcode.ClientID%>").value == "")
        Msg += "Postcode is required\n";
    if (document.getElementById("<%=txtPhone1.ClientID%>").value == "")
        Msg += "Phone 1 is required\n";
    
    if (Msg != "") {
        Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
        alert(Msg);
        if (document.getElementById("<%=txtPhone1.ClientID%>").value == "") document.getElementById("<%=txtPhone1.ClientID%>").focus();
        if (document.getElementById("<%=txtPostcode.ClientID%>").value == "") document.getElementById("<%=txtPostcode.ClientID%>").focus();
        if (document.getElementById("<%=txtSuburb.ClientID%>").value == "") document.getElementById("<%=txtSuburb.ClientID%>").focus();
        if (document.getElementById("<%=txtAddress.ClientID%>").value == "") document.getElementById("<%=txtAddress.ClientID%>").focus();
        if (document.getElementById("<%=txtLastName.ClientID%>").value == "") document.getElementById("<%=txtLastName.ClientID%>").focus();
        if (document.getElementById("<%=txtFirstName.ClientID%>").value == "") document.getElementById("<%=txtFirstName.ClientID%>").focus();
        if (document.getElementById("<%=txtEmailAddress.ClientID%>").value == "") document.getElementById("<%=txtEmailAddress.ClientID%>").focus();
        if (document.getElementById("<%=txtEndDate.ClientID%>").value == "") document.getElementById("<%=txtEndDate.ClientID%>").focus();
        if (document.getElementById("<%=txtStartDate.ClientID%>").value == "") document.getElementById("<%=txtStartDate.ClientID%>").focus();
        if (document.getElementById("<%=txtUrl.ClientID%>").value == "") document.getElementById("<%=txtUrl.ClientID%>").focus();
        if (document.getElementById("<%=txtCompanyName.ClientID%>").value == "") document.getElementById("<%=txtCompanyName.ClientID%>").focus();
        if (document.getElementById("<%=txtPassword.ClientID%>").value == "") document.getElementById("<%=txtPassword.ClientID%>").focus();
        if (document.getElementById("<%=txtUsername.ClientID%>").value == "") document.getElementById("<%=txtUsername.ClientID%>").focus();
        return false;
    }
}
function CheckAccountValidation() {
    var Msg = "";
    if (document.getElementById("<%=txtBankName.ClientID%>").value == "")
        Msg += "Bank name is required\n";
    if (document.getElementById("<%=txtACNumber.ClientID%>").value == "")
        Msg += "Bank A/C number is required\n";
    if (document.getElementById("<%=txtBSB.ClientID%>").value == "")
        Msg += "BSB number is required\n";
    if (document.getElementById("<%=txtABN.ClientID%>").value == "")
        Msg += "ABN number is required\n";

    if (Msg != "") {
        Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
        alert(Msg);
        if (document.getElementById("<%=txtABN.ClientID%>").value == "") document.getElementById("<%=txtABN.ClientID%>").focus();
        if (document.getElementById("<%=txtBSB.ClientID%>").value == "") document.getElementById("<%=txtBSB.ClientID%>").focus();
        if (document.getElementById("<%=txtACNumber.ClientID%>").value == "") document.getElementById("<%=txtACNumber.ClientID%>").focus();
        if (document.getElementById("<%=txtBankName.ClientID%>").value == "") document.getElementById("<%=txtBankName.ClientID%>").focus();

        return false;
    }
}
function CheckLogoValidation() {
    var Msg = "";
    if (document.getElementById("<%=fuLogo.ClientID%>").value == "")
        Msg += "Company logo image is required\n";
    else {
        var str = document.getElementById("<%=fuLogo.ClientID%>").value;
        var Start = str.lastIndexOf(".");
        var Ext = str.substring(Start, str.length);
        if (Ext == ".png" || Ext == ".jpeg" || Ext == ".jpg") { }
        else Msg += "Only PNG or JPEG file extention for company logo is required\n";
    }

    if (Msg != "") {
        Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
        alert(Msg);

        return false;
    }
}
function CheckAvailabilityValidation() {
    var Msg = "";
    if (document.getElementById("<%=txtUsername.ClientID%>").value == "")
        Msg += "Username is required\n";
    

    if (Msg != "") {
        Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
        alert(Msg);
        if (document.getElementById("<%=txtUsername.ClientID%>").value == "") document.getElementById("<%=txtUsername.ClientID%>").focus();
        return false;
    }
}
</script>
</asp:Content>
