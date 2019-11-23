<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageClients.aspx.cs" Inherits="AMSProjectNew.Admin.ManageClients" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
function SelectAllCheckboxesCategoryList(spanChk)
{
    var chkALL = document.getElementById(spanChk);
    var the_form = window.document.forms[0];
    for(var i=0; i<the_form.length; i++)
    {
        var temp = the_form.elements[i].type;
        if(temp == "checkbox")
        {
            if (the_form.elements[i].name.indexOf("chkDelete") > -1)
            {
                the_form.elements[i].checked = chkALL.checked;
            }
        }
    }  
}

function UncheckAllCategoryList(CheckItemClientID)
{
    var chkItem = document.getElementById(CheckItemClientID);
    var the_form = window.document.forms[0];
    for(var i=0; i<the_form.length; i++)
    {
        var temp = the_form.elements[i].type;
        if(temp == "checkbox")
        {
            if (the_form.elements[i].name.indexOf("cbheaderCategory") > -1)
            {  
                if(the_form.elements[i].checked = false)
                    the_form.elements[i].checked = chkItem.checked;
            }
        }
    }  
}
function ConfirmDelete()
{ 
    var the_form = window.document.forms[0];
    var flagDel=1;
    for(var i=0; i<the_form.length; i++)
    {
        var temp = the_form.elements[i].type;
        if(temp == "checkbox")
        {
            if (the_form.elements[i].name.indexOf("chkDelete") > -1)
            {
                 if(the_form.elements[i].checked == true)
                 {
                    flagDel=0;
                    break;
                 } 
            }
        }
    }  
    if(flagDel==0)
    {
        var DialogRes = confirm("Are you sure you want to delete records?");
        return DialogRes;
    }
    else
    {
       alert("Must Select Atleast One Record To Delete.");
       return false;
    }
}
</script>
<table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td class="LeftTitle" align="left"><i>Manage Clients</i></td>
    </tr>
    <tr>
        <td  style="background:white;">
            <table cellpadding="0" cellspacing="10" width="100%" >
                <tr>
                    <td><asp:Label CssClass="Error" ID="lblTotal" runat="server"></asp:Label></td>
                    <td align="center" class="BlackText2" >
                        <table cellpadding="0" cellspacing="5">
                            <tr>
                                <td title="New Status" style="background-color:Orange; height:10px; width:8px; border:solid 1px Orange;"></td>
                                <td>New</td>
                                <td>&nbsp;</td>
                                <td title="Active Status" style="background-color:Green; height:10px; width:8px; border:solid 1px Green;"></td>
                                <td>Active</td>
                                <td>&nbsp;</td>
                                <td title="Inactive Status" style="background-color:Red; height:10px; width:8px; border:solid 1px Red;"></td>
                                <td>Inactive</td>
                            </tr>
                        </table>
                    </td>
                    <td align="right"><asp:Button CssClass="Button" ID="btnNewEntry" runat="server" Text="New Client" onclick="btnNewEntry_Click" /></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ShowHeader="false" ID="gvClients" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                            PageSize="10" Width="100%" OnPageIndexChanging="gvClients_PageIndexChanging" 
                            CssClass="Grid" onrowdatabound="gvClients_RowDataBound" GridLines="None">
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prev" />
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
                                <asp:TemplateField HeaderText="&nbsp;Company" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="10">
                                            <tr><td tooltip='<%# DataBinder.Eval(Container.DataItem,"StatusTooltip") %>' title='<%# DataBinder.Eval(Container.DataItem,"StatusTooltip") %>' style='background-color:<%# DataBinder.Eval(Container.DataItem,"StatusColor") %>; height:10px; width:8px; border:solid 1px <%# DataBinder.Eval(Container.DataItem,"StatusColor") %>;'></td></tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Company" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr><td class="BlueText1"><%# DataBinder.Eval(Container.DataItem,"CompanyName") %></td></tr>
                                            <tr><td class="BlackText2"><%# DataBinder.Eval(Container.DataItem,"Address") %></td></tr>
                                            <tr><td class="BlackText2"><%# DataBinder.Eval(Container.DataItem,"Suburb") %>&nbsp;<%# DataBinder.Eval(Container.DataItem,"State") %>&nbsp;-&nbsp;<%# DataBinder.Eval(Container.DataItem,"Postcode") %></td></tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Type" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>                                            
                                        <table cellpadding="0" cellspacing="0">
                                            <tr><td class="BlueText1"><%# DataBinder.Eval(Container.DataItem,"FirstName") %>&nbsp;<%# DataBinder.Eval(Container.DataItem,"LastName") %></td></tr>
                                            <tr><td class="BlackText2"><%# DataBinder.Eval(Container.DataItem, "Email")%></td></tr>
                                            <tr><td class="BlackText2"><%# DataBinder.Eval(Container.DataItem,"Phone1") %></td></tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="&nbsp;Name" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>                                            
                                        &nbsp;<%# DataBinder.Eval(Container.DataItem,"FirstName") %>&nbsp;<%# DataBinder.Eval(Container.DataItem,"LastName") %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Address" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>                                            
                                        &nbsp;<%# DataBinder.Eval(Container.DataItem,"Address") %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Suburb")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "State")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Postcode")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Status" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>                                            
                                        &nbsp;<%# DataBinder.Eval(Container.DataItem, "StatusShow")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;Created On" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>                                            
                                        &nbsp;<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        &nbsp;<a href='ManageClientsEdit.aspx?Id=<%# DataBinder.Eval(Container.DataItem,"UserId") %>'><img src="../Images/btn_edit.gif" border="0"></a><%--<asp:ImageButton ID="btnEdit" runat="server" Style="padding-right: 5px; height:15px;" ImageUrl="~/Images/btn_edit.gif" OnClick="btnEdit_Click" CausesValidation="False" ToolTip="Edit record" />--%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"UserId") %>'></asp:Label>
                                        <asp:ImageButton ID="btnDelete" runat="server" Style="padding-right: 5px; height:15px;" ImageUrl="~/Images/btn_delete.gif" OnClick="btnDelete_Click" CausesValidation="False" ToolTip="Delete record" OnClientClick="return confirm('Are you sure to delete the recor?');" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
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
