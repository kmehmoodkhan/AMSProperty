<%@ Page Title="" Language="C#" MasterPageFile="~/ValuationCompany/ValuationCompanyMaster.Master" AutoEventWireup="true" CodeBehind="JobOrderCreate.aspx.cs" Inherits="AMSProjectNew.ValuationCompany.JobOrderCreate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Job Details</i></td>
    </tr>
    <tr>
        <td style="background:white; padding:0px 0px 20px 0px;" align="center">
            <table cellpadding="0" cellspacing="2" width="900px">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;" valign="bottom">
                        Create New Job
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="height:50px; background-color:#FFFBCE;">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr><td>Add job details to create new job order.</td></tr>
                            <tr><td class="Error">Fields marked as * are mandatory fields.</td></tr>
                            <tr><td><asp:Label CssClass="Error" ID="lblError" runat="server"></asp:Label></td></tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftBoldTextLeftSide" width="250px">
                        Assign to Valuer:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlValuer" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftBoldTextLeftSide" width="250px">
                        Client Details:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtClientName" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftBoldTextLeftSide" width="250px">
                        Client Address:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtClientAddress" TextMode="MultiLine" Height="50px" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td class="TDLeftBoldTextLeftSide" width="250px">
                        Bank Lender Details:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight"></td>
                </tr>
                <tr style="display:none;">
                    <td class="TDLeftNormalText">
                        Loan Reference:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtLoanReference" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftBoldTextLeftSide">
                        Customer/Contact Details:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:CheckBox ID="chkSameAsClient" runat="server" Text="Same as Client name" onclick="SetClientDetails();" />
                        <script type="text/javascript">
                            function SetClientDetails() {
                                if (document.getElementById("<%=chkSameAsClient.ClientID%>").checked == true) {
                                    document.getElementById("<%=txtCustomerFullName.ClientID%>").value = document.getElementById("<%=txtClientName.ClientID%>").value;
                                }
                            }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                        Customer Full Name:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtCustomerFullName" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Mobile Phone Number:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtCustomerMobileNumber" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Phone Number:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtCustomerPhoneNumber" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Additional Phone Number:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtCustomerAdditionalPhoneNumber" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Email Address:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtCustomerEmail" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Email Address 1:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtCustomerEmail1" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftBoldTextLeftSide">
                      Other Details:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Access Arrangement Via:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlAccessArangementsType" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftBoldTextLeftSide">
                      
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:CheckBox ID="chkSameCustomerDetails" runat="server" Text="Same as customer details" onclick="SetCustomerDetails();" />
                        <script type="text/javascript">
                            function SetCustomerDetails() {
                                if (document.getElementById("<%=chkSameCustomerDetails.ClientID%>").checked == true) {
                                    document.getElementById("<%=txtNameOfPersonToContactForAccess.ClientID%>").value = document.getElementById("<%=txtCustomerFullName.ClientID%>").value;
                                    document.getElementById("<%=txtPhoneNumber.ClientID%>").value = document.getElementById("<%=txtCustomerPhoneNumber.ClientID%>").value;
                                    document.getElementById("<%=txtMobilePhoneNumber.ClientID%>").value = document.getElementById("<%=txtCustomerMobileNumber.ClientID%>").value;
                                    document.getElementById("<%=txtAdditionalPhoneNumber.ClientID%>").value = document.getElementById("<%=txtCustomerAdditionalPhoneNumber.ClientID%>").value;
                                }
                            }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Name Of Person To Contact For Access:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtNameOfPersonToContactForAccess" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Mobile Phone Number:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtMobilePhoneNumber" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Phone Number:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Additional Phone Number:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtAdditionalPhoneNumber" runat="server" CssClass="TextBox" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Additional Notes:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtAdditionalNotes" runat="server" CssClass="TextBox" Width="500px" TextMode="MultiLine" Height="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftBoldTextLeftSide">
                       Valuation Details:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Unit/Lot:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtUnitLot" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Address:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>Street Number:&nbsp;<span class="ErrorBold">*</span></td>
                                <td>&nbsp;</td>
                                <td>Street Name:&nbsp;<span class="ErrorBold">*</span></td>
                                <td>&nbsp;</td>
                                <td>Street Type:&nbsp;<span class="ErrorBold">*</span></td>
                            </tr>
                            <tr>
                                <td><asp:TextBox Width="150px" ID="txtStreetNumber" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td><asp:TextBox Width="150px" ID="txtStreetName" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td><asp:TextBox Width="150px" ID="txtStreetType" runat="server" CssClass="TextBox"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Suburb:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtSuburb" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Postcode:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtPostcode" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
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
                    <td class="TDLeftNormalText">
                       Prior Job Reference:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtPriorJobReference" runat="server" CssClass="TextBox" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Contract Price $:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtContractPrice" runat="server" CssClass="TextBox"></asp:TextBox>&nbspEg. 100.00
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Contract Date:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtContractDate" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                            AlternateText="Click to show calendar" /><br />
                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="calendarButtonExtender" runat="server"
                            TargetControlID="txtContractDate" PopupButtonID="Image1" />
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Estimated Value $:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtEstimatedPrice" runat="server" CssClass="TextBox"></asp:TextBox>&nbspEg. 100.00
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Service Type:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Valuation Type:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlValuationType" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Property Type:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlPropertyType" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText">
                       Purpose:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlPurpose" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td class="TDLeftNormalText">
                       Transaction Type:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlTransactionType" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td class="TDLeftNormalText">
                       Urgency:
                    </td>
                    <td class="TDTopBottom"></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlUrgency" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td class="TDLeftNormalText">
                       Quoted Fee $:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtQuoteFee" runat="server" CssClass="TextBox"></asp:TextBox>&nbspEg. 100.00
                    </td>
                </tr>
                <tr>
                    <td class="TDLeftNormalText" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button OnClientClick="return CheckValidation();" ID="btnSubmit" runat="server" CssClass="Button" Text="Submit Job Order" onclick="btnSubmit_Click"></asp:Button>
                                    &nbsp;                                    
                                    <asp:Button ID="btnCancel" runat="server" CssClass="Button" Text="Cancel" onclick="btnCancel_Click"></asp:Button>
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
        if (document.getElementById("<%=ddlValuer.ClientID %>").value == "")
            Msg += "Valuer\n";
        if (document.getElementById("<%=txtClientName.ClientID %>").value == "")
            Msg += "Client\n";
        if (document.getElementById("<%=txtCustomerFullName.ClientID %>").value == "")
            Msg += "Customer full name\n";
        if (document.getElementById("<%=txtCustomerMobileNumber.ClientID %>").value == "")
            Msg += "Customer mobile number\n";
        if (document.getElementById("<%=txtCustomerEmail.ClientID %>").value == "")
            Msg += "Customer email address\n";
        if (document.getElementById("<%=txtNameOfPersonToContactForAccess.ClientID %>").value == "")
            Msg += "Name of person to contact for access\n";
        if (document.getElementById("<%=txtMobilePhoneNumber.ClientID %>").value == "")
            Msg += "Mobile phone number\n";
        if (document.getElementById("<%=txtStreetNumber.ClientID %>").value == "")
            Msg += "Street number\n";
        if (document.getElementById("<%=txtStreetName.ClientID %>").value == "")
            Msg += "Street name\n";
        if (document.getElementById("<%=txtStreetType.ClientID %>").value == "")
            Msg += "Street type\n";
        if (document.getElementById("<%=txtSuburb.ClientID %>").value == "")
            Msg += "Suburb\n";
        if (document.getElementById("<%=txtPostcode.ClientID %>").value == "")
            Msg += "Post code\n";
        if (document.getElementById("<%=txtQuoteFee.ClientID %>").value == "")
            Msg += "Quote fee\n";
        if (Msg != "") {
            Msg = "Error to submit job details\n\n" + Msg + "\n\nPlease fill required details and submit job details.";
            alert(Msg);
            return false;
        }
    }
</script>
</asp:Content>
