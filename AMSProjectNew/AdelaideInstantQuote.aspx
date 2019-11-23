<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdelaideInstantQuote.aspx.cs" Inherits="AMSProjectNew.AdelaideInstantQuote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="http://melbournevaluations.com.au/css/stylesheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function CheckValidation() {
            var strMsg = "";
            if (document.getElementById("<%=txtName.ClientID%>").value == "")
                strMsg += "\Full Name\n";
            if (document.getElementById("<%=txtEmail.ClientID%>").value == "")
                strMsg += "Email Address\n";
            if (document.getElementById("<%=txtSubject.ClientID%>").value == "")
                strMsg += "Subject\n";
                if (document.getElementById("<%=txtMessage.ClientID%>").value == "")
                strMsg += "Message\n";

            if (strMsg != "") {
                strMsg = "Please enter following fields:\n" + strMsg;
                alert(strMsg);
                if (document.getElementById("<%=txtMessage.ClientID%>").value == "") document.getElementById("<%=txtMessage.ClientID%>").focus();
                if (document.getElementById("<%=txtSubject.ClientID%>").value == "") document.getElementById("<%=txtSubject.ClientID%>").focus();
                if (document.getElementById("<%=txtEmail.ClientID%>").value == "") document.getElementById("<%=txtEmail.ClientID%>").focus();
                if (document.getElementById("<%=txtName.ClientID%>").value == "") document.getElementById("<%=txtName.ClientID%>").focus();

                return false;
            }
        }        
    </script>
</head>
<body style="text-align:left;">
    <form id="form1" runat="server">
    <table>
    <tr><td><div class="instant-quote-box "><asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" style="font-family:Arial; font-size:14px;"></asp:Label></div></td></tr>
    <tr><td>
    <div class="instant-quote-box ">
        <asp:TextBox ID="txtName" runat="server" CssClass="instant-quote-box-input" placeholder="Name" style="font-family:Arial; font-size:14px;"></asp:TextBox>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="instant-quote-box-input" placeholder="Email" style="font-family:Arial; font-size:14px;"></asp:TextBox>
        <asp:TextBox ID="txtSubject" runat="server" CssClass="instant-quote-box-input" placeholder="Subject" style="font-family:Arial; font-size:14px;"></asp:TextBox>
        <asp:TextBox ID="txtMessage" TextMode="MultiLine" Height="100px" runat="server" CssClass="instant-quote-box-input" style="font-family:Arial; font-size:14px;" placeholder="Message"></asp:TextBox>
        <asp:Button ID="btnsubmit" runat="server" Text="submit" CssClass="submit" OnClientClick="return CheckValidation();" onclick="btnsubmit_Click" />
    </div>
    </td>
    </tr>
    </table>
    </form>
</body>
</html>
