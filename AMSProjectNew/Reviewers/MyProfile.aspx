<%@ Page Title="" Language="C#" MasterPageFile="~/Reviewers/ReviewersMaster.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="AMSProjectNew.Reviewers.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>My Profile</i></td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="center">
            <table cellpadding="0" cellspacing="0" width="900px">
                <tr>
                    <td class="LeftTitle2" colspan="3" align="left" style="height:40px;" valign="bottom">
                        Edit My Profile Details
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="height:50px; background-color:#FFFBCE;">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr><td class="Error">Fields marked as * are mandatory fields.</td></tr>
                            <tr><td><asp:Label CssClass="Error" ID="lblError" runat="server"></asp:Label></td></tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft" width="180px">
                        Current Status:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:RadioButtonList Font-Bold="true" ID="rdStatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Active" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Login Details:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:CheckBox ID="chkChangePassword" runat="server" AutoPostBack="True" oncheckedchanged="chkChangePassword_CheckedChanged" Text="&nbsp;Change Password" />
                    </td>
                </tr>
               <tr>
                    <td class="TDLeft">
                        Username:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtUsername" Enabled="false" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDLeft">
                        Password:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:Label Text="********" ID="lblPassword" runat="server"></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr runat="server" id="trConfirmPassword">
                    <td class="TDLeft">
                        Confirm Password:
                    </td>
                    <td class="TDTopBottom"><span class="ErrorBold">*</span></td>
                    <td class="TDRight">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display:none;">
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
                        <asp:TextBox ID="txtState" runat="server" CssClass="TextBox"></asp:TextBox>
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
                <tr>
                    <td class="TDLeft" colspan="3">
                        <table cellpadding="0" cellspacing="5" width="100%">                
                            <tr>
                                <td align="right">
                                    <asp:Button OnClientClick="return CheckValidation();" ID="btnSubmit" runat="server" CssClass="Button" Text="Submit" onclick="btnSubmit_Click"></asp:Button>
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
    if (document.getElementById("<%=txtState.ClientID%>").value == "")
        Msg += "State is required\n";
    if (document.getElementById("<%=txtPhone1.ClientID%>").value == "")
        Msg += "Phone 1 is required\n";
    
    if (Msg != "") {
        Msg = "Error to submit form details\n\n" + Msg + "\n\nPlease resolve above error and try again.";
        alert(Msg);
        if (document.getElementById("<%=txtPhone1.ClientID%>").value == "") document.getElementById("<%=txtPhone1.ClientID%>").focus();
        if (document.getElementById("<%=txtState.ClientID%>").value == "") document.getElementById("<%=txtState.ClientID%>").focus();
        if (document.getElementById("<%=txtPostcode.ClientID%>").value == "") document.getElementById("<%=txtPostcode.ClientID%>").focus();
        if (document.getElementById("<%=txtSuburb.ClientID%>").value == "") document.getElementById("<%=txtSuburb.ClientID%>").focus();
        if (document.getElementById("<%=txtAddress.ClientID%>").value == "") document.getElementById("<%=txtAddress.ClientID%>").focus();
        if (document.getElementById("<%=txtLastName.ClientID%>").value == "") document.getElementById("<%=txtLastName.ClientID%>").focus();
        if (document.getElementById("<%=txtFirstName.ClientID%>").value == "") document.getElementById("<%=txtFirstName.ClientID%>").focus();
        if (document.getElementById("<%=txtEmailAddress.ClientID%>").value == "") document.getElementById("<%=txtEmailAddress.ClientID%>").focus();
        if (document.getElementById("<%=ddlCompany.ClientID%>").value == "0") document.getElementById("<%=ddlCompany.ClientID%>").focus();
        if (document.getElementById("<%=txtPassword.ClientID%>").value == "") document.getElementById("<%=txtPassword.ClientID%>").focus();
        if (document.getElementById("<%=txtUsername.ClientID%>").value == "") document.getElementById("<%=txtUsername.ClientID%>").focus();
        return false;
    }
}

</script>
</asp:Content>
