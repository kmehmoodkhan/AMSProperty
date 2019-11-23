<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AMSProjectNew.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Valuation Central :: Login</title>
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function CheckValidation() {
            var strMsg = "";
            if (document.getElementById("<%=txtUsername.ClientID%>").value == "")
                strMsg += "\nUsername\n";
            if (document.getElementById("<%=txtPassword.ClientID%>").value == "")
                strMsg += "Password\n";

            if (strMsg != "") {
                strMsg = "Please enter following fields:\n" + strMsg;
                alert(strMsg);
                if (document.getElementById("<%=txtPassword.ClientID%>").value == "") document.getElementById("<%=txtPassword.ClientID%>").focus();
                if (document.getElementById("<%=txtUsername.ClientID%>").value == "") document.getElementById("<%=txtUsername.ClientID%>").focus();

                return false;
            }
        }        
    </script>
</head>
<body style="background-color:#28578F;">
    <form id="form1" runat="server">
    <div align="center"><br /><br /><br /><br />
        <table cellpadding="0" cellspacing="0" style="background-color:White;" width="450px">            
            <tr>
                <td align="center" height="500px">
                    <table cellpadding="0" cellspacing="0" style="background-color:White;" width="275px">
                        <tr><td colspan="2" align="center"><img src="Images/Logo.png" /></td></tr>
                        <tr><td colspan="2" align="center">&nbsp;</td></tr>
                        <tr>
                            <td width="120px" style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4;" align="right" height="30px"><b>Username:&nbsp;</b></td>
                            <td style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4;">&nbsp;<asp:TextBox  ID="txtUsername" Width="130px" runat="server" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4;" align="right" height="30px"><b>Password:&nbsp;</b></td>
                            <td style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4;">&nbsp;<asp:TextBox ID="txtPassword" Width="130px" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4;" align="right" colspan="2" height="30px">
                                <asp:Button OnClientClick="return CheckValidation();" ID="btnLogin" runat="server" CssClass="Button" Text="Login" onclick="btnLogin_Click"></asp:Button>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style=" border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4; border-bottom:1px solid #E4E4E4;" align="right" colspan="2" height="30px"><asp:HyperLink NavigateUrl="~/ForgotPassword.aspx" ID="HyperLink1" runat="server" CssClass="LinkButton">I forgot my password</asp:HyperLink>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style=" border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4; border-bottom:1px solid #E4E4E4;" align="right" colspan="2" height="30px"><asp:HyperLink NavigateUrl="~/ValuationCompanyRegistration.aspx" ID="HyperLink2" runat="server" CssClass="LinkButton">Sign up as Valuation Company</asp:HyperLink>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style=" border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4; border-bottom:1px solid #E4E4E4;" align="right" colspan="2" height="30px"><asp:HyperLink NavigateUrl="~/Contact-Us.aspx" ID="HyperLink3" runat="server" CssClass="LinkButton">Contact us</asp:HyperLink>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" height="25px" align="center">&nbsp;<asp:Label ID="lblError" runat="server" CssClass="Error"></asp:Label>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
