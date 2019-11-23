<%@ Page Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" 
CodeBehind="DownloadClients.aspx.cs" Inherits="AMSProjectNew.ValuationManager.DownloadClients" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">

    function SelectAllCheckboxesCategoryList(spanChk) {
        var chkALL = document.getElementById(spanChk);
        var the_form = window.document.forms[0];
        for (var i = 0; i < the_form.length; i++) {
            var temp = the_form.elements[i].type;
            if (temp == "checkbox") {
                if (the_form.elements[i].name.indexOf("chkDelete") > -1) {
                    the_form.elements[i].checked = chkALL.checked;
                }
            }
        }
    }

    function UncheckAllCategoryList(CheckItemClientID) {
        var chkItem = document.getElementById(CheckItemClientID);
        var the_form = window.document.forms[0];
        for (var i = 0; i < the_form.length; i++) {
            var temp = the_form.elements[i].type;
            if (temp == "checkbox") {

                if (the_form.elements[i].name.indexOf("cbheaderCategory") > -1) {
                    if (the_form.elements[i].checked = false)
                        the_form.elements[i].checked = chkItem.checked;
                }

            }
        }
    }
    function ConfirmDelete() {
        var the_form = window.document.forms[0];
        var flagDel = 1;
        for (var i = 0; i < the_form.length; i++) {
            var temp = the_form.elements[i].type;
            if (temp == "checkbox") {
                if (the_form.elements[i].name.indexOf("chkDelete") > -1) {
                    if (the_form.elements[i].checked == true) {
                        flagDel = 0;
                        break;
                    }

                }
            }
        }
        if (flagDel == 0) {
            return true;
        }
        else {
            alert("Please select checkboxes to export records into Excel.");
            return false;
        }
    }

        </script>
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Download Clients</i></td>
    </tr>
    <tr>
        <td style="background:white;">
            <table cellpadding="0" cellspacing="0" width="100%" >
                <tr>
                    <td colspan="3" align="center" style="background-color:#FFFBCE;">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr><td><asp:Label CssClass="Error" ID="lblTotal" runat="server"></asp:Label></td></tr>
                            <tr><td><asp:Label Font-Bold="true" CssClass="Error" ID="lblMessage" runat="server"></asp:Label></td></tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left" style="padding:5px 0px 5px 20px;">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr>
                                <td width="40px">Status:</td>
                                <td width="100px"><asp:DropDownList ID="ddlStatus" CssClass="DDL" runat="server"></asp:DropDownList></td>
                                <td width="100px"><asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" /></td>
                                <td align="right"><asp:Button ID="btnDownload" runat="server" Text="Export to Excel" onclick="btnDownload_Click" OnClientClick="return ConfirmDelete();" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="right">
                        <table cellpadding="0" cellspacing="2">
                            <tr>
                                <td></td>
                                <td>Page Size:</td>
                                <td>
                                    <asp:DropDownList ID="ddlPageSize" CssClass="DDL" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPageSize_SelectedIndexChanged">
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="50" Value="50"></asp:ListItem>
                                        <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvJobs" runat="server" AutoGenerateColumns="false" AllowPaging="true" 
                            PageSize="10" OnPageIndexChanging="gvJobs_PageIndexChanging" 
                            GridLines="None" Width="100%" onrowdatabound="gvJobs_RowDataBound" >
                            <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                            <HeaderStyle CssClass="JobListGridHeader" />
                            <RowStyle CssClass="JobGridDateRow" />
                            <AlternatingRowStyle CssClass="JobGridAlt" />
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                            <Columns>
                                
                                <asp:BoundField DataField="JobId" HeaderText="Job Id" />
                                <asp:BoundField DataField="ClientName" HeaderText="Client" />
                                <asp:BoundField DataField="InstructedBy" HeaderText="Instructed By" />
                                <asp:BoundField DataField="Address" HeaderText="Address" /><asp:BoundField DataField="MobilePhoneNumber" HeaderText="Phone" />
                                <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                <asp:BoundField DataField="ValuationCompanyName" HeaderText="Valuation Company" />
                                <asp:BoundField DataField="StatusName" HeaderText="Status" />
                                <asp:BoundField DataField="CreatedOn" HeaderText="Date" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbheaderCategory" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDelete" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

