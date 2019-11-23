<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MessageDisplay.aspx.cs" Inherits="AMSProjectNew.MessageDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left">&nbsp;</td>
    </tr>
    <tr>
        <td  style="background:white; padding:0px 0px 20px 0px;" align="center">
            <table cellpadding="0" cellspacing="0" width="900px" id="tblCompanyRegistrationSuccess" runat="server">
                <tr>
                    <td align="center" style="height:40px;" valign="bottom">
                        <table cellpadding="0" cellspacing="15" width="500">
                            <tr><td align="center">Registration Completed</td></tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr><td align="center" class="Error">You have successfully completed your registration. You will get email for your registration approval.</td></tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr><td align="center">With Regards</td></tr>
                            <tr><td align="center">Valuation Central</td></tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr><td align="center"><a href="Login.aspx" class="LinkButton">Click here to Login</a></td></tr>
                        </table>
                    </td>
                </tr>
            </table>            
        </td>
    </tr>
</table>
</asp:Content>
