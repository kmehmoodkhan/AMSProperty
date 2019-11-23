<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="AMSProjectNew.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Valuation Central :: Forgot Password</title>
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function CheckValidation() {
            var strMsg = "";
            if (document.getElementById("<%=txtUsername.ClientID%>").value == "")
                strMsg += "\nUsername\n";
            
            if (strMsg != "") {
                strMsg = "Please enter following fields:\n" + strMsg;
                alert(strMsg);
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
                        <td style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4;">&nbsp;<asp:TextBox Width="130px" ID="txtUsername" runat="server" CssClass="TextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4;" align="right" colspan="2" height="30px">
                            <asp:Button OnClientClick="return CheckValidation();" ID="btnSendEmail" 
                                runat="server" CssClass="Button" Text="Send Email" onclick="btnSendEmail_Click"></asp:Button>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style=" border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4; border-bottom:1px solid #E4E4E4;" align="right" colspan="2" height="30px"><asp:HyperLink NavigateUrl="~/Login.aspx" ID="HyperLink1" runat="server" CssClass="LinkButton">Go to login</asp:HyperLink>&nbsp;</td>
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
