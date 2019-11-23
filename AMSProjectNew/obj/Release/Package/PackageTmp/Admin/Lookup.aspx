<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Lookup.aspx.cs" Inherits="AMSProjectNew.Admin.Lookup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updJob" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="2" class="LeftTitle" align="left" height="40px" style="padding-bottom: 10px;">
                        <i>Manage Custom Values</i>
                    </td>
                </tr>
                <tr>
                    <td style="background: white; padding-top:10px;width:280px; border-right:solid 2px silver; padding-left:20px;" valign="top">
                        <asp:HiddenField ID="hdnListType" runat="server" />
                        <table cellpadding="0" cellspacing="10" style="font-size:13px;">
                            <tr><td>1.</td><td><asp:LinkButton runat="server" ID="lbtnValuationApproach" onclick="lbtnValuationApproach_Click">Valuation Approach</asp:LinkButton></td></tr>
                            <tr><td>2.</td><td><asp:LinkButton runat="server" ID="lbtnValuationPurpose" onclick="lbtnValuationPurpose_Click">Valuation Purpose</asp:LinkButton></td></tr>
                            <tr><td>3.</td><td><asp:LinkButton runat="server" ID="lbtnPropertyType" onclick="lbtnPropertyType_Click">Property Type</asp:LinkButton></td></tr>
                            <tr><td>4.</td><td><asp:LinkButton runat="server" ID="lbtnlbtnPropertyIdentification" onclick="lbtnPropertyIdentification_Click">Property Identification</asp:LinkButton></td></tr>
                            <tr><td>5.</td><td><asp:LinkButton runat="server" ID="lbtnTitleSearch" onclick="lbtnTitleSearch_Click">Title Search</asp:LinkButton></td></tr>
                            <tr><td>6.</td><td><asp:LinkButton runat="server" ID="lbtnPlan" onclick="lbtnPlan_Click">Plan</asp:LinkButton></td></tr>
                            <tr><td>7.</td><td><asp:LinkButton runat="server" ID="lbtnRegisteredProprietors" onclick="lbtnRegisteredProprietors_Click">Registered Proprietors</asp:LinkButton></td></tr>
                            <tr><td>8.</td><td><asp:LinkButton runat="server" ID="lbtnEncumbrances" onclick="lbtnEncumbrances_Click">Encumbrances</asp:LinkButton></td></tr>
                            <tr><td>9.</td><td><asp:LinkButton runat="server" ID="lbtnZoningEffect" onclick="lbtnZoningEffect_Click">Zoning Effect</asp:LinkButton></td></tr>
                            <tr><td>10.</td><td><asp:LinkButton runat="server" ID="lbtnSiteLayout" onclick="lbtnSiteLayout_Click">Site Layout</asp:LinkButton></td></tr>
                            <tr><td>11.</td><td><asp:LinkButton runat="server" ID="lbtnServices" onclick="lbtnServices_Click">Services</asp:LinkButton></td></tr>
                            <tr><td>12.</td><td><asp:LinkButton runat="server" ID="lbtnEnvironmentalHazards" onclick="lbtnEnvironmentalHazards_Click">Environmental Hazards</asp:LinkButton></td></tr>
                            <tr><td>13.</td><td><asp:LinkButton runat="server" ID="lbtnPestInfestation" onclick="lbtnPestInfestation_Click">Pest Infestation</asp:LinkButton></td></tr>
                            <tr><td>14.</td><td><asp:LinkButton runat="server" ID="lbtnPropertyStyle" onclick="lbtnPropertyStyle_Click">Property Style</asp:LinkButton></td></tr>
                            <tr><td>15.</td><td><asp:LinkButton runat="server" ID="lbtnExternalWalls" onclick="lbtnExternalWalls_Click">External Walls</asp:LinkButton></td></tr>
                            <tr><td>16.</td><td><asp:LinkButton runat="server" ID="lbtnRoof" onclick="lbtnRoof_Click">Roof</asp:LinkButton></td></tr>
                            <tr><td>17.</td><td><asp:LinkButton runat="server" ID="lbtnWallLinings" onclick="lbtnWallLinings_Click">Wall Linings</asp:LinkButton></td></tr>
                            <tr><td>18.</td><td><asp:LinkButton runat="server" ID="lbtnMainFlooring" onclick="lbtnMainFlooring_Click">Main Flooring</asp:LinkButton></td></tr>
                            <tr><td>19.</td><td><asp:LinkButton runat="server" ID="lbtnWindowFrames" onclick="lbtnWindowFrames_Click">Window Frames</asp:LinkButton></td></tr>
                            <tr><td>20.</td><td><asp:LinkButton runat="server" ID="lbtnInternalCondition" onclick="lbtnInternalCondition_Click">Internal Condition</asp:LinkButton></td></tr>
                            <tr><td>21.</td><td><asp:LinkButton runat="server" ID="lbtnExternalCondition" onclick="lbtnExternalCondition_Click">External Condition</asp:LinkButton></td></tr>
                            <tr><td>22.</td><td><asp:LinkButton runat="server" ID="lbtnStreetAppeal" onclick="lbtnStreetAppeal_Click">Street Appeal</asp:LinkButton></td></tr>
                        </table>
                    </td>
                    <td style="background: white; padding-left:20px;" valign="top">
                        <table cellpadding="0" cellspacing="10">
                            <tr>
                                <td>
                                    <asp:Label  ID="lblName" runat="server" Font-Bold="true"></asp:Label>
                                    <asp:HiddenField ID="hdnId" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table cellpadding="0" cellspacing="10">
                                        <tr>
                                            <td colspan="2" height="20px">
                                                <asp:Label ID="lblError" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Name:</td>
                                            <td><asp:TextBox Width="500px" ID="txtPropertyName" runat="server" CssClass="TextBox"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td height="40px">
                                                <asp:Button CssClass="Button" ID="btnSubmit" runat="server" Text="Submit" 
                                                    OnClientClick="return CheckValidation();" onclick="btnSubmit_Click"
                                                    />
                                                <asp:Button CssClass="Button" ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" 
                                                    />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gvPropertyType" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                            PageSize="100" Width="600px" OnPageIndexChanging="gvPropertyType_PageIndexChanging"
                            CssClass="Grid" OnRowDataBound="gvPropertyType_RowDataBound" GridLines="None" AllowSorting="false">
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last"
                                NextPageText="Next" PreviousPageText="Prev" />
                            <RowStyle CssClass="GridRow" />
                            <AlternatingRowStyle CssClass="GridAlt" />
                            <Columns>
                                <asp:TemplateField HeaderText="Delete" Visible="false">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbheaderCategory" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDelete" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Property Name" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        &nbsp;<asp:Label ID="lblPropertyName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        &nbsp;<asp:ImageButton ID="btnEdit" runat="server" Style="padding-right: 5px; height: 15px;"
                                            ImageUrl="~/Images/btn_edit.gif" OnClick="btnEdit_Click" CausesValidation="False"
                                            ToolTip="Edit record" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                        <asp:ImageButton ID="btnDelete" runat="server" Style="padding-right: 5px; height: 15px;"
                                            ImageUrl="~/Images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="False"
                                            ToolTip="Delete record" OnClientClick="return confirm('Are you sure to delete the recor?');" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br /><br />
                        <table cellpadding="0" cellspacing="30" style="font-size:12px;display:none;">
                            
                            <tr>
                                <td style="width:250px;">
                                    1 <a id="va1" href="LookuplistType.aspx?type=Valuation Approach">Valuation Approach</a>
                                </td>
                                <td style="width:250px;">
                                    2 <a id="A1" href="LookuplistType.aspx?type=Property Type">Property Type</a>
                                </td>
                                <td style="width:250px;">
                                    3 <a id="A2" href="LookuplistType.aspx?type=Property Identification">Property Identification</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4 <a id="A3" href="LookuplistType.aspx?type=Title Search">Title Search</a>
                                </td>
                                <td>
                                    5 <a id="A4" href="LookuplistType.aspx?type=Plan">Plan</a>
                                </td>
                                <td>
                                    6 <a id="A6" href="LookuplistType.aspx?type=Registered Proprietors">Registered Proprietors</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    7 <a id="A7" href="LookuplistType.aspx?type=Encumbrances">Encumbrances</a>
                                </td>
                                <td>
                                    8 <a id="A8" href="LookuplistType.aspx?type=Zoning Effect">Zoning Effect</a>
                                </td>
                                <td>
                                    9 <a id="A9" href="LookuplistType.aspx?type=Site Layout">Site Layout</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    10 <a id="A10" href="LookuplistType.aspx?type=Services">Services</a>
                                </td>
                                <td>
                                    11 <a id="A11" href="LookuplistType.aspx?type=Environmental Hazards">Environmental Hazards</a>
                                </td>
                                <td>
                                    12 <a id="A12" href="LookuplistType.aspx?type=Pest Infestation">Pest Infestation</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    13 <a id="A13" href="LookuplistType.aspx?type=Property Style">Property Style</a>
                                </td>
                                <td>
                                    14 <a id="A14" href="LookuplistType.aspx?type=External Walls">External Walls</a>
                                </td>
                                <td>
                                    15 <a id="A15" href="LookuplistType.aspx?type=Roof">Roof</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    16 <a id="A16" href="LookuplistType.aspx?type=Wall Linings">Wall Linings</a>
                                </td>
                                <td>
                                    17 <a id="A17" href="LookuplistType.aspx?type=Main Flooring">Main Flooring</a>
                                </td>
                                <td>
                                    18 <a id="A18" href="LookuplistType.aspx?type=Window Frames">Window Frames</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    19 <a id="A19" href="LookuplistType.aspx?type=Internal Condition">Internal Condition</a>
                                </td>
                                <td>
                                    20 <a id="A20" href="LookuplistType.aspx?type=External Condition">External Condition</a>
                                </td>
                                <td>
                                    21 <a id="A21" href="LookuplistType.aspx?type=Street Appeal">Street Appeal</a>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    22 <a id="A5" href="LookuplistType.aspx?type=Purpose">Purpose</a>
                                </td>
                                <td>
                                    23 <a id="A22" href="LookuplistType.aspx?type=Access Arrangement Via">Access Arrangement Via</a>
                                </td>
                                <td>
                                    24 <a id="A23" href="LookuplistType.aspx?type=Service Type">Service Type</a>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    25 <a id="A24" href="LookuplistType.aspx?type=Urgency">Urgency</a>
                                </td>
                                <td>
                                    
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
