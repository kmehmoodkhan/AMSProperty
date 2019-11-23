<%@ Page Title="" Language="C#" MasterPageFile="~/ValuationManager/ValuationManagerMaster.Master" AutoEventWireup="true" CodeBehind="JobOrderList.aspx.cs" Inherits="AMSProjectNew.ValuationManager.JobOrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Job Orders</i></td>
    </tr>
    <tr>
        <td align="left">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="display:none;" align="center" width="60px" runat="server" id="tdAll"><asp:LinkButton ID="lbtnALL" runat="server" Text="ALL" onclick="lbtnALL_Click"></asp:LinkButton></td>
                    <td align="center" width="80px" runat="server" id="tdIncoming"><asp:LinkButton ID="lbtnIncoming" runat="server" Text="Incoming" onclick="lbtnIncoming_Click"></asp:LinkButton></td>
                    <td align="center" width="70px" runat="server" id="tdQueued"><asp:LinkButton ID="lbtnQueued" runat="server" Text="Queued" onclick="lbtnQueued_Click"></asp:LinkButton></td>
                    <td align="center" width="90px" runat="server" id="tdRejectFee"><asp:LinkButton ID="lbtnRejectFee" runat="server" Text="Reject Fee" onclick="lbtnRejectFee_Click"></asp:LinkButton></td>
                    <td align="center" width="100px" runat="server" id="tdInProgress"><asp:LinkButton ID="lbtnInProgress" runat="server" Text="In Progress" onclick="lbtnInProgress_Click"></asp:LinkButton></td>
                    <td align="center" width="90px" runat="server" id="tdCompleted"><asp:LinkButton ID="lbtnCompleted" runat="server" Text="Completed" onclick="lbtnCompleted_Click"></asp:LinkButton></td>
                    <td align="center" width="90px" runat="server" id="tdQueried"><asp:LinkButton ID="lbtnQueried" runat="server" Text="Queried" onclick="lbtnQueried_Click"></asp:LinkButton></td>
                    <td align="center" width="90px">&nbsp;</td>
                    <td align="center" width="100px" runat="server" id="tdUpdate"><asp:LinkButton ID="lbtnUpdate" runat="server" Text="Job Update" onclick="lbtnUpdate_Click"></asp:LinkButton></td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnStatus" runat="server" />
            <asp:HiddenField ID="hdnIsEditRequest" runat="server" />
        </td>
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
                    <td colspan="3" align="right" style="padding:5px 0px 5px 0px;">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="5">
                                        <tr>
                                            <td>Job ID</td>
                                            <td><asp:TextBox ID="txtJobIdSearch" runat="server" CssClass="TextBox" Width="100px"></asp:TextBox></td>
                                            <td>&nbsp;</td>
                                            <td>Client</td>
                                            <td><asp:TextBox ID="txtClientSearch" runat="server" CssClass="TextBox" Width="100px"></asp:TextBox></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Street</td>
                                            <td><asp:TextBox ID="txtStreetSearch" runat="server" CssClass="TextBox" Width="100px"></asp:TextBox></td>
                                            <td></td>
                                            <td>Suburb</td>
                                            <td><asp:TextBox ID="txtSuburbSearch" runat="server" CssClass="TextBox" Width="100px"></asp:TextBox></td>
                                            <td>&nbsp;</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>Valuers</td>
                                            <td><asp:DropDownList ID="ddlValuers" runat="server"></asp:DropDownList></td>
                                            <td></td>
                                            <td>Purpose</td>
                                            <td><asp:DropDownList ID="ddlPurpose" runat="server"></asp:DropDownList></td>
                                            <td></td>
                                            <td><asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="Search" onclick="btnSearch_Click"></asp:Button>&nbsp;<asp:Button ID="btnSearchClear" runat="server" CssClass="Button" Text="Clear" onclick="btnSearchClear_Click"></asp:Button></td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" valign="top">
                                    <asp:Button Width="145px" ID="btnCreateJob" runat="server" CssClass="Button" Text="Order New Valuation" onclick="btnCreateJob_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="right">
                        <table cellpadding="0" cellspacing="2">
                            <tr>
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
                        <asp:GridView ID="gvJobs" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                            PageSize="10" OnPageIndexChanging="gvJobs_PageIndexChanging" 
                            GridLines="None" Width="100%" onrowdatabound="gvJobs_RowDataBound" >
                            <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                            <HeaderStyle CssClass="JobListGridHeader" />
                            <RowStyle CssClass="JobGridDateRow" />
                            <AlternatingRowStyle CssClass="JobGridAlt" />
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                            <Columns>              
                                <asp:TemplateField HeaderText="Job ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <a class="JobId" href='JobOrderDetails.aspx?JobId=<%# DataBinder.Eval(Container.DataItem,"JobId") %>'><%# DataBinder.Eval(Container.DataItem,"JobId") %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address / Suburb" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <%--<td valign="top" width="20px"><img src="../Images/globe-tiny.gif" /></td>--%>
                                                <td align="left" class="JobAddress1"><%# DataBinder.Eval(Container.DataItem, "UnitLot")%><%# DataBinder.Eval(Container.DataItem, "StreetNumber")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "StreetName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "StreetType")%></td>
                                            </tr>
                                            <tr><td colspan="2" class="JobAddress2"><%# DataBinder.Eval(Container.DataItem, "Suburb")%>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "State")%>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "Postcode")%></td></tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td valign="middle" align="left" class="JobClientName"><%# DataBinder.Eval(Container.DataItem, "ClientName")%></td>
                                                <td valign="middle" width="16px"><asp:Label ID="lblIsClientReportEdit" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsClientReportEdit")%>'></asp:Label></td>
                                            </tr>
                                            <%--<tr><td colspan="2" class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem,"ClientAddress") %></td></tr>--%>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valuer" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr><td colspan="2" class="JobValuer1"><%# DataBinder.Eval(Container.DataItem, "ValuationCompanyName")%></td></tr>
                                            <tr><%--<td valign="top" width="20px"><img src="../Images/contact-tiny.gif" /></td>--%><td class="JobValuer2"><%# DataBinder.Eval(Container.DataItem, "ValuerUserName")%></td></tr>
                                            <tr><td colspan="2" class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "ValuerPhone1")%></td></tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr><td class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "PurposeType")%></td></tr>
                                            <tr><td class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "PropertyTypeType")%></td></tr>
                                            <%--<tr><td class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "ValuationType")%></td></tr>--%>
                                            <tr><td class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "ValuationTypeName")%></td></tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="5" >
                                            <tr><td align="center" style="font-size:14px;"><asp:Label Font-Bold="true" ID="lblStatusName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusName")%>'></asp:Label></td></tr>
                                            <tr><td align="center"><asp:Label Font-Bold="true" Font-Names="Tahoma" ID="lblAppointmentSet" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentSet")%>'></asp:Label></td></tr>
                                            <tr><td align="center"><asp:Label Font-Bold="true" Font-Names="Tahoma" ID="lblPaymentStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentStatus")%>'></asp:Label></td></tr>
                                        </table>
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
