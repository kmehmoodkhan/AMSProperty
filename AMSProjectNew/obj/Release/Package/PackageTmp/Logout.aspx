<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="AMSProjectNew.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Valuation Central :: Session Timeout</title>
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#28578F;">
    <form id="form1" runat="server">
    <div align="center"><br /><br /><br /><br />
        <table cellpadding="0" cellspacing="0" style="background-color:White;" width="450px">            
            <tr>
                <td align="center" height="500px">
                    <table cellpadding="0" cellspacing="0" style="background-color:White;" width="275px">
                    <tr><td align="center"><img src="Images/Logo.png" /></td></tr>
                    <tr><td align="center">&nbsp;</td></tr>
                    <tr>
                        <td width="120px" style="background-color:#F2F2F2; border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4;" align="left" height="30px">
                            You are logged out. Please relogin...
                        </td>
                    </tr>
                    <tr>
                        <td style=" border-top:1px solid #E4E4E4; border-right:1px solid #E4E4E4; border-left:1px solid #E4E4E4; border-bottom:1px solid #E4E4E4;" align="right" colspan="2" height="30px"><asp:HyperLink NavigateUrl="~/Login.aspx" ID="HyperLink1" runat="server" CssClass="LinkButton">Go to login</asp:HyperLink>&nbsp;</td>
                    </tr>
                </table>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
