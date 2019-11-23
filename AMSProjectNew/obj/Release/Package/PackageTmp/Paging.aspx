<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paging.aspx.cs" Inherits="AMSProjectNew.Paging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .Repeater, .Repeater td, .Repeater td
        {
            border: 1px solid #ccc;
        }
        .Repeater td
        {
            background-color: #eee !important;
        }
        .Repeater th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        .Repeater span
        {
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .page_enabled, .page_disabled
        {
            display: inline-block;
            height: 20px;
            min-width: 20px;
            line-height: 20px;
            text-align: center;
            text-decoration: none;
            border: 1px solid #ccc;
        }
        .page_enabled
        {
            background-color: #eee;
            color: #000;
        }
        .page_disabled
        {
            background-color: #6C6C6C;
            color: #fff !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="Repeater" cellspacing="0" rules="all" border="1">
        <tr>
            <th scope="col" style="width: 80px">
                Customer Id
            </th>
            <th scope="col" style="width: 150px">
                Customer Name
            </th>
            <th scope="col" style="width: 150px">
                Company Name
            </th>
        </tr>
        <asp:Repeater ID="rptCustomers" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblCustomerId" runat="server" Text='<%# Eval("CustomerId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("ContactName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
    <asp:Repeater ID="rptPager" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
