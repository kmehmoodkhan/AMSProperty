<%@ Page Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" CodeBehind="DownloadReports.aspx.cs" 
Inherits="AMSProjectNew.ValuationManager.DownloadReports" Title="Download Reports" %>
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
        //var DialogRes = confirm("Are you sure you want to delete records?");
        //return DialogRes;
        return true;
    }
    else {
        alert("Please select checkboxes to download reports.");
        return false;
    }
}
function ConfirmArchive() {
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
        var DialogRes = confirm("Are you sure you want to archive profiles?");
        return DialogRes;
    }
    else {
        alert("Must Select Atleast One Record To Archive Profile.");
        return false;
    }
}
</script>
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Download Reports</i></td>
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
                    <td colspan="3" align="center" style="padding:5px 0px 5px 0px;display:none;">
                        <table cellpadding="0" cellspacing="5">
                            <tr>
                                <td>Completed:</td>
                                <td>Start</td>
                                <td>End</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:TextBox ID="txtStart" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtEnd" runat="server"></asp:TextBox></td>
                                <td><asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" OnClientClick="return ConfirmDelete();" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="right">
                        <table cellpadding="0" cellspacing="2">
                            <tr>
                                <td class="Error">Use checkboxes check/uncheck to download PDF for reports.</td>
                                <td><asp:Button ID="btnDownload" runat="server" Text="Download PDF" onclick="btnDownload_Click" /></td>
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
                                <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Job ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <a class="JobId" href='JobOrderDetails.aspx?JobId=<%# DataBinder.Eval(Container.DataItem,"JobId") %>'><%# DataBinder.Eval(Container.DataItem,"JobId") %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address / Suburb" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "UnitLot")%><%# DataBinder.Eval(Container.DataItem, "StreetNumber")%>&nbsp;
                                        <%# DataBinder.Eval(Container.DataItem, "StreetName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "StreetType")%>&nbsp;
                                        <%# DataBinder.Eval(Container.DataItem, "Suburb")%>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "State")%>&nbsp;&nbsp;
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="1">
                                            <tr>
                                                <td align="left" class="JobValuer2"><%# DataBinder.Eval(Container.DataItem,"ClientName") %></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valuer" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr><td colspan="2" class="JobValuer1">
                                                <%# DataBinder.Eval(Container.DataItem, "ValuationCompanyName")%>&nbsp;
                                                <span class="JobValuer2"><%# DataBinder.Eval(Container.DataItem, "ValuerName")%></span>&nbsp;
                                                <%# DataBinder.Eval(Container.DataItem, "ValuerPhone1")%></td></tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Start/Completed" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="5" >
                                            <tr><td><%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>&nbsp;-&nbsp;<%# DataBinder.Eval(Container.DataItem, "ReportUploadedOn")%></td></tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Status" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="5" >
                                            <tr><td style="font-size:14px;"><asp:Label Font-Bold="true" ID="lblStatusName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusName")%>'></asp:Label></td></tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="30px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbheaderCategory" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JobId")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblReportUpload" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportUpload")%>' Visible="false"></asp:Label>
                                        <asp:CheckBox ID="chkDelete" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
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

