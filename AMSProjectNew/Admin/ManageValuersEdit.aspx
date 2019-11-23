<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageValuersEdit.aspx.cs" Inherits="AMSProjectNew.Admin.ManageValuersEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Manage Valuers</i></td>
    </tr>
    <tr>
        <td align="left">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" width="140px" runat="server" id="tdAccountDetails"><asp:LinkButton ID="lbtnAccountDetails" runat="server" Text="Profile Details" onclick="lbtnAccountDetails_Click"></asp:LinkButton></td>
                    <td align="center" width="140px" runat="server" id="tdLogoDetails"><asp:LinkButton ID="lbtnLogoDetails" runat="server" Text="Logo Details" onclick="lbtnLogoDetails_Click"></asp:LinkButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center" style="height:50px; background-color:#FFFBCE;">
            <table cellpadding="0" cellspacing="5" width="100%">
                <tr><td>Add/Edit details for Valuer</td></tr>
                <tr><td class="Error">Fields marked as * are mandatory fields.</td></tr>
                <tr><td><asp:Label CssClass="Error" ID="lblError" runat="server"></asp:Label></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="center">
            <table cellpadding="0" cellspacing="2" width="900px" runat="server" id="tblAccountDetails">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;" valign="bottom">
                        Add / Edit Valuer
                    </td>
                </tr>
                
                <tr>
                    <td class="TDLeft" width="180px">
                        Current Status:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:RadioButtonList Font-Bold="true" ID="rdStatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="New" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Active" Value="2"></asp:ListItem>
                            <asp:ListItem Text="In active" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="180px">
                        Title:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="TextBox" Width="400px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="180px">
                        Qualifications:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtQualifications" runat="server" CssClass="TextBox" Width="400px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="180px">
                        Experience:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtExperience" runat="server" CssClass="TextBox" Width="400px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="180px">
                        Membership Status: 
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtMembershipStatus" runat="server" CssClass="TextBox" Width="400px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="180px">
                        Membership Body:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtMembershipBody" runat="server" CssClass="TextBox" Width="400px" TextMode="MultiLine" Height="50px"></asp:TextBox>
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
                        Company:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="DDL" Width="508px"></asp:DropDownList>
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
                        <asp:Label ID="lblValuerLogo" runat="server" Visible="false"></asp:Label>
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
        </td>
    </tr>
</table>
<script type="text/javascript">
function CheckValidation() {
    var Msg = "";
    if (document.getElementById("<%=txtTitle.ClientID%>").value == "")
        Msg += "Title is required\n";
    if (document.getElementById("<%=txtQualifications.ClientID%>").value == "")
        Msg += "Qualifications is required\n";
    if (document.getElementById("<%=txtExperience.ClientID%>").value == "")
        Msg += "Experience is required\n";
    if (document.getElementById("<%=txtMembershipStatus.ClientID%>").value == "")
        Msg += "Membership Status is required\n";
    if (document.getElementById("<%=txtMembershipBody.ClientID%>").value == "")
        Msg += "Membership Body is required\n";
    if (document.getElementById("<%=txtUsername.ClientID%>").value == "")
        Msg += "Username is required\n";
    if (document.getElementById("<%=txtPassword.ClientID%>").value == "")
        Msg += "Password is required\n";
    if (document.getElementById("<%=ddlCompany.ClientID%>").value == "0")
        Msg += "Company is required\n";
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
        if (document.getElementById("<%=ddlCompany.ClientID%>").value == "0") document.getElementById("<%=ddlCompany.ClientID%>").focus();
        if (document.getElementById("<%=txtPassword.ClientID%>").value == "") document.getElementById("<%=txtPassword.ClientID%>").focus();
        if (document.getElementById("<%=txtUsername.ClientID%>").value == "") document.getElementById("<%=txtUsername.ClientID%>").focus();
        if (document.getElementById("<%=txtMembershipBody.ClientID%>").value == "") document.getElementById("<%=txtMembershipBody.ClientID%>").focus();
        if (document.getElementById("<%=txtMembershipStatus.ClientID%>").value == "") document.getElementById("<%=txtMembershipStatus.ClientID%>").focus();
        if (document.getElementById("<%=txtExperience.ClientID%>").value == "") document.getElementById("<%=txtExperience.ClientID%>").focus();
        if (document.getElementById("<%=txtQualifications.ClientID%>").value == "") document.getElementById("<%=txtQualifications.ClientID%>").focus();
        if (document.getElementById("<%=txtTitle.ClientID%>").value == "") document.getElementById("<%=txtTitle.ClientID%>").focus();
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
