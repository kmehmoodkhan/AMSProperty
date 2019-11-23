<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageJobOrderList.aspx.cs" Inherits="AMSProjectNew.Admin.ManageJobOrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left" height="40px" style="padding-bottom:10px;"><i>Manage Job Orders</i></td>
    </tr>
    <tr>
        <td align="left">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" width="60px" runat="server" id="tdAll"><asp:LinkButton ID="lbtnALL" runat="server" Text="ALL" onclick="lbtnALL_Click"></asp:LinkButton></td>
                    <td align="center" width="80px" runat="server" id="tdIncoming"><asp:LinkButton ID="lbtnIncoming" runat="server" Text="Incoming" onclick="lbtnIncoming_Click"></asp:LinkButton></td>
                    <td align="center" width="70px" runat="server" id="tdQueued"><asp:LinkButton ID="lbtnQueued" runat="server" Text="Queued" onclick="lbtnQueued_Click"></asp:LinkButton></td>
                    <td align="center" width="90px" runat="server" id="tdRejectFee"><asp:LinkButton ID="lbtnRejectFee" runat="server" Text="Reject Fee" onclick="lbtnRejectFee_Click"></asp:LinkButton></td>
                    <td align="center" width="100px" runat="server" id="tdInProgress"><asp:LinkButton ID="lbtnInProgress" runat="server" Text="In Progress" onclick="lbtnInProgress_Click"></asp:LinkButton></td>
                    <td align="center" width="90px" runat="server" id="tdCompleted"><asp:LinkButton ID="lbtnCompleted" runat="server" Text="Completed" onclick="lbtnCompleted_Click"></asp:LinkButton></td>
                    <td align="center" width="90px" runat="server" id="tdQueried"><asp:LinkButton ID="lbtnQueried" runat="server" Text="Queried" onclick="lbtnQueried_Click"></asp:LinkButton></td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnStatus" runat="server" />
        </td>
    </tr>
    <tr>
        <td  style="background:white;">
            <table cellpadding="0" cellspacing="0" width="100%" >
                <tr>
                    <td colspan="3" align="center" style="background-color:#FFFBCE;">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr><td><asp:Label CssClass="Error" ID="lblTotal" runat="server"></asp:Label></td></tr>
                            <tr><td align="center"><asp:Label CssClass="Error" ID="lblMessage" runat="server" Font-Bold="true"></asp:Label></td></tr>
                        </table>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td colspan="3" align="right">
                        <table cellpadding="0" cellspacing="5" width="100%">
                            <tr>
                                <td align="left" style="width:100px;">Select Client:</td>
                                <td align="left" style="width:220px;"><asp:DropDownList ID="ddlClients" runat="server" CssClass="DDL" Width="210px"></asp:DropDownList></td>
                                <td align="left"><asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="Search" onclick="btnSearch_Click"></asp:Button></td>
                                <td align="right"><asp:Button Visible="false" ID="btnCreateJob" runat="server" CssClass="Button" Text="Order New Valuation" onclick="btnCreateJob_Click"></asp:Button></td>
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
                            GridLines="None" Width="100%" onrowdatabound="gvJobs_RowDataBound" 
                            onrowcommand="gvJobs_RowCommand" >
                            <PagerStyle CssClass="JobGridAlt" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Right" />
                            <HeaderStyle CssClass="JobListGridHeader" />
                            <RowStyle CssClass="JobGridDateRow" />
                            <AlternatingRowStyle CssClass="JobGridAlt" />
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                            <Columns>              
                                <asp:TemplateField HeaderText="Job ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <a class="JobId" href='ManageJobOrderDetails.aspx?JobId=<%# DataBinder.Eval(Container.DataItem,"JobId") %>'><%# DataBinder.Eval(Container.DataItem,"JobId") %></a>
                                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address / Suburb" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td valign="top" width="20px"><img src="../Images/globe-tiny.gif" /></td>
                                                <td align="left" class="JobAddress1"><%# DataBinder.Eval(Container.DataItem, "UnitLot")%><%# DataBinder.Eval(Container.DataItem, "StreetNumber")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "StreetName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "StreetType")%></td>
                                            </tr>
                                            <tr><td colspan="2" class="JobAddress2"><%# DataBinder.Eval(Container.DataItem, "Suburb")%>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "State")%>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "Postcode")%></td></tr>
                                        </table>
                                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr>
                                                <td valign="top" width="25px"><img src="../Images/contact-new.gif" /></td>
                                                <td align="left" class="JobClientName"><%# DataBinder.Eval(Container.DataItem,"ClientName") %></td>
                                            </tr>
                                            <tr><td colspan="2" class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem,"ClientAddress") %></td></tr>
                                        </table>
                                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valuer" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr><td colspan="2" class="JobValuer1"><%# DataBinder.Eval(Container.DataItem, "ValuationCompanyName")%></td></tr>
                                            <tr><td valign="top" width="20px"><img src="../Images/contact-tiny.gif" /></td><td class="JobValuer2"><%# DataBinder.Eval(Container.DataItem, "ValuerName")%></td></tr>
                                            <tr><td colspan="2" class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "ValuerPhone1")%></td></tr>
                                        </table>
                                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="3">
                                            <tr><td class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "PurposeType")%></td></tr>
                                            <tr><td class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "PropertyTypeType")%></td></tr>
                                            <tr><td class="JobClientAddress"><%# DataBinder.Eval(Container.DataItem, "ServiceType")%></td></tr>
                                        </table>
                                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="5" >
                                            <tr><td align="center" style="font-size:14px;"><asp:Label Font-Bold="true" ID="lblStatusName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusName")%>'></asp:Label></td></tr>
                                            <tr><td align="center"><asp:Label Font-Bold="true" Font-Names="Tahoma" ID="lblAppointmentSet" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AppointmentSet")%>'></asp:Label></td></tr>
                                            <tr><td align="center"><asp:Label Font-Bold="true" Font-Names="Tahoma" ID="lblPaymentStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentStatus")%>'></asp:Label></td></tr>
                                        </table>
                                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle Width="150px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" Visible="false">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="5" >
                                            <tr><td align="center">
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="Button" OnClientClick="return confirm('Are you sure to delete job?');" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobId")%>' CommandName="DD" /></td></tr>
                                        </table>
                                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle Width="150px"></ItemStyle>
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
